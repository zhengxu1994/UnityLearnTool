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

        private CommonTop commonTop { get; set; }
        
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

        private void SetTopInfo(UIData uiData,bool showAni = true)
        {
            if(uiData != null && uiData.topInfo != null)
            {
                if(commonTop == null)
                {
                    GObject top = UIPackage.CreateObject("Common", "CommonTop");
                    layers[(int)LayerEnum.Top].AddChild(top);
                    commonTop = ExtUtil.Cast<CommonTop>(top);
                }

                commonTop.SetPanelInfo(uiData.topInfo,showAni);
                commonTop.visable =true;
            }
        }

        public void RemTop(bool remove = false)
        {
            if(commonTop != null)
            {
                if (remove)
                {
                    commonTop.Dispose();
                    commonTop = null;
                }
                else
                    commonTop.visable = false;
            }
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
            UIData config = GetUIData(uiName);
            string pkgName = config.package;

            PanelBase panel = panels[uiName];
            panels.Remove(uiName);

            if (panelStack.Contains(uiName))
                panelStack.Remove(uiName);
            panel.Dispose();

            if(config.closeSound != null)
            {
                //播放音效
            }

            bool remPkg = PkgCache.IndexOf(pkgName) < 0;
            //没有界面引用这些资源，则将资源卸载掉
            if(remPkg)
            {
                var pair = panels.GetEnumerator();
                while (pair.MoveNext())
                {
                    if (pair.Current.Key != uiName)
                    {
                        UIData data = GetUIData(pair.Current.Key);
                        if(data.package == config.package)
                        {
                            remPkg = false;
                            break;
                        }
                    }
                }
            }

            //移除ab包
            //if(remPkg)
            //    resourcemanager

            //依次向前查找到第一个有commonTop的panel
            var lastPanel = panelStack.Last;
            bool remCommonTop = true;
            bool topSet = false;
            bool visSet = false;
            bool isCloseFullScreen = config.isFullScreen;
            while (lastPanel != null)
            {
                uiName = lastPanel.Value;
                config = GetUIData(uiName);
                if(config.topInfo != null && !topSet)
                {
                    topSet = true;
                    remCommonTop = false;
                    SetTopInfo(config, isCloseFullScreen);
                }
                if(!visSet)
                {
                    if (config.layer == LayerEnum.Guide)
                        panels[uiName].SetVisible(true);
                    visSet = config.hideBelow;
                }
                if (topSet && visSet)
                    break;
                lastPanel = lastPanel.Previous;
            }

            if(PanelCount <= 0 && isCreateRoot)
            {
                //如果是home 回到mainui    
            }

            if (remCommonTop)
                RemTop(true);
        }

        private void InitPanel(string uiName,GObject obj,PanelBase panel)
        {
            UIData config = GetUIData(uiName);
            GComponent uiObj = obj.asCom;

            if(config.isRoot)
            {
                HashBox<string> remPanels = new HashBox<string>();
                var pair = panelStack.GetEnumerator();
                while (pair.MoveNext())
                    remPanels.Add(pair.Current);
                remPanels.BoxEach((v) => { RemovePanel(v, false); });
                remPanels.Clear();
            }

            panels[uiName] = panel;
            panel.layer = config.layer;
            if (panel.layer != LayerEnum.Guide)
                panelStack.AddLast(uiName);
            GComponent parent = layers[(int)config.layer];
            uiObj.name = uiName;
            if(config.isModal)
            {
                parent.AddChild(panel.CreateModal());
                if (!config.isFullScreen)
                    uiObj.opaque = false;
            }
            parent.AddChild(uiObj);

            SetTopInfo(config);
            if (!string.IsNullOrEmpty(panel.showTitle))
                commonTop?.SetTitle(panel.showTitle);

            if(config.hideBelow)
            {
                panels.BoxEach((k, v) =>{
                    if (v.Name != uiName)
                        v.SetVisible(false);
                });
            }

            panel.OnCreate();

            //设置全屏
            if (config.isFullScreen)
            {
                SafeSpace = LocalStore.Data.GetInt("sliderPadding", 50);
                if (GRoot.inst.width != DesignWidth || GRoot.inst.height != DesignHeight)
                {
                    uiObj.onSizeChanged.Add(() =>
                    {
                        panel.InitObjPosition();
                        panel.OnSafeAreaChange(SafeSpace);
                    });
                }
                else
                {
                    panel.InitObjPosition();
                    panel.OnSafeAreaChange(SafeSpace);
                }
                uiObj.MakeFullScreen();
            }
            else
            {
                uiObj.SetPivot(0.5f, 0.5f);
                uiObj.pivotAsAnchor = true;
                uiObj.x = GRoot.inst.width / 2;
                uiObj.y = GRoot.inst.height / 2;
                uiObj.scaleX = 1.1f;
                uiObj.scaleY = 1.1f;

                GTweener tweener = uiObj.TweenScale(new Vector2(1.0f, 1.0f), 0.4f);
                tweener.SetEase(EaseType.ExpoOut);
            }

            if(config.openSound != null)
            {
                //播放音效
            }

            GObject closeButton = uiObj.GetChild("closeButton");
            if(closeButton != null)
            {
                closeButton.onClick.Set(() => {
                    RemovePanel(uiName);
                });
            }
        }

        private PanelBase CreateUI(string uiName, bool async, NotifyParam objParams = null, Action<PanelBase> dlg = null)
        {
            Type type = Type.GetType("ZFramework.UI".Append(uiName));
            if(!type.IsSubclassOf(typeof(PanelBase)))
            {
                Log.Error($"can not find panel base{uiName}");
                return null;
            }
            UIData config = GetUIData(uiName);
            if(config == null)
            {
                throw new Exception(string.Format("Not Find UI Config{0}", uiName));
            }

            if(panels.ContainKey(uiName))
            {
                var oldPanel = panels[uiName];
                dlg?.Invoke(oldPanel);
                oldPanel.visable = true;
                if(oldPanel.layer != LayerEnum.Guide)
                {
                    panelStack.Remove(uiName);
                    panelStack.AddLast(uiName);
                }

                SetTopInfo(config);
                return oldPanel;
            }

            //Load Package

            if(async)
            {
                UIPackage.CreateObjectAsync(config.package, config.resource, (GObject uiObj) => {
                    var com = uiObj.asCom;
                    var panel = (PanelBase)ViewBase.CreateInvoke(com,uiName, objParams, true);
                    if(panel != null)
                    {
                        InitPanel(uiName, uiObj, panel);
                        dlg?.Invoke(panel);
                    }
                });
            }
            else
            {
                GObject uiObj = UIPackage.CreateObject(config.package, config.resource);
                if(uiObj != null)
                {
                    var com = uiObj.asCom;
                    var panel = (PanelBase)ViewBase.CreateInvoke(com, uiName, objParams, true);
                    if(panel != null)
                    {
                        InitPanel(uiName, uiObj, panel);
                        return panel;
                    }
                }
                throw new Exception(string.Format("Create UI failed :{0}", uiName));
            }
            return null;
        }

        public void CreateAsync<T>(NotifyParam objParams = null,Action<PanelBase> dlg = null)
        {
            CreateUI(typeof(T).Name, true, objParams, dlg);
        }

        public PanelBase CreatePanel(Type type,NotifyParam objParams = null)
        {
            return CreateUI(type.Name, false, objParams);
        }

        public T CreatePanel<T>(NotifyParam objParams = null) where T :PanelBase
        {
            return CreateUI(typeof(T).Name, false, objParams) as T; 
        }

        public void ChangeSafeSpace(int space)
        {
            SafeSpace = space;
            panels.BoxEach((k, v) => {
                v.OnSafeAreaChange(space);
            });
        }
    }
}
