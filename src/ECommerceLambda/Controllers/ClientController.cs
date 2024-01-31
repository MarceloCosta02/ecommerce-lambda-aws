using ECommerceLambda.Interfaces.Repositories;
using ECommerceLambda.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _repository;

    public ClientController(IClientRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{document}")]
    public async Task<IActionResult> GetByDocument(string document)
    {
        var client = await _repository.GetByDocument(document);

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        await _repository.Add(client);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Client client)
    {
        await _repository.Update(client);

        return Ok();
    }

    [HttpDelete("{document}")]
    public async Task<IActionResult> Delete(string document)
    {
        await _repository.Remove(document);

        return Ok();
    }
}
