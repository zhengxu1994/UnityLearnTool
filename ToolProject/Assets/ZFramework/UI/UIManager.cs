using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using static ZFramework.UI.ViewBase;
using System;

namespace ZFramework.UI
{
    public enum LayerEnum
    {
        UI = 0,
        Top = 1,
        Cover = 2,
        Tip = 3,
        Guide = 4,
        Waiting = 5,
        Count = 6,
    }
    public partial class UIManager : Singleton<UIManager>
    {
        private  GComponent[] layers = new GComponent[(int)LayerEnum.Count];

        public static readonly int DesignHeight = 640;
        public static readonly int DesignWidth = 1136;
        private static readonly List<string> PkgCache = new List<string>() {
            "Main","Common","Battle"
        };
        private DictBox<string, PanelBase> panels = new DictBox<string, PanelBase>();
        private LinkedList<string> panelStack = new LinkedList<string>();

        private string rootNode = "";
        public int SafeSpace { get; private set; } = 50;

        public int PanelCount => panelStack.Count;

        
        private UIManager()
        {
            for (int i = 0; i < (int)LayerEnum.Count; i++)
            {
                layers[i] = new GComponent();
                layers[i].gameObjectName = (LayerEnum.UI + i).ToString();
                GRoot.inst.AddChild(layers[i]);
                layers[i].MakeFullScreen();
            }

            GRoot.inst.onSizeChanged.Add(() => {
                for (int i = 0; i < (int)LayerEnum.Count; i++)
                {
                    layers[i].MakeFullScreen();
                }
            });
        }

        public static void FitFullScreen(GObject obj,bool allShow = false)
        {
            float _rateR = (DesignHeight * 1.0f) / DesignWidth;
            float _rateV = GRoot.inst.height / GRoot.inst.width;
            //物理分辨率 > 设计分辨率 使用高度比
            if(_rateV > _rateR && !allShow)
            {
                float scale = GRoot.inst.height / DesignHeight;
                obj.width = GRoot.inst.width * scale;
                obj.height = GRoot.inst.height;
            }
            else
            {
                //物理分辨率 < 设计分辨率 使用宽度比
                float scale = GRoot.inst.width / DesignWidth;
                obj.width = GRoot.inst.width;
                obj.height = GRoot.inst.height * scale;
            }
        }

        public void RemovePanel(Type type)
        {
            RemovePanel(type.Name);
        }

        public void RemovePanel<T>() where T : PanelBase
        {
            RemovePanel(typeof(T));
        }

        public void RemovePanel(string uiName,bool isCreateRoot = true)
        {
            //没有该界面
            if (!panels.ContainKey(uiName))
                return;

            
        }
    }
}
