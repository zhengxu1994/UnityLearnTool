using System;
using System.Collections;
using System.Reflection;
using FairyGUI;
namespace ZFramework.UI
{
    public abstract class ExtensionBase : IDisposable
    {
        public GComponent uiObj { get; private set; } = null;

        private string _name = null;

        public string Name { get => _name ?? (_name = GetType().Name); }

        private DictBox<string, CoroutineHandler> countHandlers = null;

        protected static Type[] createOTypes = new Type[]{};

        public abstract void OnCreate();

        public virtual void Show() {
            uiObj.visible = true;
        }

        public virtual void Hide() {
            uiObj.visible = false;
        }

        public static T Create<T>(GComponent uiObj) where T : ExtensionBase
        {
            return Create(typeof(T), uiObj) as T;
        }

        public static ExtensionBase Create(Type type,GComponent uiObj)
        {
            //必须继承自ExtensionBase的类
            if(!type.IsSubclassOf(typeof(ExtensionBase)) || type.IsSubclassOf(typeof(ViewBase)))
            {
                //Log.Error("Super Type Error : {0} must be extend ExtensionBase", type.ToString());
                return null;
            }

            ExtensionBase view = null;
            //反射生成
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            //类型 构造器 生成
            ConstructorInfo ctor = type.GetConstructor(flags, Type.DefaultBinder, createOTypes, null);
            if (ctor != null)
                view = ctor.Invoke(null) as ExtensionBase;
            //else
            //    Log.Error("Create {0} Not Find Constructor", type.ToString());
            if (view != null)
            {
                //初始化
                InitUIObject(view, uiObj);
                view.InitObjPosition();
                view.OnCreate();
            }
            else
                uiObj.Dispose();
            return view;
        }

        public static void InitUIObject(ExtensionBase view,GComponent uiObj)
        {
            view.uiObj = uiObj;
            view.uiObj.onDispose.Add(() => view.RealDispose(true));
            view.AutoBinderUI();
            uiObj.data = view;
        }

        ~ExtensionBase()
        {
            //if (!disposed)
            //    Log.Warning($"please call {this.GetType().Name} Dispose function initiative!!!");
            RealDispose(false);
        }

        public string icon
        {
            get => uiObj.icon;
            set => uiObj.icon = value;
        }

        public string text
        {
            get => uiObj.text;
            set => uiObj.text = value;
        }

        public virtual void AutoBinderUI()
        {

        }

        public virtual void InitObjPosition()
        {

        }

        private bool disposed = false;

        public virtual void Dispose()
        {

        }

        private void OnDispose()
        {
            disposed = true;

            if(countHandlers != null)
            {
                countHandlers.BoxEach((k, v) => { CoroutineManager.Inst.Stop(v); });
                countHandlers.Clear();
            }

            //NotifactionCenter.Inst.RemoveObserver(this);
            //if(this is PanelBase)
            //{

            //}
            if (uiObj != null)
                uiObj.data = null;
            GTween.Kill(this);
            GTween.Kill(uiObj);
        }

        private void RealDispose(bool disposing)
        {
            if(!disposed)
            {
                OnDispose();
                if (!disposing)
                    uiObj.Dispose();
                else
                    Dispose();
            }
            disposed = true;
        }

        protected void AddCoroutine(string key,IEnumerator rIEnum)
        {
            if (countHandlers == null)
                countHandlers = new DictBox<string, CoroutineHandler>();
            if (!countHandlers.ContainKey(key))
                countHandlers.Add(key, CoroutineManager.Inst.StartHandler(rIEnum));
        }

        protected void RemoveCoroutine(string key)
        {
            if(countHandlers != null)
            {
                if(countHandlers.ContainKey(key))
                {
                    CoroutineManager.Inst.Stop(countHandlers[key]);
                    countHandlers.Remove(key);
                }
            }
        }

        public virtual bool visable
        {
            get
            {
                if (uiObj != null)
                    return uiObj.visible;
                return false;
            }
            set
            {
                if (uiObj.visible == value) return;
                if (value)
                    Show();
                else
                    Hide();
            }
        }

        public virtual int sortingOrder
        {
            get => uiObj.sortingOrder;
            set
            {
                uiObj.sortingOrder = value;
            }
        }
    }

    public abstract class ViewBase : ExtensionBase
    {
        protected GGraph modal = null;

        public GGraph Modal => modal;

        NotifyParam _objParam;

        protected NotifyParam objParams
        {
            get
            {
                if (_objParam == null)
                    _objParam = NotifyParam.Create();
                return _objParam;
            }
            set => _objParam = value;
        }

        public static T Create<T>(GComponent uiObj, NotifyParam objParams = null, bool isPanel = false)
            where T: ViewBase
        {
            return CreateInvoke(uiObj, typeof(T).Name, objParams, isPanel) as T;
        }

        public static ViewBase CreateInvoke(GComponent uiObj,string className,NotifyParam objParams= null,
            bool isPanel = false)
        {
            ViewBase view = null;
            Type type = Type.GetType("ZFramework.UI".Append(className));
            if(!type.IsSubclassOf(typeof(ViewBase)) || (!isPanel && type.IsSubclassOf(typeof(PanelBase))))
            {
                //Log.Error("Super Type Error :{0} must be extend ViewBase", type);
                return null;
            }
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            ConstructorInfo ctor = type.GetConstructor(flags, Type.DefaultBinder, createOTypes, null);
            if (ctor != null)
                view = (ViewBase)ctor.Invoke(null);
            else
                //Log.Error("Create {0} Not Find Constructor", type);
            if (view != null)
            {
                view.objParams = objParams;
                InitUIObject(view, uiObj);
                if (!isPanel)
                {
                    view.InitObjPosition();
                    view.OnCreate();
                }
                // PostNotification
            }
            else
                uiObj.Dispose();
            return view;
        }

        public void SetVisible(bool isShow)
        {
            uiObj.visible = isShow;
            if (modal != null)
                modal.visible = isShow;
        }

        private void OnDispose()
        {
            objParams?.Destory();
            objParams = null;
            modal?.RemoveFromParent();
            modal.Dispose();
            base.Dispose();
        }

        public override void Dispose()
        {
            OnDispose();
        }

        public GGraph CreateModal()
        {
            modal = new GGraph();
            modal.SetSize(GRoot.inst.width, GRoot.inst.height);
            modal.DrawRect(GRoot.inst.width, GRoot.inst.height, 1
                , new UnityEngine.Color(0, 0, 0), new UnityEngine.Color(0, 0, 0, 0.7f));
            modal.onClick.Set(() => {
                UIManager.Inst.RemovePanel(Name);
            });
            return modal;
        }

        public abstract class PanelBase : ViewBase
        {
            public LayerEnum layer = LayerEnum.UI;

            protected abstract void OnRemove();

            public override void Dispose()
            {
                base.Dispose();
                OnRemove();
            }

            public string showTitle { get; protected set; } = "";

            public abstract void OnSafeAreaChange(int safeSpace);
        }
    }
}