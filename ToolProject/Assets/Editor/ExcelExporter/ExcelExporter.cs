using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public enum ConfigType
{
    Client,
    Server
}

struct HeadInfo
{
    public string FieldAttribute;
    public string FieldDesc;
    public string FieldName;
    public string FieldType;

    public HeadInfo(string cs,string desc,string name,string type)
    {
        this.FieldAttribute = cs;
        this.FieldDesc = desc;
        this.FieldName = name;
        this.FieldType = type;
    }
}
public static class ExcelExporter 
{
    private static string template;

    private const string clientClassDir = "../../../Unity/Assets/Model/Generate/Config";

    private const string serverClassDir = "../../../Server/Model/Generate/Config";

    private const string excelDir = "../../../Excel";

    private const string jsonDir = "./{0}/Json";

    private const string clientProtoDir = "../../../Unity/Assets/Bundles/Config";
    private const string serverProtoDir = "../../../Config";

    private static string GetProtoDir(ConfigType configType)
    {
        if (configType == ConfigType.Client)
            return clientProtoDir;
        return serverProtoDir;
    }

    private static string GetClassDir(ConfigType config)
    {
        if (config == ConfigType.Client)
            return clientClassDir;
        return serverClassDir;
    }

    [MenuItem("Tool/ExportExcel")]
    public static void Export()
    {
        template = File.ReadAllText("Template.txt");
    }
}
