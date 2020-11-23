using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoFinal.Clases
{
    public class UserData
    {
        const string URL = "http://134.209.220.83/proyecto/";
        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;

        }

        public async Task<IEnumerable<UserDataProfile>> getUserData(int id_user)
        {
            HttpClient cliente = getClient();

            var result = await cliente.GetAsync(URL + "user_data.php?id_user=" + id_user);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<UserDataProfile>>(content);

            }
            return Enumerable.Empty<UserDataProfile>();
        }
    }
}
