using Compras.Aplication;
using Compras.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

#region InjectionDependecy
builder.Services.AddInfraestructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
