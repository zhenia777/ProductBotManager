using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.BarcodeServices.BarcodeLookupService;

public class BarcodeLookupService : IBarcodeLookupService
{
    //7350080718740
    private readonly string baseUrl = "https://www.barcodelookup.com/";
    public async Task<Product> Get(string barcode)
    {
        var cookieContainer = new CookieContainer();
        using HttpClient httpClient = new HttpClient(new HttpClientHandler()
        {
            CookieContainer = cookieContainer
        });

        cookieContainer.Add(new Cookie("cf_clearance", "667ISQW_g1YU8STCIaAhUU99dG7dMtagVNffCEloKN8-1702395632-0-1-7c3054b2.3e1d2dff.66da7a02-0.2.1702395632", "/", ".barcodelookup.com"));

        cookieContainer.Add(new Cookie("_ga_6K9HJQ9YDK", "GS1.1.1702395630.4.1.1702395631.0.0.0", "/", ".barcodelookup.com"));

        cookieContainer.Add(new Cookie("bl_csrf", "a46546637a0fb86a89fb8688d9f29939", "/", ".barcodelookup.com"));

        cookieContainer.Add(new Cookie("__cflb", "04dToRCegghj9KSg7BqsUc4efEezbNiXZiikXHLj6D", "/", "www.barcodelookup.com"));

        cookieContainer.Add(new Cookie("bl_session", "pefgd8io77qu0jdnp38ml6lcp4clmu62", "/", ".barcodelookup.com"));

        cookieContainer.Add(new Cookie("_ga", "GA1.1.1232143010.1702381811", "/", ".barcodelookup.com"));

        cookieContainer.Add(new Cookie("__cf_bm", "eAdLAenOf_wUMxkMCAAEzGqHotu1TZyFKMDX.CG0exw-1702395630-1-AQ7KPIo69URV9PQ6IrsrWj4rJrb9AyXEhUS/8zIsRNBLknbGPCE5vTgyDgGUmpT8sPG530aEjk7Ve/kSDdJiK9t0gIVpYqEXwL8jf+m2OkYt", "/", ".barcodelookup.com"));




        //var response = await httpClient.GetAsync(baseUrl + barcode);

        //response.StatusCode == 200

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUrl + barcode);
        request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        request.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru-RU;q=0.8,ru;q=0.7,uk;q=0.6");
        request.Headers.Add("Cache-Control", "no-cache");
        //request.Headers.Add("Cookie", "bl_csrf=a46546637a0fb86a89fb8688d9f29939; _ga=GA1.1.1232143010.1702381811; bl_session=e37atdo2a90i6hgafhgukuqqptdg1ju6; __cf_bm=n4H76EYrOGoT9hxOfErysaKXrAMROnJyheOxRM5xA3k-1702392743-1-AefnAonQCftmuB8pKmj5gwd8SwaSOPMo6Kf29uK79Vvd6JpUObWFltTdAdnB7O1+eeTUYu80iNLcHlvn/WoHJeS3LQSFaxpUi/6iZ8qrCMp0; __cflb=04dToRCegghj9KSg7BqsUc4efEezbNiKvecDPeJp6R; cf_clearance=qHwctngBGzM7KQB2Ry4nA4ckI.lbPuxCBM4qqM7vfZk-1702392745-0-1-7c3054b2.3e1d2dff.66da7a02-0.2.1702392745; _ga_6K9HJQ9YDK=GS1.1.1702392744.3.1.1702392761.0.0.0");
        request.Headers.Add("Pragma", "no-cache");
        request.Headers.Add("Sec-Ch-Ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\"");
        request.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
        request.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
        request.Headers.Add("Sec-Fetch-Dest", "document");
        request.Headers.Add("Sec-Fetch-Mode", "navigate");
        request.Headers.Add("Sec-Fetch-Site", "none");
        request.Headers.Add("Sec-Fetch-User", "?1");
        request.Headers.Add("Upgrade-Insecure-Requests", "1");
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");



        var response = await httpClient.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(content);
        File.WriteAllText("data.html", content);
        File.WriteAllText("test.html", "hello");
        int index = content.IndexOf("edit-product-btn");
        int indexStart = content.IndexOf("h4", index);
        int indexEnd = content.IndexOf("h4", indexStart+1);
        Debug.WriteLine(indexStart);
        Debug.WriteLine(content.Substring(indexStart, 20));
        string name = content.Substring(indexStart+3, indexEnd - indexStart-3-3)
                             .Trim(' ', '\n', '\r');
        Debug.WriteLine(name);
        return new Product() {Name = name };
    }
}
