using Hangfire;
using Hangfire.MemoryStorage;
using hangfire_dotnet_sample.Domain.Interfaces;
using hangfire_dotnet_sample.Integration;
using hangfire_dotnet_sample.Jobs;
using hangfire_dotnet_sample.Queues;
using HangfireBasicAuthenticationFilter;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INICIO DA CONFIGUR��O NO SERVICE  - HANGFIRE
builder.Services.AddHangfire(config => config.UseMemoryStorage());
// FIM DA CONFIGURA��O  NO SERVICE - HANGFIRE

//Configura��o da Inje��o de depend�ncia de Jobs, Queues e Integrations 
builder.Services.AddScoped<IInvestmentProductIntegration, InvestmentProductIntegration>();
builder.Services.AddScoped<IFixedIncomeQueue, FixedIncomeQueue>();
builder.Services.AddScoped<IEquityQueue, EquityQueue>();
builder.Services.AddScoped<IFundQueue, FundQueue>();
builder.Services.AddScoped<IProductsJob, ProductsJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();


// INICIO DA CONFIGUR��O NO APP  - HANGFIRE
app.UseHangfireServer();

//Basic Authentication added to access the hangfire dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangifire Dashboard Sample",
    Authorization = new[]{
                new HangfireCustomBasicAuthenticationFilter{
                    User = "hangfireUser",
                    Pass = "hangfirePassword"
                }
            },

});
// FIM DA CONFIGURA��O  NO APP - HANGFIRE


// EXECU��O DO JOB - INICIO 
var productsJob = builder.Services.BuildServiceProvider().GetService<IProductsJob>();

RecurringJob.AddOrUpdate(
    () => productsJob.StartJob(),
    Cron.Daily,
    TimeZoneInfo.Utc);

// EXECU��O DO JOB - FIM 

app.MapControllers();
app.Run();
