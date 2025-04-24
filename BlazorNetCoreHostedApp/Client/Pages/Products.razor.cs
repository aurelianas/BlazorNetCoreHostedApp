using BlazorNetCoreHostedApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorNetCoreHostedApp.Client.Pages;

public partial class Products
{
	[Inject] private IHttpClientFactory HttpClientFactory { get; set; } = default!;

	[Inject] private HttpClient HttpClient { get; set; }

	//[Inject] private NavigationManager NavigationManager { get; set; }

	private List<Product>? ProductList { get; set; } = new();

	protected override async Task OnInitializedAsync()
	{
		//ProductList = await HttpClient.GetFromJsonAsync<List<Product>>("sample-data/product.json");
		//var baseUri = NavigationManager.BaseUri;
		var http = HttpClientFactory.CreateClient("BlazorNetCoreHostedApp.ServerAPI");
		ProductList = await http.GetFromJsonAsync<List<Product>>($"api/products");
	}
}