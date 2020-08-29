using GrillMaster.Application.GrillMenu.Interfaces;
using GrillMaster.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.Services
{
    /// <summary>
    /// Resumen:
    ///     Grill Menu Http Client
    /// </summary>
    public class GrillMenuClient: IGrillMenuClient
    {
        private readonly HttpClient _client;

        public GrillMenuClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://isol-grillassessment.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            _client = client;
        }

        /// <summary>
        /// Gets the menu grill collection.
        /// </summary>
        public async Task<IEnumerable<GrillMenu>> GetAll()
        {
            var response = await _client.GetAsync("/api/GrillMenu");

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();

            IEnumerable<GrillMenu> menus = JsonConvert.DeserializeObject<IEnumerable<GrillMenu>>(responseString);
            
            return menus;
        }
    }
}
