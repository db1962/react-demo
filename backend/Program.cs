using backend.Model;

var AllowSpecificOrigins = "_AllowBackendSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFacilityActions, FacilityActions>();
builder.Services.AddSingleton<IProposalActions, ProposalActions>();
builder.Services.AddSingleton<IConfiguration>(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
