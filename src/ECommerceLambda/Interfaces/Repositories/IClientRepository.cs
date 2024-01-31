using ECommerceLambda.Models;

namespace ECommerceLambda.Interfaces.Repositories;

public interface IClientRepository
{
    Task<Client?> GetByDocument(string document);
    Task Add(Client client);
    Task Update(Client client);
    Task Remove(string document);
}
