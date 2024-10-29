using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.Services.Interfaces;
using BusinessServices.Services.Repoistory;
using DataLayer.Data;
using DataLayer.RepositoryAction;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//toastar
builder.Services.AddMvc().AddNToastNotifyToastr(new NToastNotify.ToastrOptions
{
    PositionClass = ToastPositions.TopRight,
    ProgressBar = true,
    PreventDuplicates = true,
    CloseButton = true
});

//add session
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//add db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
));

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IRetailerService, RetailerService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IBankProductservice, BankProductservice>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ICustomerDealService, CustomerDealService>();
builder.Services.AddTransient<ICustomerDetailsService, CustomerDetailsService>();
builder.Services.AddTransient<ICustomerSearchService, CustomerSearchService>();
builder.Services.AddTransient<ICustomerIdNumberService, CustomerIdNumberService>();
builder.Services.AddTransient<ICustomerAdditinalService, CustomerAdditinalService>();
builder.Services.AddTransient<IForgetPasswordService, ForgetPasswordService>();
builder.Services.AddTransient<IChangedPasswordService, ChangedPasswordService>();
builder.Services.AddTransient<IMobileExisService, MobileExisService>();
builder.Services.AddTransient<ICheckPinService, CheckPinService>();
builder.Services.AddTransient<IRefreshService, RefreshService>();
builder.Services.AddTransient<ILogoutService, LogoutService>(); 
builder.Services.AddTransient(typeof(IVerifyAction<>), typeof(VerifyAction<>)); 
builder.Services.AddTransient(typeof(IProjectOperation<>), typeof(ProjectOperation<>));
builder.Services.AddTransient(typeof(IProjectActionOperation<>), typeof(ProjectActionOperation<>));
builder.Services.AddTransient(typeof(IProjectActionParameterOperation<>), typeof(ProjectActionParameterOperation<>));
builder.Services.AddTransient(typeof(IActionParameterType<>), typeof(ActionParameterType<>));

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

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
