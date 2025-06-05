var builder = WebApplication.CreateBuilder(args);

builder.AddRedisOutputCache("cache");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddNwsManager();

builder.Services.AddOpenTelemetry()
		.WithMetrics(m => m.AddMeter("NwsManagerMetrics"))
		.WithTracing(m => m.AddSource("NwsManager"));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

}

app.UseHttpsRedirection();

// Map the endpoints for the API
app.MapApiEndpoints();

app.Run();
