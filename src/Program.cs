using Demo.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
       .AddControllers();

builder.Services
       .AddEndpointsApiExplorer()
       .AddSwaggerGen();

builder.Services
       .AddDbContext<DatabaseContext>();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI();

app.MapControllers();

app.Run();
