using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;
using Furnivault.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the repository and pass the connection string to its constructor.
builder.Services.AddScoped<IRepository<Item>, ItemRepository>();

// Register the service.
builder.Services.AddScoped<ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
