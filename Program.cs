using Microsoft.EntityFrameworkCore;
using RazorPage.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazDbContext>(options =>
    options.UseSqlite("Data Source=emp_37.db"));

// If you're using authentication or other services, add them here, before builder.Build().

// Build the application.
var app = builder.Build();

// Configure middleware and request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
