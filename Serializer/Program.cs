using FluentValidation;
using FluentValidation.AspNetCore;
using Serializer.Middlewares;
using Serializer.Services.Abstractions;
using Serializer.Services.Implementations;
using Serializer.Validators.PersonDtoValidators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<PersonPostDtoValidator>());


builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<PersonPostDtoValidator>();


builder.Services.AddScoped(typeof(ISerializeService<>), typeof(JsonSerializerService<>));

builder.Services.AddScoped<IPersonService,PersonService>();

var app = builder.Build();


app.AddExceptionHandlerService();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
