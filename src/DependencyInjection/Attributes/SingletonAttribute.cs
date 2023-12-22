﻿using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class SingletonAttribute : ServiceAttribute
{
    public SingletonAttribute(Type? serviceType = null)
    {
        ServiceType = serviceType;
    }

    /// <summary>
    /// The type of the service to be registered under. If null, the service will be registered as the type this attribute is
    /// above.
    /// </summary>
    public Type? ServiceType { get; }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddSingleton(ServiceType ?? targetType, targetType);
    }
}