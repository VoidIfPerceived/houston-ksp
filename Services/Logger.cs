using System;
using System.IO;
using System.Text;

namespace Houston.Services;

public static class Logger
{
    private static readonly string LogDirectory = GetLogDirectoryPath();

    private static string GetLogDirectoryPath()
    {
        try
        {
            // Get the application base directory (bin/Debug/net10.0 or similar)
            var baseDirectory = AppContext.BaseDirectory;
            System.Diagnostics.Debug.WriteLine($"Application base directory: {baseDirectory}");
            
            // Navigate up to the Houston project root
            // From: /path/to/Houston/bin/Debug/net10.0/
            // To: /path/to/Houston/
            var projectRoot = Path.Combine(baseDirectory, "..", "..", "..");
            projectRoot = Path.GetFullPath(projectRoot);
            
            System.Diagnostics.Debug.WriteLine($"Project root: {projectRoot}");
            
            // Create logs directory in project root
            var logsPath = Path.Combine(projectRoot, "Logs");
            System.Diagnostics.Debug.WriteLine($"Logs path: {logsPath}");
            
            if (!Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(logsPath);
                System.Diagnostics.Debug.WriteLine($"Created logs directory: {logsPath}");
            }
            
            return logsPath;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to determine log directory: {ex.Message}");
            
            // Fallback to a simple Logs folder in the current directory
            var fallbackPath = Path.Combine(AppContext.BaseDirectory, "Logs");
            System.Diagnostics.Debug.WriteLine($"Using fallback logs path: {fallbackPath}");
            return fallbackPath;
        }
    }

    private static string GetLogFilePath()
    {
        return Path.Combine(LogDirectory, $"houston_{DateTime.Now:yyyy-MM-dd}.log");
    }

    public static void Initialize()
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"Logger initializing with directory: {LogDirectory}");
            
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
                System.Diagnostics.Debug.WriteLine($"Created log directory: {LogDirectory}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Log directory already exists: {LogDirectory}");
            }
            
            LogInfo("=== Logger Initialized ===");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to initialize logger: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"Exception type: {ex.GetType().Name}");
            System.Diagnostics.Debug.WriteLine($"LogDirectory = {LogDirectory}");
        }
    }

    public static void Log(string message)
    {
        Log(message, LogLevel.Info);
    }

    public static void Log(string message, LogLevel level)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var logMessage = $"[{timestamp}] [{level}] {message}";

        try
        {
            // Ensure directory exists before writing
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
                System.Diagnostics.Debug.WriteLine($"Created directory: {LogDirectory}");
            }
            
            var logFilePath = GetLogFilePath();
            System.Diagnostics.Debug.WriteLine($"Writing to: {logFilePath}");
            
            // Write to file
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine, Encoding.UTF8);
            
            // Also write to debug output
            System.Diagnostics.Debug.WriteLine(logMessage);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to write to log: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"LogDirectory: {LogDirectory}");
            System.Diagnostics.Debug.WriteLine($"Exception type: {ex.GetType().Name}");
            System.Diagnostics.Debug.WriteLine($"Full Exception: {ex}");
        }
    }

    public static void LogError(string message, Exception ex)
    {
        var errorMessage = ex != null 
            ? $"{message}\nException: {ex.GetType().Name}\nMessage: {ex.Message}\nStackTrace: {ex.StackTrace}"
            : message;
        
        Log(errorMessage, LogLevel.Error);
    }

    public static void LogInfo(string message)
    {
        Log(message, LogLevel.Info);
    }

    public static void LogDebug(string message)
    {
        Log(message, LogLevel.Debug);
    }

    public static void LogWarning(string message)
    {
        Log(message, LogLevel.Warning);
    }

    public static string GetLogDirectory()
    {
        return LogDirectory;
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}
