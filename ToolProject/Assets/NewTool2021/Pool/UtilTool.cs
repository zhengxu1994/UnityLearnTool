using System;
public static class UtilTool
{
    public static readonly string SessionSecrect = "pemelo_session_secret_winddy";

    public static TResult SafeExecute<TResult>(Func<TResult> rFunc)
    {
        if (rFunc == null) return default(TResult);
        return rFunc();
    }
}