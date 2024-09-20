using MarketplaceApp2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MarketplaceApp2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketplaceApp2Context") ?? throw new InvalidOperationException("Connection string 'MarketplaceApp2Context' not found.")));

var app = builder.Build();

// Seed the database.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataSeeder.Seed(services);
}

// Configure the HTTP request pipeline.
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

// Set the default page
app.MapGet("/", context =>
{
    context.Response.Redirect("/Listings");
    return Task.CompletedTask;
});

app.Run();
