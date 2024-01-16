using Newtonsoft.Json;
using ProductBotManager.Helpers;
using ProductBotManager.Repositiry.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ProductBotManager.Services.UpcitemdbService
{
    public class UpcitemdbService: IUpcitemdbService
    {
        private readonly string baseUrl = "https://www.upcitemdb.com/";
        public async Task<Product> Get(string barcode)
        {
            var cookieContainer = new CookieContainer();
            using HttpClient httpClient = new HttpClient(new HttpClientHandler()
            {
                CookieContainer = cookieContainer
            });
            var user_key = "only_for_dev_or_pro";

            var client = new RestClient("https://api.upcitemdb.com/prod/trial/");
            // lookup request with GET
            var request = new RestRequest("lookup", Method.Get);
            //request.AddHeader("key_type", "3scale");
            //request.AddHeader("user_key", user_key);

            request.AddQueryParameter("upc", barcode);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine("response: " + response.Content);
            // parsing json
            var obj = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);
            Console.WriteLine("offset: " + obj.offset);


            return new Product { Name = obj.items.FirstOrDefault()?.title ?? "None" 
                                 , Price = obj.items.FirstOrDefault()?.highest_recorded_price ?? 0};
        }
    }
}
