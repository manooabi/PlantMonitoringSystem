using Microsoft.AspNetCore.Mvc;
using PlantMonitoringSystem.Models;
using System.Diagnostics;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlantMonitoringSystem.Controllers
{
    public class HomeController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "Z3hvicVj20nKFHVi7MZGwQHSLHkdhNU7wI5rcGaj",
            BasePath = "https://plant-monitoring-system-app-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public IActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Plants-Monitoring-App");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Plants_Monitoring_App>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Plants_Monitoring_App>(((JProperty)item).Value.ToString()));
                }
            }

            return View(list);
        }

    }
}