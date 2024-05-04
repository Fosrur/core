using core.Extensions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServiceExtensions(builder.Configuration, builder.Environment);

var app = builder.Build();
app.AddCoreBuilderExtensions(app.Environment);
app.Run();