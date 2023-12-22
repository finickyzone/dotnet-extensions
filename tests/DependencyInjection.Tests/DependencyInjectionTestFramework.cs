using FluentAssertions;
using JetBrains.Annotations;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Finickyzone.Extensions.DependencyInjection;

[UsedImplicitly]
public sealed class DependencyInjectionTestFramework : XunitTestFramework
{
    public DependencyInjectionTestFramework(IMessageSink messageSink)
        : base(messageSink)
    {
        AssertionOptions.AssertEquivalencyUsing(options => options.Using(ServiceDescriptorEquivalency.Instance));
    }
}