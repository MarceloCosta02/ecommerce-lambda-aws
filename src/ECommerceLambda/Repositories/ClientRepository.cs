using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Interfaces.Repositories;
using ECommerceLambda.Models;

namespace ECommerceLambda.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDynamoDBContext _context;

    public ClientRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task<Client?> GetByDocument(string document)
    {
        return await _context.LoadAsync<Client?>(document);
    }

    public async Task Add(Client client)
    {
        await _context.SaveAsync(client);
    }

    public async Task Update(Client client)
    {
        await _context.SaveAsync(client);
    }

    public async Task Remove(string document)
    {
        await _context.DeleteAsync<Client>(document);
    }
}
