using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Helpers;
using RecruitmentProcessManagementSystem.Repositories;
using RecruitmentProcessManagementSystem.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllers()
.AddJsonOptions(options =>
    {
       
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    })
     .AddNewtonsoftJson(options =>
{
     options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Configure EF Core to use SQL Server Express
builder.Services.AddDbContext<RecruitmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie(options=>{
    options.Cookie.Name="token";
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
    options.Events=new JwtBearerEvents{
        OnMessageReceived=context=>{
            context.Token=context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };
});

// Register the JWT service
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<CandidateService>();
builder.Services.AddScoped<PositionService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IInterviewRepository,InterviewRepository>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<ICandidateStatusRepository, CandidateStatusRepository>();
builder.Services.AddScoped<CandidateStatusService> ();
builder.Services.AddScoped<InterviewFeedbackService>();
builder.Services.AddScoped<IInterviewFeedbackRepository, InterviewFeedbackRepository>();
builder.Services.AddScoped<CandidateSkillService>();
builder.Services.AddScoped<PositionCandidateService>();
builder.Services.AddScoped<ShortlistCandidateService> ();
builder.Services.AddScoped<IShortlistCandidateRepository, ShortlistCandidateRepository>();
// builder.Services.AddScoped<JobRequirementService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<InterviewService>();
builder.Services.AddScoped<IPositionCandidateRepository, PositionCandidateRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateSkillRepository, CandidateSkillRepository>();
// builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<RoleService>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RecruiterPolicy", policy => 
        policy.RequireRole("Recruiter"));
    options.AddPolicy("HRPolicy", policy => 
        policy.RequireRole("HR"));
     options.AddPolicy("ReviewerPolicy", policy => 
        policy.RequireRole("Reviewer"));
    options.AddPolicy("InterviewerPolicy", policy => 
        policy.RequireRole("Interviewer"));
    options.AddPolicy("RecruiterHRPolicy", policy => 
        policy.RequireRole("Recruiter", "HR"));
    options.AddPolicy("RecruiterInterviewerPolicy", policy => 
        policy.RequireRole("Recruiter", "Interviewer"));
    options.AddPolicy("RecruiterReviewerPolicy", policy => 
        policy.RequireRole("Recruiter", "Reviewer"));
    options.AddPolicy("RecruiterCandidatePolicy", policy => 
        policy.RequireRole("Recruiter", "Candidate"));
    options.AddPolicy("RecruiterReviewerHRPolicy", policy => 
        policy.RequireRole("Recruiter", "Reviewer", "HR"));
    // Add other role policies similarly
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        }
    ); 
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();