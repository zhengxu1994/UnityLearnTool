using System;
using System.Text;
using UnityEngine;
internal static class LogTool
{
    public enum LogLevel
    {
        Log = 0,
        Warning = 1,
        Error = 2
    }

    public static bool LOG_SWITCH = true;
    public static LogLevel DisplayLevel = LogLevel.Log;

    private const string LOG_COLOR = "white";
    private const string WARNING_COLOR = "orange";
    private const string ERROR_COLOR = "red";

    public  static StringBuilder builder = new StringBuilder();

    private static void LogDeal(string log,LogLevel level)
    {
        if (!LOG_SWITCH) return;
        string color = LOG_COLOR;
        if (level.Equals(LogLevel.Log)) {
            if (DisplayLevel > LogLevel.Log) return;
        }
        else if(level.Equals(LogLevel.Warning))
        {
            if (DisplayLevel > LogLevel.Warning) return;
            color = WARNING_COLOR;
        }
        else if (level.Equals(LogLevel.Error))
        {
            color = ERROR_COLOR;
        }

        string time = "Time :" + System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
        builder.Clear();
        builder.AppendFormat("<color=[0]>[{1}][{2}]</color>", color, time, log);
        if (level.Equals(LogLevel.Error))
            Debug.LogError(builder);
        else
            Debug.Log(builder);
    } 

    public static void Log(string log)
    {
        LogDeal(log, LogLevel.Log);
    }

    public static void Log(string format,params object[] args)
    {
        string log = string.Format(format, args);
        LogDeal(log, LogLevel.Log);
    }

    public static void LogWarning(string log)
    {
        LogDeal(log, LogLevel.Warning);
    }

    public static void LogWarning(string format,params object[] args)
    {
        string log = string.Format(format, args);
        LogDeal(log, LogLevel.Warning);
    }

    public static void LogError(string log)
    {
        LogDeal(log, LogLevel.Error);
    }

    public static void LogError(string format, params object[] args)
    {
        string log = string.Format(format, args);
        LogDeal(log, LogLevel.Error);
    }
}
