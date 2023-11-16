using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

const string DictionaryHttpClientName = "dictionary";

var builder = WebApplication.CreateBuilder(args);

_ = builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddOutputCache()
    .AddHttpClient(DictionaryHttpClientName, config =>
    {
        config.BaseAddress = new("https://api.dictionaryapi.dev");
    })
    .Services;

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI()
   .UseHttpsRedirection()
   .UseResponseCaching();

app.MapGet("/dictionary/{word}", static async ([FromQuery] string word, [FromServices] IHttpClientFactory httpClients, CancellationToken cancel) =>
{
    var start = Stopwatch.GetTimestamp();
    var dictionaryClient = httpClients.CreateClient(DictionaryHttpClientName);

    var response = await dictionaryClient.GetAsync($"api/v2/entries/en/{word}", cancel);
    var content = await response.Content.ReadFromJsonAsync<object>(Json.Options, cancel);

    var end = Stopwatch.GetTimestamp();

    return Results.Ok(new { Latency = $"{TimeSpan.FromTicks(end - start).Milliseconds} ms", Content = content });
})
.WithName("Dictionary")
.CacheOutput(policy =>
{
    policy.Expire(TimeSpan.FromSeconds(2));
});

app.Run();

static class Json
{
    public static JsonSerializerOptions Options = new() { WriteIndented = true };
}