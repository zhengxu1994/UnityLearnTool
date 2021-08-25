using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class _11UberShaderGUI : ShaderGUI {
    Material target;
    MaterialEditor editor;
    MaterialProperty[] properties;
    int lastBlendMode = -1;

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties){
        this.editor = editor;
        this.target = this.editor.target as Material;
        this.properties = properties;
        ShowMain();
        ShowUVFlow();
        ShowMask();
        ShowDistort();
        ShowDissolve();
        ShowSoftParticle();
        ShowRenderMode();
    }

    void ShowUVFlow(){
        ShowPropertys("_UseUVFlow");
        var property = ShaderGUI.FindProperty("_UseUVFlow", properties);
        if (property.floatValue > 0.5) {
            ShowPropertys("_FlowSpeed");
        }

    }

    void ShowMain(){
        ShowPropertys("_TintColor");
        ShowPropertys("_MainTex");
    }

    void ShowDistort(){
        ShowBlock("_DistortTex","USE_DISTORT",()=>{
            ShowPropertys("_DistortTex");
            ShowPropertys("_DistrotStrength");
            ShowPropertys("_DistortRotateSpeed");
        });
    } 
    void ShowDissolve(){
        ShowBlock("_DissolveTex","USE_DISSOLVE",()=>{
            ShowPropertys("_DissolveTex");
            ShowPropertys("_DissolveProgress");
            ShowPropertys("_DissolveColor");
            ShowPropertys("_DissolveRange");
        });
    }

    void ShowMask(){
        ShowBlock("_MaskTex","USE_MASK",()=>{
            ShowPropertys("_MaskTex");
            //ShowVector2("_MainSpeed2_MaskSpeed2", "MaskTexture FlowSpeed", 2,3);
        });
    }
    void ShowSoftParticle(){
        var _UseSoftParticle = ShaderGUI.FindProperty("_UseSoftParticle", properties);
        editor.ShaderProperty(_UseSoftParticle, _UseSoftParticle.displayName);
        if (_UseSoftParticle.floatValue > 0.5f) {
            ShowPropertys("_InvFade");
        }
    }
    
    void ShowRenderMode(){
        ShowPropertys("_CullMode");
        var _BlendMode = ShaderGUI.FindProperty("_BlendMode", properties);
        editor.ShaderProperty(_BlendMode, _BlendMode.displayName);

        var blendMode = (BlendMode)Mathf.RoundToInt(_BlendMode.floatValue);
        SetupMaterialWithBlendMode(target,blendMode,lastBlendMode != -1 && lastBlendMode != (int)blendMode);
        lastBlendMode = (int)blendMode;
        editor.RenderQueueField();
    }


    
    
    
    void ShowBlock(string name,string macroName, System.Action callback){
        MaterialProperty map = FindProperty(name);
        EditorGUI.BeginChangeCheck();
        if (map.textureValue != null) {
            //GUILayout.Label(name, EditorStyles.boldLabel);
            //EditorGUI.indentLevel += 1;
            callback();
            //EditorGUI.indentLevel -= 1;
            GUILayout.Space(10);
        }
        else { 
            this.editor.TexturePropertySingleLine(MakeLabel(map, name), map,null);
        }
        if (EditorGUI.EndChangeCheck()) {
            SetKeyword(macroName, map.textureValue);
        }
    }
    MaterialProperty FindProperty (string name) {
        return FindProperty(name, properties);
    }
    
    static GUIContent staticLabel = new GUIContent();
    static GUIContent MakeLabel (MaterialProperty property, string tooltip = null) {
        staticLabel.text = property.displayName;
        staticLabel.tooltip = tooltip;
        return staticLabel;
    }
    void SetKeyword (string keyword, bool state) {
        if (state) {
            foreach (Material m in editor.targets) {
                m.EnableKeyword(keyword);
            }
        }
        else {
            foreach (Material m in editor.targets) {
                m.DisableKeyword(keyword);
            }
        }
    }
    
        
        
    void ShowPropertys(string name){
        var property = ShaderGUI.FindProperty(name, properties);
        editor.ShaderProperty(property, property.displayName);
    }
    
    
    
        #region RenderMode Implement
        public enum BlendMode
        {
            //Blend,   // Old school alpha-blending mode, fresnel does not affect amount of transparency
            //Transparent, // Physically plausible transparency mode, implemented as alpha pre-multiply
            Additive,Blend,Opaque,Cutout,Transparent,Subtractive,Modulate
        }

        public static void SetupMaterialWithBlendMode(Material material, BlendMode blendMode,bool isResetRenderQueue)
        {
            switch (blendMode)
            {
                case BlendMode.Opaque:
                    material.SetOverrideTag("RenderType", "");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    if(isResetRenderQueue) material.renderQueue = 2000;
                    break;
                case BlendMode.Cutout:
                    material.SetOverrideTag("RenderType", "TransparentCutout");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest;
                    break;
                case BlendMode.Blend:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Transparent:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Additive:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_ZWrite", 0);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Subtractive:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.ReverseSubtract);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_ZWrite", 0);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Modulate:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.DstColor);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if(isResetRenderQueue) material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
            }
        }

        #endregion
}
