
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
    unsafe class GameDll_Events_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.Events);

            field = type.GetField("OnCameraPositionChangedEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnCameraPositionChangedEvent_0);
            app.RegisterCLRFieldSetter(field, set_OnCameraPositionChangedEvent_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnCameraPositionChangedEvent_0, AssignFromStack_OnCameraPositionChangedEvent_0);
            field = type.GetField("OnPrepareOkEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnPrepareOkEvent_1);
            app.RegisterCLRFieldSetter(field, set_OnPrepareOkEvent_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPrepareOkEvent_1, AssignFromStack_OnPrepareOkEvent_1);
            field = type.GetField("OnOnAddRoomsEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnOnAddRoomsEvent_2);
            app.RegisterCLRFieldSetter(field, set_OnOnAddRoomsEvent_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnOnAddRoomsEvent_2, AssignFromStack_OnOnAddRoomsEvent_2);
            field = type.GetField("OnObjectPositionChangedEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnObjectPositionChangedEvent_3);
            app.RegisterCLRFieldSetter(field, set_OnObjectPositionChangedEvent_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnObjectPositionChangedEvent_3, AssignFromStack_OnObjectPositionChangedEvent_3);
            field = type.GetField("OnSceneLoadEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnSceneLoadEvent_4);
            app.RegisterCLRFieldSetter(field, set_OnSceneLoadEvent_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnSceneLoadEvent_4, AssignFromStack_OnSceneLoadEvent_4);
            field = type.GetField("OnCameraTargetChangedEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnCameraTargetChangedEvent_5);
            app.RegisterCLRFieldSetter(field, set_OnCameraTargetChangedEvent_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnCameraTargetChangedEvent_5, AssignFromStack_OnCameraTargetChangedEvent_5);
            field = type.GetField("OnChangeMySelfEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnChangeMySelfEvent_6);
            app.RegisterCLRFieldSetter(field, set_OnChangeMySelfEvent_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnChangeMySelfEvent_6, AssignFromStack_OnChangeMySelfEvent_6);
            field = type.GetField("OnPingChangeEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnPingChangeEvent_7);
            app.RegisterCLRFieldSetter(field, set_OnPingChangeEvent_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPingChangeEvent_7, AssignFromStack_OnPingChangeEvent_7);
            field = type.GetField("OnStartLoadLevelEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnStartLoadLevelEvent_8);
            app.RegisterCLRFieldSetter(field, set_OnStartLoadLevelEvent_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnStartLoadLevelEvent_8, AssignFromStack_OnStartLoadLevelEvent_8);
            field = type.GetField("OnCreatePlayerBoardEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnCreatePlayerBoardEvent_9);
            app.RegisterCLRFieldSetter(field, set_OnCreatePlayerBoardEvent_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnCreatePlayerBoardEvent_9, AssignFromStack_OnCreatePlayerBoardEvent_9);
            field = type.GetField("OnScoreChangeEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnScoreChangeEvent_10);
            app.RegisterCLRFieldSetter(field, set_OnScoreChangeEvent_10);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnScoreChangeEvent_10, AssignFromStack_OnScoreChangeEvent_10);
            field = type.GetField("OnTimeChangeEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnTimeChangeEvent_11);
            app.RegisterCLRFieldSetter(field, set_OnTimeChangeEvent_11);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnTimeChangeEvent_11, AssignFromStack_OnTimeChangeEvent_11);
            field = type.GetField("OnPickObjEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnPickObjEvent_12);
            app.RegisterCLRFieldSetter(field, set_OnPickObjEvent_12);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPickObjEvent_12, AssignFromStack_OnPickObjEvent_12);
            field = type.GetField("OnRemovePlayerBoardEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnRemovePlayerBoardEvent_13);
            app.RegisterCLRFieldSetter(field, set_OnRemovePlayerBoardEvent_13);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnRemovePlayerBoardEvent_13, AssignFromStack_OnRemovePlayerBoardEvent_13);
            field = type.GetField("OnHurtEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnHurtEvent_14);
            app.RegisterCLRFieldSetter(field, set_OnHurtEvent_14);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnHurtEvent_14, AssignFromStack_OnHurtEvent_14);
            field = type.GetField("OnPropertyChangedEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnPropertyChangedEvent_15);
            app.RegisterCLRFieldSetter(field, set_OnPropertyChangedEvent_15);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPropertyChangedEvent_15, AssignFromStack_OnPropertyChangedEvent_15);
            field = type.GetField("OnTestMapEvent", flag);
            app.RegisterCLRFieldGetter(field, get_OnTestMapEvent_16);
            app.RegisterCLRFieldSetter(field, set_OnTestMapEvent_16);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnTestMapEvent_16, AssignFromStack_OnTestMapEvent_16);
            field = type.GetField("OnBattleOpenUIs", flag);
            app.RegisterCLRFieldGetter(field, get_OnBattleOpenUIs_17);
            app.RegisterCLRFieldSetter(field, set_OnBattleOpenUIs_17);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnBattleOpenUIs_17, AssignFromStack_OnBattleOpenUIs_17);
            field = type.GetField("OnBattleCloseUIs", flag);
            app.RegisterCLRFieldGetter(field, get_OnBattleCloseUIs_18);
            app.RegisterCLRFieldSetter(field, set_OnBattleCloseUIs_18);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnBattleCloseUIs_18, AssignFromStack_OnBattleCloseUIs_18);
            field = type.GetField("OnStartApplication_OnAppInitOk", flag);
            app.RegisterCLRFieldGetter(field, get_OnStartApplication_OnAppInitOk_19);
            app.RegisterCLRFieldSetter(field, set_OnStartApplication_OnAppInitOk_19);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnStartApplication_OnAppInitOk_19, AssignFromStack_OnStartApplication_OnAppInitOk_19);
            field = type.GetField("OnLoginMessageHF_EnterLoginScene", flag);
            app.RegisterCLRFieldGetter(field, get_OnLoginMessageHF_EnterLoginScene_20);
            app.RegisterCLRFieldSetter(field, set_OnLoginMessageHF_EnterLoginScene_20);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnLoginMessageHF_EnterLoginScene_20, AssignFromStack_OnLoginMessageHF_EnterLoginScene_20);
            field = type.GetField("OnLoginMessageHF_StartLogin", flag);
            app.RegisterCLRFieldGetter(field, get_OnLoginMessageHF_StartLogin_21);
            app.RegisterCLRFieldSetter(field, set_OnLoginMessageHF_StartLogin_21);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnLoginMessageHF_StartLogin_21, AssignFromStack_OnLoginMessageHF_StartLogin_21);
            field = type.GetField("OnNetStateChanged", flag);
            app.RegisterCLRFieldGetter(field, get_OnNetStateChanged_22);
            app.RegisterCLRFieldSetter(field, set_OnNetStateChanged_22);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnNetStateChanged_22, AssignFromStack_OnNetStateChanged_22);
            field = type.GetField("OnLobby_EnterLobbyScene", flag);
            app.RegisterCLRFieldGetter(field, get_OnLobby_EnterLobbyScene_23);
            app.RegisterCLRFieldSetter(field, set_OnLobby_EnterLobbyScene_23);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnLobby_EnterLobbyScene_23, AssignFromStack_OnLobby_EnterLobbyScene_23);
            field = type.GetField("OnLobby_LeaveLobbyScene", flag);
            app.RegisterCLRFieldGetter(field, get_OnLobby_LeaveLobbyScene_24);
            app.RegisterCLRFieldSetter(field, set_OnLobby_LeaveLobbyScene_24);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnLobby_LeaveLobbyScene_24, AssignFromStack_OnLobby_LeaveLobbyScene_24);
            field = type.GetField("OnPrepareBattleOk", flag);
            app.RegisterCLRFieldGetter(field, get_OnPrepareBattleOk_25);
            app.RegisterCLRFieldSetter(field, set_OnPrepareBattleOk_25);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPrepareBattleOk_25, AssignFromStack_OnPrepareBattleOk_25);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.Events());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.Events[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_OnCameraPositionChangedEvent_0(ref object o)
        {
            return ((GameDll.Events)o).OnCameraPositionChangedEvent;
        }

        static StackObject* CopyToStack_OnCameraPositionChangedEvent_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnCameraPositionChangedEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnCameraPositionChangedEvent_0(ref object o, object v)
        {
            ((GameDll.Events)o).OnCameraPositionChangedEvent = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnCameraPositionChangedEvent_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnCameraPositionChangedEvent = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnCameraPositionChangedEvent = @OnCameraPositionChangedEvent;
            return ptr_of_this_method;
        }

        static object get_OnPrepareOkEvent_1(ref object o)
        {
            return ((GameDll.Events)o).OnPrepareOkEvent;
        }

        static StackObject* CopyToStack_OnPrepareOkEvent_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnPrepareOkEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPrepareOkEvent_1(ref object o, object v)
        {
            ((GameDll.Events)o).OnPrepareOkEvent = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnPrepareOkEvent_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnPrepareOkEvent = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnPrepareOkEvent = @OnPrepareOkEvent;
            return ptr_of_this_method;
        }

        static object get_OnOnAddRoomsEvent_2(ref object o)
        {
            return ((GameDll.Events)o).OnOnAddRoomsEvent;
        }

        static StackObject* CopyToStack_OnOnAddRoomsEvent_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnOnAddRoomsEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnOnAddRoomsEvent_2(ref object o, object v)
        {
            ((GameDll.Events)o).OnOnAddRoomsEvent = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnOnAddRoomsEvent_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnOnAddRoomsEvent = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnOnAddRoomsEvent = @OnOnAddRoomsEvent;
            return ptr_of_this_method;
        }

        static object get_OnObjectPositionChangedEvent_3(ref object o)
        {
            return ((GameDll.Events)o).OnObjectPositionChangedEvent;
        }

        static StackObject* CopyToStack_OnObjectPositionChangedEvent_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnObjectPositionChangedEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnObjectPositionChangedEvent_3(ref object o, object v)
        {
            ((GameDll.Events)o).OnObjectPositionChangedEvent = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnObjectPositionChangedEvent_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnObjectPositionChangedEvent = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnObjectPositionChangedEvent = @OnObjectPositionChangedEvent;
            return ptr_of_this_method;
        }

        static object get_OnSceneLoadEvent_4(ref object o)
        {
            return ((GameDll.Events)o).OnSceneLoadEvent;
        }

        static StackObject* CopyToStack_OnSceneLoadEvent_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnSceneLoadEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnSceneLoadEvent_4(ref object o, object v)
        {
            ((GameDll.Events)o).OnSceneLoadEvent = (System.Action<System.Boolean>)v;
        }

        static StackObject* AssignFromStack_OnSceneLoadEvent_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Boolean> @OnSceneLoadEvent = (System.Action<System.Boolean>)typeof(System.Action<System.Boolean>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnSceneLoadEvent = @OnSceneLoadEvent;
            return ptr_of_this_method;
        }

        static object get_OnCameraTargetChangedEvent_5(ref object o)
        {
            return ((GameDll.Events)o).OnCameraTargetChangedEvent;
        }

        static StackObject* CopyToStack_OnCameraTargetChangedEvent_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnCameraTargetChangedEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnCameraTargetChangedEvent_5(ref object o, object v)
        {
            ((GameDll.Events)o).OnCameraTargetChangedEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnCameraTargetChangedEvent_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnCameraTargetChangedEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnCameraTargetChangedEvent = @OnCameraTargetChangedEvent;
            return ptr_of_this_method;
        }

        static object get_OnChangeMySelfEvent_6(ref object o)
        {
            return ((GameDll.Events)o).OnChangeMySelfEvent;
        }

        static StackObject* CopyToStack_OnChangeMySelfEvent_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnChangeMySelfEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnChangeMySelfEvent_6(ref object o, object v)
        {
            ((GameDll.Events)o).OnChangeMySelfEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnChangeMySelfEvent_6(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnChangeMySelfEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnChangeMySelfEvent = @OnChangeMySelfEvent;
            return ptr_of_this_method;
        }

        static object get_OnPingChangeEvent_7(ref object o)
        {
            return ((GameDll.Events)o).OnPingChangeEvent;
        }

        static StackObject* CopyToStack_OnPingChangeEvent_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnPingChangeEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPingChangeEvent_7(ref object o, object v)
        {
            ((GameDll.Events)o).OnPingChangeEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnPingChangeEvent_7(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnPingChangeEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnPingChangeEvent = @OnPingChangeEvent;
            return ptr_of_this_method;
        }

        static object get_OnStartLoadLevelEvent_8(ref object o)
        {
            return ((GameDll.Events)o).OnStartLoadLevelEvent;
        }

        static StackObject* CopyToStack_OnStartLoadLevelEvent_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnStartLoadLevelEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnStartLoadLevelEvent_8(ref object o, object v)
        {
            ((GameDll.Events)o).OnStartLoadLevelEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnStartLoadLevelEvent_8(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnStartLoadLevelEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnStartLoadLevelEvent = @OnStartLoadLevelEvent;
            return ptr_of_this_method;
        }

        static object get_OnCreatePlayerBoardEvent_9(ref object o)
        {
            return ((GameDll.Events)o).OnCreatePlayerBoardEvent;
        }

        static StackObject* CopyToStack_OnCreatePlayerBoardEvent_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnCreatePlayerBoardEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnCreatePlayerBoardEvent_9(ref object o, object v)
        {
            ((GameDll.Events)o).OnCreatePlayerBoardEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnCreatePlayerBoardEvent_9(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnCreatePlayerBoardEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnCreatePlayerBoardEvent = @OnCreatePlayerBoardEvent;
            return ptr_of_this_method;
        }

        static object get_OnScoreChangeEvent_10(ref object o)
        {
            return ((GameDll.Events)o).OnScoreChangeEvent;
        }

        static StackObject* CopyToStack_OnScoreChangeEvent_10(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnScoreChangeEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnScoreChangeEvent_10(ref object o, object v)
        {
            ((GameDll.Events)o).OnScoreChangeEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnScoreChangeEvent_10(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnScoreChangeEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnScoreChangeEvent = @OnScoreChangeEvent;
            return ptr_of_this_method;
        }

        static object get_OnTimeChangeEvent_11(ref object o)
        {
            return ((GameDll.Events)o).OnTimeChangeEvent;
        }

        static StackObject* CopyToStack_OnTimeChangeEvent_11(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnTimeChangeEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnTimeChangeEvent_11(ref object o, object v)
        {
            ((GameDll.Events)o).OnTimeChangeEvent = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnTimeChangeEvent_11(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @OnTimeChangeEvent = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnTimeChangeEvent = @OnTimeChangeEvent;
            return ptr_of_this_method;
        }

        static object get_OnPickObjEvent_12(ref object o)
        {
            return ((GameDll.Events)o).OnPickObjEvent;
        }

        static StackObject* CopyToStack_OnPickObjEvent_12(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnPickObjEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPickObjEvent_12(ref object o, object v)
        {
            ((GameDll.Events)o).OnPickObjEvent = (System.Action<GameDll.IEventParam>)v;
        }

        static StackObject* AssignFromStack_OnPickObjEvent_12(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<GameDll.IEventParam> @OnPickObjEvent = (System.Action<GameDll.IEventParam>)typeof(System.Action<GameDll.IEventParam>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnPickObjEvent = @OnPickObjEvent;
            return ptr_of_this_method;
        }

        static object get_OnRemovePlayerBoardEvent_13(ref object o)
        {
            return ((GameDll.Events)o).OnRemovePlayerBoardEvent;
        }

        static StackObject* CopyToStack_OnRemovePlayerBoardEvent_13(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnRemovePlayerBoardEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnRemovePlayerBoardEvent_13(ref object o, object v)
        {
            ((GameDll.Events)o).OnRemovePlayerBoardEvent = (System.Action<System.Int32, System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnRemovePlayerBoardEvent_13(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32, System.Int32> @OnRemovePlayerBoardEvent = (System.Action<System.Int32, System.Int32>)typeof(System.Action<System.Int32, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnRemovePlayerBoardEvent = @OnRemovePlayerBoardEvent;
            return ptr_of_this_method;
        }

        static object get_OnHurtEvent_14(ref object o)
        {
            return ((GameDll.Events)o).OnHurtEvent;
        }

        static StackObject* CopyToStack_OnHurtEvent_14(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnHurtEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnHurtEvent_14(ref object o, object v)
        {
            ((GameDll.Events)o).OnHurtEvent = (System.Action<System.Int32, System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnHurtEvent_14(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32, System.Int32> @OnHurtEvent = (System.Action<System.Int32, System.Int32>)typeof(System.Action<System.Int32, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnHurtEvent = @OnHurtEvent;
            return ptr_of_this_method;
        }

        static object get_OnPropertyChangedEvent_15(ref object o)
        {
            return ((GameDll.Events)o).OnPropertyChangedEvent;
        }

        static StackObject* CopyToStack_OnPropertyChangedEvent_15(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnPropertyChangedEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPropertyChangedEvent_15(ref object o, object v)
        {
            ((GameDll.Events)o).OnPropertyChangedEvent = (System.Action<System.Int32, System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnPropertyChangedEvent_15(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32, System.Int32> @OnPropertyChangedEvent = (System.Action<System.Int32, System.Int32>)typeof(System.Action<System.Int32, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnPropertyChangedEvent = @OnPropertyChangedEvent;
            return ptr_of_this_method;
        }

        static object get_OnTestMapEvent_16(ref object o)
        {
            return ((GameDll.Events)o).OnTestMapEvent;
        }

        static StackObject* CopyToStack_OnTestMapEvent_16(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnTestMapEvent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnTestMapEvent_16(ref object o, object v)
        {
            ((GameDll.Events)o).OnTestMapEvent = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnTestMapEvent_16(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnTestMapEvent = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnTestMapEvent = @OnTestMapEvent;
            return ptr_of_this_method;
        }

        static object get_OnBattleOpenUIs_17(ref object o)
        {
            return ((GameDll.Events)o).OnBattleOpenUIs;
        }

        static StackObject* CopyToStack_OnBattleOpenUIs_17(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnBattleOpenUIs;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnBattleOpenUIs_17(ref object o, object v)
        {
            ((GameDll.Events)o).OnBattleOpenUIs = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnBattleOpenUIs_17(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnBattleOpenUIs = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnBattleOpenUIs = @OnBattleOpenUIs;
            return ptr_of_this_method;
        }

        static object get_OnBattleCloseUIs_18(ref object o)
        {
            return ((GameDll.Events)o).OnBattleCloseUIs;
        }

        static StackObject* CopyToStack_OnBattleCloseUIs_18(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnBattleCloseUIs;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnBattleCloseUIs_18(ref object o, object v)
        {
            ((GameDll.Events)o).OnBattleCloseUIs = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnBattleCloseUIs_18(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnBattleCloseUIs = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnBattleCloseUIs = @OnBattleCloseUIs;
            return ptr_of_this_method;
        }

        static object get_OnStartApplication_OnAppInitOk_19(ref object o)
        {
            return ((GameDll.Events)o).OnStartApplication_OnAppInitOk;
        }

        static StackObject* CopyToStack_OnStartApplication_OnAppInitOk_19(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnStartApplication_OnAppInitOk;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnStartApplication_OnAppInitOk_19(ref object o, object v)
        {
            ((GameDll.Events)o).OnStartApplication_OnAppInitOk = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnStartApplication_OnAppInitOk_19(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnStartApplication_OnAppInitOk = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnStartApplication_OnAppInitOk = @OnStartApplication_OnAppInitOk;
            return ptr_of_this_method;
        }

        static object get_OnLoginMessageHF_EnterLoginScene_20(ref object o)
        {
            return ((GameDll.Events)o).OnLoginMessageHF_EnterLoginScene;
        }

        static StackObject* CopyToStack_OnLoginMessageHF_EnterLoginScene_20(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnLoginMessageHF_EnterLoginScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnLoginMessageHF_EnterLoginScene_20(ref object o, object v)
        {
            ((GameDll.Events)o).OnLoginMessageHF_EnterLoginScene = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnLoginMessageHF_EnterLoginScene_20(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnLoginMessageHF_EnterLoginScene = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnLoginMessageHF_EnterLoginScene = @OnLoginMessageHF_EnterLoginScene;
            return ptr_of_this_method;
        }

        static object get_OnLoginMessageHF_StartLogin_21(ref object o)
        {
            return ((GameDll.Events)o).OnLoginMessageHF_StartLogin;
        }

        static StackObject* CopyToStack_OnLoginMessageHF_StartLogin_21(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnLoginMessageHF_StartLogin;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnLoginMessageHF_StartLogin_21(ref object o, object v)
        {
            ((GameDll.Events)o).OnLoginMessageHF_StartLogin = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnLoginMessageHF_StartLogin_21(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnLoginMessageHF_StartLogin = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnLoginMessageHF_StartLogin = @OnLoginMessageHF_StartLogin;
            return ptr_of_this_method;
        }

        static object get_OnNetStateChanged_22(ref object o)
        {
            return ((GameDll.Events)o).OnNetStateChanged;
        }

        static StackObject* CopyToStack_OnNetStateChanged_22(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnNetStateChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnNetStateChanged_22(ref object o, object v)
        {
            ((GameDll.Events)o).OnNetStateChanged = (System.Action<System.Int32, System.Int32>)v;
        }

        static StackObject* AssignFromStack_OnNetStateChanged_22(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32, System.Int32> @OnNetStateChanged = (System.Action<System.Int32, System.Int32>)typeof(System.Action<System.Int32, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnNetStateChanged = @OnNetStateChanged;
            return ptr_of_this_method;
        }

        static object get_OnLobby_EnterLobbyScene_23(ref object o)
        {
            return ((GameDll.Events)o).OnLobby_EnterLobbyScene;
        }

        static StackObject* CopyToStack_OnLobby_EnterLobbyScene_23(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnLobby_EnterLobbyScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnLobby_EnterLobbyScene_23(ref object o, object v)
        {
            ((GameDll.Events)o).OnLobby_EnterLobbyScene = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnLobby_EnterLobbyScene_23(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnLobby_EnterLobbyScene = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnLobby_EnterLobbyScene = @OnLobby_EnterLobbyScene;
            return ptr_of_this_method;
        }

        static object get_OnLobby_LeaveLobbyScene_24(ref object o)
        {
            return ((GameDll.Events)o).OnLobby_LeaveLobbyScene;
        }

        static StackObject* CopyToStack_OnLobby_LeaveLobbyScene_24(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnLobby_LeaveLobbyScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnLobby_LeaveLobbyScene_24(ref object o, object v)
        {
            ((GameDll.Events)o).OnLobby_LeaveLobbyScene = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnLobby_LeaveLobbyScene_24(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnLobby_LeaveLobbyScene = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnLobby_LeaveLobbyScene = @OnLobby_LeaveLobbyScene;
            return ptr_of_this_method;
        }

        static object get_OnPrepareBattleOk_25(ref object o)
        {
            return ((GameDll.Events)o).OnPrepareBattleOk;
        }

        static StackObject* CopyToStack_OnPrepareBattleOk_25(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Events)o).OnPrepareBattleOk;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPrepareBattleOk_25(ref object o, object v)
        {
            ((GameDll.Events)o).OnPrepareBattleOk = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnPrepareBattleOk_25(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnPrepareBattleOk = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Events)o).OnPrepareBattleOk = @OnPrepareBattleOk;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.Events();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
