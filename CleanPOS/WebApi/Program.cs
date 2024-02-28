using WebApi;
using WebApi.Extensions;
using Infrastructure;
using Application;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
