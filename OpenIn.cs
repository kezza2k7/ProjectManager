using System.Diagnostics;

namespace ProjectsManager;

public class OpenIn
{
    public static void VSCode(string relativePath)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(basePath, relativePath);

        Console.WriteLine($"Opening {basePath} in VS Code...");
        Console.WriteLine($"Opening {fullPath} in VS Code...");
        Process.Start(new ProcessStartInfo
        {
            FileName = "code",
            Arguments = $"\"{fullPath}\"",
            UseShellExecute = true
        });
    }

    public static void IntelliJ(string relativePath)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(basePath, relativePath);
        
        Console.WriteLine($"Opening {basePath} in InteliJ...");
        Console.WriteLine($"Opening {fullPath} in InteliJ...");

        Process.Start(new ProcessStartInfo
        {
            FileName = "D:\\IntelliJ IDEA 2023.3.4\\bin\\idea.bat",
            Arguments = $"\"{fullPath}\"",
            UseShellExecute = true
        });
    }
}