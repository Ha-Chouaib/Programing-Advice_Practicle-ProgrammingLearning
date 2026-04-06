using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using StudentApi.Authorization;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("StudentApiCorsPolicy", policy =>
    {
        policy.WithOrigins
        ("https://localhost:7217",
        "http://localhost:5215").AllowAnyHeader().AllowAnyMethod(); ;
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
    (
        options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,//Ensures that the token was issued by a trusted authority.
                ValidateAudience = true,//Ensures that the token was issued by a trusted authority and is intended for the correct audience.
                ValidateLifetime = true,//Ensures that the token has not expired and is still valid.
                ValidateIssuerSigningKey = true,//Ensures that the token's signature is valid and has not been tampered with.

                ValidIssuer = "StudentApi",//The expected issuer of the token, which should match the issuer specified when the token was created.
                ValidAudience = "StudentApiUsers",//The expected audience of the token, which should match the audience specified when the token was created.

                //The key used to validate the token's signature, which should match the key used to sign the token.
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456")),
                
                ClockSkew = TimeSpan.Zero //here we set the clock skew to zero to prevent any additional time window for token expiration,
                                          //ensuring that tokens expire exactly at their specified expiration time without any grace period.
                                          //This enhances security by reducing the risk of token misuse after expiration.
            };
        }
    );

builder.Services.AddSingleton<IAuthorizationHandler, StudentOwnerOrAdminHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StudentOwnerOrAdmin", policy =>
    {
        policy.Requirements.Add(new StudentOwnerOrAdminRequirement());
    });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddPolicy("AuthLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(partitionKey: ip,
            factory: partition => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 5,
            Window = TimeSpan.FromMinutes(1),
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            QueueLimit = 0
        });
    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // ===============================
    // 1) Define the JWT Bearer security scheme
    // ===============================
    //
    // This tells Swagger that our API uses JWT Bearer authentication
    // through the HTTP Authorization header.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // The name of the HTTP header where the token will be sent.
        Name = "Authorization",


        // Indicates this is an HTTP authentication scheme.
        Type = SecuritySchemeType.Http,


        // Specifies the authentication scheme name.
        // Must be exactly "Bearer" for JWT Bearer tokens.
        Scheme = "Bearer",


        // Optional metadata to describe the token format.
        BearerFormat = "JWT",


        // Specifies that the token is sent in the request header.
        In = ParameterLocation.Header,


        // Text shown in Swagger UI to guide the user.
        Description = "Enter: Bearer {your JWT token}"
    });


    // ===============================
    // 2) Require the Bearer scheme for secured endpoints
    // ===============================
    //
    // This tells Swagger that endpoints protected by [Authorize]
    // require the Bearer token defined above.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // Reference the previously defined "Bearer" security scheme.
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },


            // No scopes are required for JWT Bearer authentication.
            // This array is empty because JWT does not use OAuth scopes here.
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();//This middleware redirects HTTP requests to HTTPS, ensuring that all communication with the API is encrypted and secure.
                          //It helps protect sensitive data from being transmitted over unencrypted connections, enhancing the overall security of the application.

app.UseCors("StudentApiCorsPolicy");//This middleware enables Cross-Origin Resource Sharing (CORS) for the API, allowing it to accept requests from specified origins (e.g., frontend applications running on different domains). 
                                    //By defining a CORS policy, we can control which external domains are allowed to access the API, enhancing security while enabling necessary cross-origin interactions.

app.UseRateLimiter();//This middleware applies rate limiting to incoming requests, helping to prevent abuse and protect the API from excessive traffic. 
                     //By configuring rate limits, we can mitigate the risk of denial-of-service (DoS) attacks and ensure that the API remains responsive and available to legitimate users.
app.Use(async (context, next) =>
{
   await next();
    if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
        var path = context.Request.Path.ToString();

        app.Logger.LogWarning("Rate limit exceeded for user: {UserId}, IP: {IP}, Path: {Path}", userId ?? "Anonymous", ip, path);
        await context.Response.WriteAsync("Too many requests. Please try again later.");
    }
    if(context.Response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
        var path = context.Request.Path.ToString();
        app.Logger.LogWarning("Unauthorized access attempt from IP: {IP}, Path: {Path}", ip, path);
        await context.Response.WriteAsync("Unauthorized. Please provide valid credentials.");
    }
    if(context.Response.StatusCode == StatusCodes.Status403Forbidden)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
        var path = context.Request.Path.ToString();
        app.Logger.LogWarning("Forbidden access attempt by user: {UserId}, IP: {IP}, Path: {Path}", userId ?? "Anonymous", ip, path);
        await context.Response.WriteAsync("Forbidden. You do not have permission to access this resource.");
    }
});

app.UseAuthentication();//This middleware enables authentication for the API, allowing it to validate and process authentication tokens (e.g., JWTs) included in incoming requests. 
                        //By using authentication, we can ensure that only authorized users can access protected endpoints, enhancing the security of the application by preventing unauthorized access.

app.UseAuthorization();//This middleware enables authorization for the API, allowing it to enforce access control policies based on user roles and permissions. 
                       //By using authorization, we can restrict access to certain endpoints or resources to specific users or groups, enhancing security by ensuring that users can only perform actions they are authorized for.

app.MapControllers();//This middleware maps incoming HTTP requests to the appropriate controller actions based on the defined routes. 
                     //By using MapControllers, we can organize our API endpoints into controllers and handle requests in a structured manner, improving maintainability and scalability of the application.

app.Run();
