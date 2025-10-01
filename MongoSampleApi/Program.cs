using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoSampleApi.Configuration;
using MongoSampleApi.Endpoints;
using MongoSampleApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection(MongoOptions.SectionName));
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var options = sp.GetRequiredService<IOptions<MongoOptions>>().Value;
    return new MongoClient(options.ConnectionString);
});
builder.Services.AddSingleton<TodoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapTodoEndpoints();

app.Run();
