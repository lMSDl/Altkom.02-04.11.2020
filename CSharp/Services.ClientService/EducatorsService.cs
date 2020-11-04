using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClientService
{
    public class EducatorsService : IEducatorsService
    {
        private HttpClient _client;



        public EducatorsService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:58846");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
        }

        public EducatorsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Educator> CreateAsync(Educator entity)
        {
            var response = await _client.PostAsJsonAsync("/api/Educators", entity);
            if(response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsAsync<int>();
                return await ReadAsync(id);
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"/api/Educators/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Educator> ReadAsync(int id)
        {
            var response = await _client.GetAsync($"/api/Educators/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<Educator>();
            return null;
        }

        public async Task<ICollection<Educator>> ReadAsync()
        {
            var response = await _client.GetAsync("/api/Educators");

            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //}
            //catch
            //{
            //    return null;
            //}

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<ICollection<Educator>>();
            else
                return null;
        }

        public async Task<ICollection<Educator>> ReadBySpecializationAsync(string specialization)
        {
            var response = await _client.GetAsync($"/api/Educators?{nameof(Educator.Specialization)}={specialization}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<ICollection<Educator>>();
            return null;
        }

        public async Task UpdateAsync(Educator entity)
        {
            var response = await _client.PutAsJsonAsync($"/api/Educators/{entity.EducatorId}", entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
