using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWW.Data;
using WWW.Models.Interface;
using WWWW.Models;

namespace WWWW.Models
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context; // EF Dbcontext obj

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Admin admin)
        {
            // price per deal
            decimal budget = 0;

            switch (admin.Type?.Trim().ToLower())
            {
                case "luxury":
                    budget = (2000 * admin.Guests) + (2200 * admin.Guests) + (2500 * admin.Guests);
                    break;
                case "standard":
                default:
                    
                    budget = (1000 * admin.Guests) + (1200 * admin.Guests) + (1500 * admin.Guests);
                    break;
            }

            //  total 
            admin.Budget = budget;

            
            await _context.RegdClients.AddAsync(admin);
            await _context.SaveChangesAsync();
            
        }
        public async Task<List<Admin>> GetAllCustomersAsync()
        {
            return await _context.RegdClients.AsNoTracking().ToListAsync();
        }

        public async Task<Admin?> GetCustomerAsync(string fullName, string phoneNumber)
        {
            var customers = await GetAllCustomersAsync();
            return customers.FirstOrDefault(c =>
                c.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase) &&
                c.PhoneNumber.Equals(phoneNumber));
        }



    }
}
