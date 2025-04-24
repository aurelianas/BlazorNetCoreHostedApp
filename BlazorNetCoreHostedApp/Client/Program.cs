using BlazorNetCoreHostedApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient("BlazorNetCoreHostedApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient("BlazorNetCoreHostedApp.ServerAPI", client =>
{
#if DEBUG
	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
#else
    client.BaseAddress = new Uri("https://kind-rock-0b7318210.6.azurestaticapps.net/");
#endif
});

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorNetCoreHostedApp.ServerAPI"));

await builder.Build().RunAsync();
