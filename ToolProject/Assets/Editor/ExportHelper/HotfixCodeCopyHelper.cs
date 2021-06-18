using System.IO;
using ZFramework;
using UnityEditor;

[InitializeOnLoad]
public static class HotfixCodeCopyHelper
{
    private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
    private const string CodeDir = "Assets/Code/";
    private const string HotfixDll = "Unity.Hotfix.dll";
    private const string HotfixPdb = "Unity.Hotfix.pdb";

    static HotfixCodeCopyHelper()
    {
        File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "Hotfix.dll.bytes"), true);
        File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "Hotfix.pdb.bytes"), true);
        Log.Info($"复制Hotfix dlls到Res/Code完成");
        AssetDatabase.Refresh();
    }
}
