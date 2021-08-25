using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FishMan {
    public class UberParticleGUI : BaseShaderGUI {
        
        protected override void ShowGUI(){
            ShowMain();
            ShowMask();
            ShowDistort();
            ShowDissolve();
            
            ShowSoftParticle();
            ShowRenderMode();
        }
        
        void ShowMain(){

            ShowPropertys("_TintColor");
            ShowPropertys("_ColorFactor");

            ShowPropertys("_MainTex");
            ShowVector2("_MainSpeed2_MaskSpeed2", "MainTexture FlowSpeed", 0,1);
            GUILayout.Space(10);
            
        }
        void ShowMask(){
            ShowBlock("_MaskTex","USE_MASK",()=>{
                ShowPropertys("_MaskTex");
                ShowVector2("_MainSpeed2_MaskSpeed2", "MaskTexture FlowSpeed", 2,3);
            });
        }
        void ShowDistort(){

            ShowBlock("_DistortTex","USE_DISTORT",()=>{
                ShowPropertys("_DistortTex");
                var isFlowDistort = ShowBool("_DistortUVFactor2_RotateSpeed1", "Is Flow Distort?", 3);
                if (isFlowDistort) {
                    ShowVector2("_DistortSpeed2_Factor2", "DistortTexture FlowSpeed", 0,1);
                }
                ShowVector2("_DistortUVFactor2_RotateSpeed1", "Distort UV Strength", 0,1);
                ShowFloat("_DistortUVFactor2_RotateSpeed1", "RotateSpeed", 2);
                SetKeyword("USE_FLOW_DISTORT", isFlowDistort);
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
        void ShowSoftParticle(){
            var _UseSoftParticle = ShaderGUI.FindProperty("_UseSoftParticle", properties);
            editor.ShaderProperty(_UseSoftParticle, _UseSoftParticle.displayName);
            if (FloatEqual(_UseSoftParticle.floatValue, 1)) {
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
        }


    }
}