using Microsoft.AspNetCore.Mvc;
using WWW.Models.Interface;
using WWWW.Models;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace WWWW.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "LateHoursPolicy")]
        [HttpPost]
        
        public async Task<IActionResult> RegClientEvent(Client client)
        {
            
                await _repository.AddClientAsync(client); // await async add
                return View("EventUpd"); // success page
            

          
        }


        public async Task<IActionResult> GetDates()
        {
            var dates = await _repository.GetClientEventDatesAsync();
            TempData["EventDates"] = JsonConvert.SerializeObject(dates); // Serialize list to JSON string
            return RedirectToAction("Dates", "Admin");
        }




    }
}
