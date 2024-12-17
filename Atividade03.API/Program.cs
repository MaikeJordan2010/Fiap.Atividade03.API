using API.Aplicacao._Contato.Comandos;
using API.Aplicacao._Contato.Consultas;
using API.Aplicacao._Services;
using API.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddInfraestrutura();

builder.Services.AddScoped<IContatoComandos, ContatoComandos>();
builder.Services.AddScoped<IContatoConsultas, ContatoConsultas>();
builder.Services.AddScoped<IMessageBroker, MessageBroker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
