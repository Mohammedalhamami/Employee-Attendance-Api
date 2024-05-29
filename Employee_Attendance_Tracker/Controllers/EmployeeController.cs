using Employee_Attendance_Tracker.Models.DTO;
using Employee_Attendance_Tracker.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Employee_Attendance_Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AddEmployeeViewModel>? employeesResponse = new List<AddEmployeeViewModel>();
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7059/api/Employee/GetAllEmployees");

                httpResponseMessage.EnsureSuccessStatusCode();

                employeesResponse.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AddEmployeeViewModel>>());
               
                
            }
            catch (Exception ex)
            {
            }
            return View(employeesResponse);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7059/api/Employee"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResonseMessage = await client.SendAsync(httpRequestMessage);

            httpResonseMessage.EnsureSuccessStatusCode();

            var response = await httpRequestMessage.Content.ReadFromJsonAsync<EmployeeDto>();

            if(response is not null)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

         
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<AddEmployeeViewModel>($"https://localhost:7059/api/Employee/{id}");

            return View(response);
          
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AddEmployeeViewModel request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage()
            {
				Method = HttpMethod.Put,
				RequestUri = new Uri($"https://localhost:7059/api/Employee/{request.Id}"),
				Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
			};
           var httpResponseMessage = await client.SendAsync(httpRequest);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<AddEmployeeViewModel>();

            if(response is not null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7059/api/Employee/{id}");

                httpResponseMessage.EnsureSuccessStatusCode();
               
                return RedirectToAction("Index", "Employee");
               
            }
            catch (Exception ex)
            {

            }
            return View("Edit");  
		}
    
    }
}
