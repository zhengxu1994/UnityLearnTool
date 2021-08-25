using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FishMan {
    public class UberSpriteGUI : BaseShaderGUI {
        protected override void ShowGUI(){
            ShowMain();
            ShowPixelStyle();
            ShowBlur();
            ShowDesaturate();
            ShowShadow();
            ShowChromaticAberration();
            ShowOutline();
            ShowInnerOutline();
        }

        GUIContent MakeLabel(MaterialProperty property, string tooltip = null){
            staticLabel.text = property.displayName;
            staticLabel.tooltip = tooltip;
            return staticLabel;
        }

        void ShowMain(){
            var prop = ShaderGUI.FindProperty("_MainTex", properties);
            var prop2 = ShaderGUI.FindProperty("_Color", properties);
            this.editor.TexturePropertySingleLine(MakeLabel(prop), prop, prop2);
            GUILayout.Space(15);
        }

        void ShowPixelStyle(){
            ShowToggleBlock("_UsePixelate", "USE_PIXELATE", () => { ShowPropertys("_PixelResolution"); });
        }

        void ShowBlur(){
            ShowToggleBlock("_UseBlur", "USE_BLUR", () => { ShowPropertys("_BlurIntensity"); });
        }

        void ShowDesaturate(){
            ShowToggleBlock("_UseDesaturate", "USE_DESATURATE", () => { ShowPropertys("_DesaturateFactor"); });
        }

        void ShowShadow(){
            ShowToggleBlock("_UseShadow", "USE_SHADOW", () => {
                ShowPropertys("_ShadowColor");
                ShowPropertys("_ShadowOffset");
            });
        }

        void ShowChromaticAberration(){
            ShowToggleBlock("_UseChromaticAberr", "USE_CHROMATIC_ABERRATION", () => {
                ShowPropertys("_ChromaticAberrFactor");
                ShowPropertys("_ChromaticAberrAlpha");
            });
        }

        void ShowOutline(){
            ShowToggleBlock("_UseOutline", "USE_OUTLINE", () => {
                ShowPropertys("_OutlineColor");
                ShowPropertys("_OutlineWidth_Alpha_Glow");
            });
        }

        void ShowInnerOutline(){
            ShowToggleBlock("_UseInnerOutline", "USE_INNER_OUTLINE", () => {
                ShowPropertys("_InnerOutlineColor");
                ShowPropertys("_InnerOutlineWidth_Alpha_Glow");
            });
        }

    }
}