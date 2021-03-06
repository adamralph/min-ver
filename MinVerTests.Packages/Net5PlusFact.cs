using System;
using MinVerTests.Infra;
using Xunit;

namespace MinVerTests.Packages
{
    public sealed class Net5PlusFact : FactAttribute
    {
        public override string Skip
        {
            get => base.Skip ??
                (
                    (
                        Sdk.Version != null &&
                        (
                            Sdk.Version.StartsWith("2.", StringComparison.Ordinal) ||
                            Sdk.Version.StartsWith("3.", StringComparison.Ordinal)
                        )
                    )
                    ? "Not .NET 5 or later"
                    : null
                );

            set => base.Skip = value;
        }
    }
}
