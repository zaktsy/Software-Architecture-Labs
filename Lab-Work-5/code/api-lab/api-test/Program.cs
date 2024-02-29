using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

var httpClient = new HttpClient();

await Test_CreateEvent(httpClient);
await Test_GetEvents(httpClient);
return;

async Task Test_CreateEvent(HttpClient httpClient1)
{
    using var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/events?eventName=njdcnscidncsd");
    var ticketAdditionResult = await httpClient1.SendAsync(request);

    if (ticketAdditionResult.StatusCode != HttpStatusCode.OK)
    {
        Console.WriteLine("Error in test 1");
        Environment.Exit(1);
    }
}

async Task Test_GetEvents(HttpClient httpClient1)
{
    using var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/events");
    var ticketAdditionResult = await httpClient1.SendAsync(request);

    if (ticketAdditionResult.StatusCode != HttpStatusCode.OK)
    {
        Console.WriteLine("Error in test 2");
        Environment.Exit(1);
    }
    
    var responseString = await ticketAdditionResult.Content.ReadAsStringAsync();
    
    if (responseString == string.Empty)
    {
        Console.WriteLine("Error in test 2");
        Environment.Exit(1);
    }
}
