using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(policy =>
{
	policy.AddPolicy("_myAllowSpecificOrigins", builder =>
	 builder.WithOrigins("https://blazornetcorehostedappserver.azurewebsites.net/")
	  .SetIsOriginAllowed((host) => true) // this for using localhost address
	  .AllowAnyMethod()
	  .AllowAnyHeader()
	  .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
