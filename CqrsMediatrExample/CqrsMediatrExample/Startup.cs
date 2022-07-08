using CqrsMediatrExample.Behaviors;
using CqrsMediatrExample.DataStore;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CqrsMediatrExample
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMediatR(typeof(Startup));
			services.AddSingleton<FakeDataStore>();
			services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

			services.AddControllers();

			services.AddControllers()
				.AddFluentValidation(s => 
				{ 
					s.RegisterValidatorsFromAssemblyContaining<Startup>();
				});

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
