using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Domain.Models;

[DynamoDBTable("invoice")]
public class Invoice
{
    [DynamoDBHashKey("clientDocument")]
    public string ClientDocument { get; set; }

    [DynamoDBRangeKey("invoiceId")]
    public string InvoiceId { get; set; }

    public decimal CalculationBasis { get; set; }

    public decimal TaxRate { get; set; }

    public string Description { get; set; }

    public decimal TaxValue
    {
        get => CalculationBasis * TaxRate / 100;
        private set => TaxValue = value;
    }
}