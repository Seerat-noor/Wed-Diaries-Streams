using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWWW.Models;

namespace WWW.Models.Interface
{
    public interface IAdminRepository
    {
        Task AddCustomerAsync(Admin admin);
        Task<List<Admin>> GetAllCustomersAsync();
        Task<Admin?> GetCustomerAsync(string fullName, string phoneNumber);


    }
}