// Import DoctorService
using Doc_Hospital_Appointment_Management_System.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Enable IMemoryCache
builder.Services.AddMemoryCache();

// Register DoctorService with Dependency Injection
builder.Services.AddSingleton<DoctorService>();

// Add memory-based session storage
builder.Services.AddDistributedMemoryCache();

// Configure Session
builder.Services.AddSession(options =>
{
    // Session expires after 30 minutes of inactivity
    options.IdleTimeout =
        TimeSpan.FromMinutes(30);

    // Prevent JavaScript from accessing session cookie
    options.Cookie.HttpOnly = true;

    // Make session cookie essential
    options.Cookie.IsEssential = true;
});

// Enable Response Caching
builder.Services.AddResponseCaching();

// Register HttpClientFactory
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // Enable HSTS in production
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable CSS, JavaScript and other static files
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable Response Caching middleware
app.UseResponseCaching();

// Enable Session middleware
app.UseSession();

// Enable authorization
app.UseAuthorization();

// Configure default MVC route
// Doctor/Index will be the starting page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doctor}/{action=Index}/{id?}");

// Start the application
app.Run();