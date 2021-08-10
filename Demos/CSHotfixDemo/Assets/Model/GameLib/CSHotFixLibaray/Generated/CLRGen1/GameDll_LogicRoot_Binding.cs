
#if CSHotFix
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

using CSHotFix.CLR.TypeSystem;
using CSHotFix.CLR.Method;
using CSHotFix.Runtime.Enviorment;
using CSHotFix.Runtime.Intepreter;
using CSHotFix.Runtime.Stack;
using CSHotFix.Reflection;
using CSHotFix.CLR.Utils;
using System.Linq;
namespace CSHotFix.Runtime.Generated
{
    unsafe class GameDll_LogicRoot_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.LogicRoot);
            args = new Type[]{};
            method = type.GetMethod("get_TimeSinceLastFrame", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_TimeSinceLastFrame_0);
            args = new Type[]{typeof(System.Single)};
            method = type.GetMethod("set_TimeSinceLastFrame", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_TimeSinceLastFrame_1);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("getStream", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getStream_2);
            args = new Type[]{typeof(System.Byte[])};
            method = type.GetMethod("getStream", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getStream_3);
            args = new Type[]{};
            method = type.GetMethod("getLanguage", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getLanguage_4);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("getURLNameNoExt", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getURLNameNoExt_5);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("getURLName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getURLName_6);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("getURLExt", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getURLExt_7);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("getURLDir", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getURLDir_8);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("ShowDebugInfo", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowDebugInfo_9);
            args = new Type[]{};
            method = type.GetMethod("GetPlatformName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetPlatformName_10);
            args = new Type[]{};
            method = type.GetMethod("get_GameMain", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_GameMain_11);
            args = new Type[]{};
            method = type.GetMethod("GetSetting", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetSetting_12);
            args = new Type[]{typeof(UnityEngine.ThreadPriority)};
            method = type.GetMethod("SetLoadThreadPriority", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetLoadThreadPriority_13);
            args = new Type[]{};
            method = type.GetMethod("GetLoadThreadPriority", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetLoadThreadPriority_14);

            field = type.GetField("m_bUsePBNet", flag);
            app.RegisterCLRFieldGetter(field, get_m_bUsePBNet_0);
            app.RegisterCLRFieldSetter(field, set_m_bUsePBNet_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_bUsePBNet_0, AssignFromStack_m_bUsePBNet_0);
            field = type.GetField("m_nLoginScene", flag);
            app.RegisterCLRFieldGetter(field, get_m_nLoginScene_1);
            app.RegisterCLRFieldSetter(field, set_m_nLoginScene_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_nLoginScene_1, AssignFromStack_m_nLoginScene_1);
            field = type.GetField("m_GameFrameRate", flag);
            app.RegisterCLRFieldGetter(field, get_m_GameFrameRate_2);
            app.RegisterCLRFieldSetter(field, set_m_GameFrameRate_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_GameFrameRate_2, AssignFromStack_m_GameFrameRate_2);
            field = type.GetField("m_LoadThreadPriority", flag);
            app.RegisterCLRFieldGetter(field, get_m_LoadThreadPriority_3);
            app.RegisterCLRFieldSetter(field, set_m_LoadThreadPriority_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_LoadThreadPriority_3, AssignFromStack_m_LoadThreadPriority_3);
            field = type.GetField("m_ScreenDesignSize", flag);
            app.RegisterCLRFieldGetter(field, get_m_ScreenDesignSize_4);
            app.RegisterCLRFieldSetter(field, set_m_ScreenDesignSize_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_ScreenDesignSize_4, AssignFromStack_m_ScreenDesignSize_4);
            field = type.GetField("m_bResCache", flag);
            app.RegisterCLRFieldGetter(field, get_m_bResCache_5);
            app.RegisterCLRFieldSetter(field, set_m_bResCache_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_bResCache_5, AssignFromStack_m_bResCache_5);
            field = type.GetField("m_bIsDebugMode", flag);
            app.RegisterCLRFieldGetter(field, get_m_bIsDebugMode_6);
            app.RegisterCLRFieldSetter(field, set_m_bIsDebugMode_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_bIsDebugMode_6, AssignFromStack_m_bIsDebugMode_6);
            field = type.GetField("m_fTimeDelay", flag);
            app.RegisterCLRFieldGetter(field, get_m_fTimeDelay_7);
            app.RegisterCLRFieldSetter(field, set_m_fTimeDelay_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_fTimeDelay_7, AssignFromStack_m_fTimeDelay_7);




        }


        static StackObject* get_TimeSinceLastFrame_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.TimeSinceLastFrame;

            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* set_TimeSinceLastFrame_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Single @value = *(float*)&ptr_of_this_method->Value;


            GameDll.LogicRoot.TimeSinceLastFrame = value;

            return __ret;
        }

        static StackObject* getStream_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @path = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getStream(@path);

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getStream_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @byte_data = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getStream(@byte_data);

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getLanguage_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.getLanguage();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getURLNameNoExt_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @url = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getURLNameNoExt(@url);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getURLName_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @url = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getURLName(@url);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getURLExt_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @url = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getURLExt(@url);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* getURLDir_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @url = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = GameDll.LogicRoot.getURLDir(@url);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* ShowDebugInfo_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @bShow = ptr_of_this_method->Value == 1;


            GameDll.LogicRoot.ShowDebugInfo(@bShow);

            return __ret;
        }

        static StackObject* GetPlatformName_10(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.GetPlatformName();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_GameMain_11(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.GameMain;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetSetting_12(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.GetSetting();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetLoadThreadPriority_13(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.ThreadPriority @priority = (UnityEngine.ThreadPriority)typeof(UnityEngine.ThreadPriority).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            GameDll.LogicRoot.SetLoadThreadPriority(@priority);

            return __ret;
        }

        static StackObject* GetLoadThreadPriority_14(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.LogicRoot.GetLoadThreadPriority();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_m_bUsePBNet_0(ref object o)
        {
            return GameDll.LogicRoot.m_bUsePBNet;
        }

        static StackObject* CopyToStack_m_bUsePBNet_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_bUsePBNet;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_m_bUsePBNet_0(ref object o, object v)
        {
            GameDll.LogicRoot.m_bUsePBNet = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_m_bUsePBNet_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @m_bUsePBNet = ptr_of_this_method->Value == 1;
            GameDll.LogicRoot.m_bUsePBNet = @m_bUsePBNet;
            return ptr_of_this_method;
        }

        static object get_m_nLoginScene_1(ref object o)
        {
            return GameDll.LogicRoot.m_nLoginScene;
        }

        static StackObject* CopyToStack_m_nLoginScene_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_nLoginScene;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_nLoginScene_1(ref object o, object v)
        {
            GameDll.LogicRoot.m_nLoginScene = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_nLoginScene_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_nLoginScene = ptr_of_this_method->Value;
            GameDll.LogicRoot.m_nLoginScene = @m_nLoginScene;
            return ptr_of_this_method;
        }

        static object get_m_GameFrameRate_2(ref object o)
        {
            return GameDll.LogicRoot.m_GameFrameRate;
        }

        static StackObject* CopyToStack_m_GameFrameRate_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_GameFrameRate;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_GameFrameRate_2(ref object o, object v)
        {
            GameDll.LogicRoot.m_GameFrameRate = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_GameFrameRate_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_GameFrameRate = ptr_of_this_method->Value;
            GameDll.LogicRoot.m_GameFrameRate = @m_GameFrameRate;
            return ptr_of_this_method;
        }

        static object get_m_LoadThreadPriority_3(ref object o)
        {
            return GameDll.LogicRoot.m_LoadThreadPriority;
        }

        static StackObject* CopyToStack_m_LoadThreadPriority_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_LoadThreadPriority;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_LoadThreadPriority_3(ref object o, object v)
        {
            GameDll.LogicRoot.m_LoadThreadPriority = (UnityEngine.ThreadPriority)v;
        }

        static StackObject* AssignFromStack_m_LoadThreadPriority_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.ThreadPriority @m_LoadThreadPriority = (UnityEngine.ThreadPriority)typeof(UnityEngine.ThreadPriority).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            GameDll.LogicRoot.m_LoadThreadPriority = @m_LoadThreadPriority;
            return ptr_of_this_method;
        }

        static object get_m_ScreenDesignSize_4(ref object o)
        {
            return GameDll.LogicRoot.m_ScreenDesignSize;
        }

        static StackObject* CopyToStack_m_ScreenDesignSize_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_ScreenDesignSize;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_m_ScreenDesignSize_4(ref object o, object v)
        {
            GameDll.LogicRoot.m_ScreenDesignSize = (UnityEngine.Vector2)v;
        }

        static StackObject* AssignFromStack_m_ScreenDesignSize_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector2 @m_ScreenDesignSize = new UnityEngine.Vector2();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.ParseValue(ref @m_ScreenDesignSize, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @m_ScreenDesignSize = (UnityEngine.Vector2)typeof(UnityEngine.Vector2).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            GameDll.LogicRoot.m_ScreenDesignSize = @m_ScreenDesignSize;
            return ptr_of_this_method;
        }

        static object get_m_bResCache_5(ref object o)
        {
            return GameDll.LogicRoot.m_bResCache;
        }

        static StackObject* CopyToStack_m_bResCache_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_bResCache;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_m_bResCache_5(ref object o, object v)
        {
            GameDll.LogicRoot.m_bResCache = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_m_bResCache_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @m_bResCache = ptr_of_this_method->Value == 1;
            GameDll.LogicRoot.m_bResCache = @m_bResCache;
            return ptr_of_this_method;
        }

        static object get_m_bIsDebugMode_6(ref object o)
        {
            return GameDll.LogicRoot.m_bIsDebugMode;
        }

        static StackObject* CopyToStack_m_bIsDebugMode_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_bIsDebugMode;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_m_bIsDebugMode_6(ref object o, object v)
        {
            GameDll.LogicRoot.m_bIsDebugMode = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_m_bIsDebugMode_6(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @m_bIsDebugMode = ptr_of_this_method->Value == 1;
            GameDll.LogicRoot.m_bIsDebugMode = @m_bIsDebugMode;
            return ptr_of_this_method;
        }

        static object get_m_fTimeDelay_7(ref object o)
        {
            return GameDll.LogicRoot.m_fTimeDelay;
        }

        static StackObject* CopyToStack_m_fTimeDelay_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LogicRoot.m_fTimeDelay;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_fTimeDelay_7(ref object o, object v)
        {
            GameDll.LogicRoot.m_fTimeDelay = (System.Single)v;
        }

        static StackObject* AssignFromStack_m_fTimeDelay_7(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @m_fTimeDelay = *(float*)&ptr_of_this_method->Value;
            GameDll.LogicRoot.m_fTimeDelay = @m_fTimeDelay;
            return ptr_of_this_method;
        }




    }
}
#endif
