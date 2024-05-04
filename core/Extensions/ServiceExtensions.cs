using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using core.Models;
using System.Text;


namespace core.Extensions
{
	/// <summary>
	/// Definition of ServiceExtensions
	/// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Definition of AddPersistenceServiceExtensions
        /// </summary>
        public static IServiceCollection AddPersistenceServiceExtensions(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddCors();

            var envSettingsPath = Path.Combine(environment.ContentRootPath, "envsettings.json");
            Dictionary<string, string> envSettings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(envSettingsPath))!;
            string environmentValue = envSettings.GetValueOrDefault("ASPNETCORE_ENVIRONMENT")!;
            environment.EnvironmentName = environmentValue;
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            configuration = builder.Build();
            services.Configure<SQLConfig>(configuration.GetSection("SQLConfig"));
            services.Configure<DBType>(configuration.GetSection("DBType"));
            services.AddControllers();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference =  new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Core",
                    Description = "Ogni metodo richiede come input un utente, ad esempio: <b>example@example.com</b>. Al momento, non è presente alcun tipo di controllo, quindi è possibile inserire qualsiasi cosa"
                });
                options.IncludeXmlComments(string.Format(@"{0}swaggerdoc.xml", AppDomain.CurrentDomain.BaseDirectory));
            });
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings?.Secret!);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddOptions();

            return services;
        }
    }
}
