using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Domain.Models;

public class Address
{
    [DynamoDBProperty("street")]
    public string? Street { get; set; }

    [DynamoDBProperty("number")]
    public int Number { get; set; }

    [DynamoDBProperty("complement")]
    public string? Complement { get; set; }

    [DynamoDBProperty("city")]
    public string? City { get; set; }

    [DynamoDBProperty("state")]
    public string? State { get; set; }
}