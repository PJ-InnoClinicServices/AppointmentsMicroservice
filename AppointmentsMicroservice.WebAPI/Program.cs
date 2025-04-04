using BusinessLogicLayer.AppExtensions;
using PresentationLayer.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddFluentValidation();
new ConfigureGraphQl(builder.Configuration).Configure(builder.Services);
builder.Services.AddMassTransitServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    ConfigureGraphQl.ApplyMigrations(app.Services);
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();