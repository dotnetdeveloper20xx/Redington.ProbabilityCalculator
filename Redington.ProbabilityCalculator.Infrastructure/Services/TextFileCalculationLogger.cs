using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Interfaces;
using System.Globalization;

namespace Redington.ProbabilityCalculator.Infrastructure.Services;

public class TextFileCalculationLogger : ICalculationLogger
{
    private const string LogFilePath = "Logs/calculations.txt";

    public async Task LogAsync(ProbabilityRequestDto request, double result)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath)!);

        var logLine = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}] " +
                      $"{request.CalculationType}: Inputs({request.ProbabilityA}, {request.ProbabilityB}) => Result: {result}";

        await File.AppendAllTextAsync(LogFilePath, logLine + Environment.NewLine);
    }
}
