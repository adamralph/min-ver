using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleExec;

namespace MinVerTests.Infra
{
    public static class MinVerCli
    {
        public static async Task<ReadResult> ReadAsync(string workingDirectory, string configuration = Configuration.Current, params (string, string)[] envVars)
        {
            var environmentVariables = envVars.ToDictionary(envVar => envVar.Item1, envVar => envVar.Item2, StringComparer.OrdinalIgnoreCase);
            _ = environmentVariables.TryAdd("MinVerVerbosity".ToAltCase(), "trace");

            return await CommandEx.ReadLoggedAsync("dotnet", $"exec {GetPath(configuration)}", workingDirectory, environmentVariables).ConfigureAwait(false);
        }

        public static string GetPath(string configuration) =>
            Solution.GetFullPath($"minver-cli/bin/{configuration}/netcoreapp2.1/minver-cli.dll");
    }
}
