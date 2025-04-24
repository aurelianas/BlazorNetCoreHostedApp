using BlazorNetCoreHostedApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNetCoreHostedApp.Server.Controllers;

[ApiController]
public class ProductController : Controller
{
	private readonly List<Product> ProductList = new()
	{
		new() 
		{
			Id = 1,
			Name = "Product 1",
			Description = "Description for Product 1",
			ImagePath = "images/product1.jpg",
			Price = 10.99m
		},
		new()
		{
			Id = 2,
			Name = "Product 2",
			Description = "Description for Product 1",
			ImagePath = "images/product2.jpg",
			Price = 200m
		},
		new()
		{
			Id = 3,
			Name = "Product 3",
			Description = "Description for Product 3",
			ImagePath = "images/product3.jpg",
			Price = 33.33m
		}
	};

	[HttpGet]
	[Route("/api/products")]
	public IActionResult GetAll()
	{
		return Ok(ProductList);
	}
}