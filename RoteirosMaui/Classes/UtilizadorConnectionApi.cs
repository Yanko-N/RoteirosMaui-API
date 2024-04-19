using RoteirosMaui.Abstractions;
using RoteirosMaui.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoteirosMaui.Classes
{
    public class UtilizadorConnectionApi : IApiConnection<Utilizador>
    {
        public HttpClient HttpClient { get; set; }
        public string ExtraUrl { get; set; } = "/api/Utilizadores";
        public string Url { get; set; }

        public UtilizadorConnectionApi(HttpClient client, string baseUrl)
        {
            this.HttpClient = client;
            this.Url = baseUrl + ExtraUrl;
        }


        public Task<bool> DeleteItem(Utilizador item)
        {
            throw new NotImplementedException();
        }

        public Task<Utilizador> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Utilizador>> GetItems(string parameterName, string serchParameter)
        {
            try
            {
                // Construir a url com o predicate como query
                string url = $"{Url}{GetQueryString(parameterName, serchParameter)}";

                var response = await HttpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data = await JsonSerializer.DeserializeAsync<List<Utilizador>>(responseStream);
                        if (data.Count > 0)
                        {
                            return data;

                        }
                    }
                }
            }
            catch
            {
                //Nothing is returned
                return null;
            }
            

            //Nothing is returned
            return null;


        }

        public Task<List<Utilizador>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveItem(Utilizador item)
        {
            throw new NotImplementedException();
        }

        public string GetQueryString(string parameterName, string serchParameter)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append('?').Append(parameterName).Append('=').Append(serchParameter);

            return stringBuilder.ToString();
        }
    }
}
