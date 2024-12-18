var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//COLOCAR ANTES DE HACER EL RUN DEL APP
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin() // Reemplaza con el dominio de tu sitio web
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();


app.Run();

//FALTA FILTRO OPCIONAL EN GET DE CLIENTES.
//EL FORMULARIO NO FUNCIONA, TIENE PINTA DE SER UN ERROR POR COPY&PASTE (FALTO AJUSTAR NOMBRES Y AJUSTAR JS)
//EL OTRO FORMULARIO DA 400 AL ENVIAR A LA API. NO FUNCIONA.

//LA NOTA DEL RECUPERATORIO ES DE 70%. APROBADO