﻿using ClothingStore.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace ClothingStore.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
