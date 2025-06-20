using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWWW.Models;

namespace WWW.Models.Interface
{
    public interface IClientRepository
    {
        Task AddClientAsync(Client client); // async EF func
        Task<List<DateTime>> GetClientEventDatesAsync(); // async EF read
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);

        Task DeleteClientAsync(int id);


    }
} 