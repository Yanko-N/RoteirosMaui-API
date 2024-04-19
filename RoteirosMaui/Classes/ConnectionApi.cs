using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.Classes
{
    public class ConnectionApi
    {
        HttpClient Client;
        string BaseUrl = "https://localhost:7203";
        public UtilizadorConnectionApi utilizadorConnectionApi;
        public ConnectionApi()
        {
            Client = new HttpClient();
            utilizadorConnectionApi = new UtilizadorConnectionApi(Client,BaseUrl);
        }
    }
}
