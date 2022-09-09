using ACS.AppDBContext;
using ACS.Data;
using ACS.Helpers;
using ACS.Mapper;
using ACS.Services;
using ACS.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IPartyService, PartyService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IInventoryNoteService, InventoryNoteService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ILedgerService, LedgerService>();
builder.Services.AddScoped<IPartyLedgerService, PartyLedgerService>();
builder.Services.AddScoped<IRoomAllotmentService, RoomAllotmentService>();
builder.Services.AddScoped<IShipmentDetailsService, ShipmentDetailsService>();
builder.Services.AddScoped<IStockOutService, StockOutService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeAttendenceService, EmployeeAttendenceService>();
builder.Services.AddScoped<IAdvanceSalaryService, AdvanceSalaryService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();
builder.Services.AddScoped<IStockOutBillService, StockOutBillService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IDataService, DataService>();



builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<NotificationHelper>();

builder.Services.AddScoped<UserLoginService>();
builder.Services.AddScoped<GoodsReceivedService>();
builder.Services.AddScoped<EmployeeManagerService>();
builder.Services.AddScoped<StockOutManagerService>();
builder.Services.AddScoped<ShipmentDetailsManagerService>();
builder.Services.AddScoped<RoomAllotmentManagerService>();
builder.Services.AddScoped<EmployeeAttendanceManageService>();
builder.Services.AddScoped<AdvanceSalaryManagerService>();
builder.Services.AddScoped<PartyManagerService>();
builder.Services.AddScoped<SizeManagerService>();
builder.Services.AddScoped<ItemManagerService>();
builder.Services.AddScoped<CategoryManagerService>();
builder.Services.AddScoped<TransactionManagerService>();
builder.Services.AddScoped<InventoryManagerService>();
builder.Services.AddScoped<NotesManagerService>();
builder.Services.AddScoped<DashBoardDataServices>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AddProfile(new MappingProfile());
});



builder.Services.AddSingleton(config.CreateMapper());

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

//app.MapBlazorHub();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapBlazorHub();
});
app.MapFallbackToPage("/_Host");

app.Run();
