namespace YoutubeCategorizer.Core.Services;

using System.Diagnostics;

public class YoutubePlaywrighService
{
    public async Task<List<string>> Search(string query)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "node",
            Arguments = $"Playwright/scraper.js {query}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = Process.Start(psi);

        string output = await process.StandardOutput.ReadToEndAsync();
        process.WaitForExit();

        return System.Text.Json.JsonSerializer
            .Deserialize<List<string>>(output) ?? new List<string>();
    }
}