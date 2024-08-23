
using API.Models;
using API.Repo;
using System;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<ExamDistributionTestContext>();

			builder.Services.AddScoped<IStaffRepo, StaffRepo>();
			builder.Services.AddScoped<IMajorFacilityRepo, MajorFacilityRepo>();
            builder.Services.AddScoped<IFacilityRepo, FacilityRepo>();
            builder.Services.AddScoped<IMajorRepo, MajorRepo>();
            var app = builder.Build();

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
		}
	}
}
