using MyWeatherHub;
using MyWeatherHub.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHttpClient<NwsManager>(client =>
{
	client.BaseAddress = new("https+http://api");
});

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

builder.Services.AddMemoryCache();

builder.AddNpgsqlDbContext<MyWeatherContext>(connectionName: "weatherdb");

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
else
{
	using var scope = app.Services.CreateScope();
	var context = scope.ServiceProvider.GetRequiredService<MyWeatherContext>();
	await context.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

app.Run();