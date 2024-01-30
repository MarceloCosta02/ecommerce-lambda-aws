using ECommerceLambda.Model;

namespace ECommerceLambda.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetByDocument(string document);
    Task Add(Client client);
    Task Update(Client client);
    Task Remove(string document);
}
