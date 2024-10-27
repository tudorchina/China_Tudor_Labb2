using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using China_Tudor_Labb2.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<China_Tudor_Labb2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("China_Tudor_Labb2Context") ?? throw new InvalidOperationException("Connection string 'China_Tudor_Labb2Context' not found.")));

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
