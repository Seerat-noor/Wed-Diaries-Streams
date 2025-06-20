using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WWW.Models.Interface;
using WWWW.Models;

namespace WWW.Controllers
{
    public class AdminController : Controller
    {
        private readonly IClientRepository _repository;
        private readonly IAdminRepository _adminRepository;

        public AdminController(IClientRepository repository, IAdminRepository adminRepository)
        {
            _repository = repository;
            _adminRepository = adminRepository;
        }

        [Authorize]
        public IActionResult AdminDash()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult StatusReq()
        {
            return View();
        }
        public IActionResult Notfound()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                return RedirectToAction("AdminDash", "Admin");
            }

            ViewBag.ErrorMessage = "Invalid credentials!";
            return View("AdminDash");
        }

        public async Task<IActionResult> Requests()
        {
            var clients = await _repository.GetAllClientsAsync();
            return View(clients);
        }

        public IActionResult Dates()
        {
            if (TempData["EventDates"] != null)
            {
                TempData.Keep("EventDates");
                var dates = JsonConvert.DeserializeObject<List<DateTime>>(TempData["EventDates"].ToString());
                return View(dates);
            }

            return View(new List<DateTime>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteClientAsync(id);
            return RedirectToAction("Requests");
        }



        [HttpPost]
        public async Task<IActionResult> AddCustomer(int id)
        {
            var client = await _repository.GetClientByIdAsync(id); // You must implement this in IClientRepository
            if (client == null)
            {
                return NotFound();
            }

            var newAdmin = new Admin
            {
                // Do NOT set Id — let EF handle it
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                EventDate = client.EventDate,
                Guests = client.Guests,
                Catering = client.Catering,
                Decoration = client.Decoration,
                Entertainment = client.Entertainment,
                Type = client.Type
            };

            await _adminRepository.AddCustomerAsync(newAdmin);

            return RedirectToAction("CustomerList");
        }

        public async Task<IActionResult> CustomerList()
        {
            var customers = await _adminRepository.GetAllCustomersAsync();
            return View(customers);
        }
        [HttpPost]
        public async Task<IActionResult> GetCustomer(string fullName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return View("Error"); // or show validation error
            }

            var customer = await _adminRepository.GetCustomerAsync(fullName, phoneNumber);


            if (customer == null)
            {
                return View("Notfound");

            }

            return View("CustomerStatus", customer); // show details in a status view
        }

    }
}
