using ECommerceLambda.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IStorageService _storageService;

    public InvoiceController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("download/{document}/{year}/{month}/{day}/{invoiceId}")]
    public async Task<IActionResult> DownloadInvoice(string document, string year, string month, string day, string invoiceId)
    {
        var fileKey = $"{document}/{year}/{month}/{day}/{invoiceId}";
        var bucketName = Environment.GetEnvironmentVariable("INVOICES_BUCKET_NAME");
        var fileName = fileKey.Replace("/", "-");

        var file = await _storageService.Download(bucketName, fileKey);

        return File(file, "application/octet-stream", fileName);
    }
}
