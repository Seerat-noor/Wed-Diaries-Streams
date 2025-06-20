using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWW.Data;
using WWW.Models.Interface;
using WWWW.Models;

namespace WWWW.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context; // EF Dbcontext obj

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync(); // sve is handled here
        }

        public async Task<List<DateTime>> GetClientEventDatesAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .Select(c => c.EventDate)
                .ToListAsync();
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }



    }
}
