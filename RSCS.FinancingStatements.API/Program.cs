using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using RSCS.FinancingStatements.Core.Services;
using RSCS.FinancingStatements.Data.Persistance.DataAccess;
using RSCS.FinancingStatements.Data.Repository;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using Serilog;
using System.Data;
using System.Security.Claims;
using System.Text;
using Microsoft.Identity.Web;
using RSCS.FinancingStatements.API.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
//Add services to the container.
builder.Services.AddScoped<IDbConnection>((s) => new SqlConnection(builder.Configuration.GetConnectionString("RSCSDatabase")));
builder.Services.AddScoped<IDBTransactionFactory, DBTransactionFactory>();
builder.Services.AddScoped<IDbTransaction>(s =>
{
	IDBTransactionFactory conn = s.GetRequiredService<IDBTransactionFactory>();
	return conn.Get();
});

//Register DAL and Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Register all repositories 
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<IFinProgramsRepository, FinProgramsRepository>();
builder.Services.AddScoped<IFinProgramsFranchiseeRepository, FinProgramsFranchiseeRepository>();
builder.Services.AddScoped<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
builder.Services.AddScoped<IStatementDetailsRepository, StatementDetailsRepository>();
builder.Services.AddScoped<IReferencesRepository, ReferencesRepository>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IResourceSecurityRepository, ResourceSecurityRepository>();

//Register all services
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFinProgramsService, FinProgramsService>();
builder.Services.AddScoped<IFinProgramsFranchiseeService, FinProgramsFranchiseeService>();
builder.Services.AddScoped<IInvoiceDetailsService, InvoiceDetailsService>();
builder.Services.AddScoped<IStatementDetailsService, StatementDetailsService>();
builder.Services.AddScoped<IReferencesService, ReferencesService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IResourceSecurityService, ResourceSecurityService>();
builder.Services.Configure<ApiConstant>(builder.Configuration.GetSection("Roles"));


//Register Serilog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = NegotiateDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddNegotiate()
//.AddJwtBearer(x =>
//{
//	x.SaveToken = true;
//	x.TokenValidationParameters = new TokenValidationParameters
//	{
//		ValidIssuer = builder.Configuration["Jwt:Issuer"],
//		ValidAudience = builder.Configuration["Jwt:Audience"],
//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//		ValidateIssuer = true,
//		ValidateAudience = true,
//		ValidateLifetime = false,
//		ValidateIssuerSigningKey = true
//	};
//});
//var ReadWrite = builder.Configuration.GetValue<string>("Roles:ReadWrite");
builder.Services.AddAuthorization(options =>
{
	// By default, all incoming requests will be authorized according to the default policy.
	options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
			.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
			.RequireClaim(ClaimTypes.Name, "MyApiUser").Build());
	//options.AddPolicy("ReadWrite", policy =>
	//{
	//	policy.RequireRole(builder.Configuration.GetValue<string>("Roles:ReadWrite"));
	//});
	//options.AddPolicy("FullAccess", policy =>
	//{
	//	policy.RequireRole(builder.Configuration.GetValue<string>("Roles:FullAccess"));
	//});
	//options.AddPolicy("ReadOnly", policy =>
	//{
	//	policy.RequireRole(builder.Configuration.GetValue<string>("Roles:ReadOnly"));
	//});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
