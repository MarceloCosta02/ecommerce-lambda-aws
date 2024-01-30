using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Model;

[DynamoDBTable("client")]
public class Client
{
    [DynamoDBHashKey("document")]
    public string? Document { get; set; }

    [DynamoDBProperty("name")]
    public string? Name { get; set; }

    [DynamoDBProperty("email")]
    public string? Email { get; set; }

    [DynamoDBProperty("address")]
    public Address? Address { get; set; }
}
