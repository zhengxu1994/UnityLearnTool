using System;
using UnityEditor;
using UnityEngine;

namespace FishMan {
    public class BaseShaderGUI : ShaderGUI {
        static float TOLERANCE = 0.01f;
        protected GUIContent staticLabel = new GUIContent();
        protected Material target;
        protected MaterialEditor editor;
        protected MaterialProperty[] properties;
        protected bool shouldShowAlphaCutoff;
        protected int lastBlendMode = -1;


        private static GUIStyle _style;

        protected static GUIStyle BoldStyle {
            get {
                if (_style == null) {
                    _style = new GUIStyle();
                    _style.fontStyle = FontStyle.Bold;
                }

                return _style;
            }
        }

        public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties){
            this.editor = editor;
            this.target = this.editor.target as Material;
            this.properties = properties;
            ShowGUI();
            editor.RenderQueueField();

#if UNITY_5_6_OR_NEWER
            editor.EnableInstancingField();
            target.enableInstancing = true;
#endif
        }

        protected virtual void ShowGUI(){ }


        protected void ShowBlock(string name, string macroname, System.Action callback){
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
                this.editor.TexturePropertySingleLine(MakeLabel(map, name), map, null);
            }

            if (EditorGUI.EndChangeCheck()) {
                SetKeyword(macroname, map.textureValue);
            }
        }

        protected void ShowToggleBlock(string name, string macroname, System.Action callback){
            EditorGUI.BeginChangeCheck();
            ShowPropertys(name);
            var property = ShaderGUI.FindProperty(name, properties);
            //if (property.floatValue > 0.5) {
            //    property.floatValue = GUILayout.Toggle(property.floatValue > 0.5, property.displayName, BoldStyle)?1:0;
            //}
            //else {
            //    property.floatValue = GUILayout.Toggle(property.floatValue > 0.5, property.displayName)?1:0;
            //}

            if (property.floatValue > 0.5) {
                //GUILayout.Label(name, EditorStyles.boldLabel);
                EditorGUI.indentLevel += 1;
                callback();
                EditorGUI.indentLevel -= 1;
                GUILayout.Space(15);
            }

            if (EditorGUI.EndChangeCheck()) {
                SetKeyword(macroname, property.floatValue > 0.5);
            }
        }

        #region Util functions

        protected Vector4 ShowVector4(string name){
            var property = ShaderGUI.FindProperty(name, properties);
            var res = target.GetVector(name);
            var val = EditorGUILayout.Vector4Field(property.displayName, res);
            target.SetVector(name, val);
            return res;
        }

        protected Vector4 ShowVector2(string name, string tips, int idx1, int idx2){
            var res = target.GetVector(name);
            var val = EditorGUILayout.Vector2Field(tips, new Vector2(res[idx1], res[idx2]));
            res[idx1] = val.x;
            res[idx2] = val.y;
            target.SetVector(name, res);
            return res;
        }

        protected bool ShowBool(string name, string tips, int idx){
            var res = target.GetVector(name);
            var val = EditorGUILayout.Toggle(tips, res[idx] > 0.5f);
            res[idx] = val ? 1 : 0;
            target.SetVector(name, res);
            return val;
        }

        protected float ShowFloat(string name, string tips, int idx){
            var res = target.GetVector(name);
            var val = EditorGUILayout.FloatField(tips, res[idx]);
            res[idx] = val;
            target.SetVector(name, res);
            return val;
        }


        protected bool FloatEqual(float valA, float valB){
            return Math.Abs(valA - valB) < TOLERANCE;
        }

        protected MaterialProperty FindProperty(string name){
            return FindProperty(name, properties);
        }

        protected GUIContent MakeLabel(MaterialProperty property, string tooltip = null){
            staticLabel.text = property.displayName;
            staticLabel.tooltip = tooltip;
            return staticLabel;
        }

        protected void ShowPropertys(string name){
            var property = ShaderGUI.FindProperty(name, properties);
            editor.ShaderProperty(property, property.displayName);
        }

        protected void SetKeyword(string keyword, bool state){
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

        protected bool IsKeywordEnabled(string keyword){
            return target.IsKeywordEnabled(keyword);
        }

        protected void RecordAction(string label){
            editor.RegisterPropertyChangeUndo(label);
        }

        #endregion


        #region RenderMode Implement

        public enum BlendMode {
            //Blend,   // Old school alpha-blending mode, fresnel does not affect amount of transparency
            //Transparent, // Physically plausible transparency mode, implemented as alpha pre-multiply
            Additive,
            Blend,
            Opaque,
            Cutout,
            Transparent,
            Subtractive,
            Modulate
        }

        protected static void SetupMaterialWithBlendMode(Material material, BlendMode blendMode,
            bool isResetRenderQueue){
            switch (blendMode) {
                case BlendMode.Opaque:
                    material.SetOverrideTag("RenderType", "");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    if (isResetRenderQueue) material.renderQueue = 2000;
                    break;
                case BlendMode.Cutout:
                    material.SetOverrideTag("RenderType", "TransparentCutout");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.AlphaTest;
                    break;
                case BlendMode.Blend:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Transparent:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Additive:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_ZWrite", 0);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Subtractive:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.ReverseSubtract);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_ZWrite", 0);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
                case BlendMode.Modulate:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_BlendOp", (int) UnityEngine.Rendering.BlendOp.Add);
                    material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.DstColor);
                    material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    if (isResetRenderQueue) material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                    break;
            }
        }

        #endregion
    }
}