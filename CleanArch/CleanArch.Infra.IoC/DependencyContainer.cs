using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandlers;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Bus;
using CleanArch.Infra.Data;
using CleanArch.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain InMemoryBus MediatR

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handler

            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();
            
            // Application Layer
            services.AddScoped<ICourseService, CourseService>();


            // Infra.Data Layer
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<UniversityDBContext>();

        }
    }
}
