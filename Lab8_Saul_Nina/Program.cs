using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<Lab8_Saul_Nina.Models.Linqexample2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Lab8_Saul_Nina.Repositories.Interfaces.IUnitOfWork,
    Lab8_Saul_Nina.Repositories.UnitOfWork>();
builder.Services.AddScoped<Lab8_Saul_Nina.Services.Interfaces.IClientService,
        Lab8_Saul_Nina.Services.ClientService>();
builder.Services.AddOpenApi();
builder.Services.AddScoped<Lab8_Saul_Nina.Services.Interfaces.IProductService,
    Lab8_Saul_Nina.Services.ProductService>();
builder.Services.AddOpenApi();
//Agregar Servicios de Swagger
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

app.Run();