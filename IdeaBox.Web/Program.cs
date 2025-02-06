using IdeaBox.Data.Models;
using IdeaBox.Storage;
using IdeaBox.Storage.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Storage
// Change path for localstorage
builder.Services.AddSingleton<IStorage<Idea>, LocalStorage<Idea>>(_ => new LocalStorage<Idea>(@"D:\IdeaBoxData"));
//builder.Services.AddSingleton<IStorage<Idea>, MemoryStorage<Idea>>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
