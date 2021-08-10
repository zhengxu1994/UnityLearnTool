
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
    unsafe class GameDll_LoginStatus_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.LoginStatus);

            field = type.GetField("None", flag);
            app.RegisterCLRFieldGetter(field, get_None_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_None_0, null);
            field = type.GetField("EnterLoginScene", flag);
            app.RegisterCLRFieldGetter(field, get_EnterLoginScene_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnterLoginScene_1, null);
            field = type.GetField("EnteringLoginScene", flag);
            app.RegisterCLRFieldGetter(field, get_EnteringLoginScene_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnteringLoginScene_2, null);
            field = type.GetField("EnterLoginSceneOK", flag);
            app.RegisterCLRFieldGetter(field, get_EnterLoginSceneOK_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnterLoginSceneOK_3, null);
            field = type.GetField("EnterLoginSceneFailed", flag);
            app.RegisterCLRFieldGetter(field, get_EnterLoginSceneFailed_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnterLoginSceneFailed_4, null);
            field = type.GetField("WaitingForLoginScene", flag);
            app.RegisterCLRFieldGetter(field, get_WaitingForLoginScene_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_WaitingForLoginScene_5, null);
            field = type.GetField("Login", flag);
            app.RegisterCLRFieldGetter(field, get_Login_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_Login_6, null);
            field = type.GetField("Logining", flag);
            app.RegisterCLRFieldGetter(field, get_Logining_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_Logining_7, null);
            field = type.GetField("LoginRst_Ok", flag);
            app.RegisterCLRFieldGetter(field, get_LoginRst_Ok_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginRst_Ok_8, null);
            field = type.GetField("LoginRst_Failed", flag);
            app.RegisterCLRFieldGetter(field, get_LoginRst_Failed_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginRst_Failed_9, null);
            field = type.GetField("LoginGame", flag);
            app.RegisterCLRFieldGetter(field, get_LoginGame_10);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginGame_10, null);
            field = type.GetField("LoginGameing", flag);
            app.RegisterCLRFieldGetter(field, get_LoginGameing_11);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginGameing_11, null);
            field = type.GetField("LoginGameRst_OK", flag);
            app.RegisterCLRFieldGetter(field, get_LoginGameRst_OK_12);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginGameRst_OK_12, null);
            field = type.GetField("LoginGameRst_Failed", flag);
            app.RegisterCLRFieldGetter(field, get_LoginGameRst_Failed_13);
            app.RegisterCLRFieldBinding(field, CopyToStack_LoginGameRst_Failed_13, null);
            field = type.GetField("GoLobby", flag);
            app.RegisterCLRFieldGetter(field, get_GoLobby_14);
            app.RegisterCLRFieldBinding(field, CopyToStack_GoLobby_14, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.LoginStatus());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.LoginStatus[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref GameDll.LoginStatus instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as GameDll.LoginStatus[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_None_0(ref object o)
        {
            return GameDll.LoginStatus.None;
        }

        static StackObject* CopyToStack_None_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.None;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_EnterLoginScene_1(ref object o)
        {
            return GameDll.LoginStatus.EnterLoginScene;
        }

        static StackObject* CopyToStack_EnterLoginScene_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.EnterLoginScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_EnteringLoginScene_2(ref object o)
        {
            return GameDll.LoginStatus.EnteringLoginScene;
        }

        static StackObject* CopyToStack_EnteringLoginScene_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.EnteringLoginScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_EnterLoginSceneOK_3(ref object o)
        {
            return GameDll.LoginStatus.EnterLoginSceneOK;
        }

        static StackObject* CopyToStack_EnterLoginSceneOK_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.EnterLoginSceneOK;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_EnterLoginSceneFailed_4(ref object o)
        {
            return GameDll.LoginStatus.EnterLoginSceneFailed;
        }

        static StackObject* CopyToStack_EnterLoginSceneFailed_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.EnterLoginSceneFailed;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_WaitingForLoginScene_5(ref object o)
        {
            return GameDll.LoginStatus.WaitingForLoginScene;
        }

        static StackObject* CopyToStack_WaitingForLoginScene_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.WaitingForLoginScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Login_6(ref object o)
        {
            return GameDll.LoginStatus.Login;
        }

        static StackObject* CopyToStack_Login_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.Login;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Logining_7(ref object o)
        {
            return GameDll.LoginStatus.Logining;
        }

        static StackObject* CopyToStack_Logining_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.Logining;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginRst_Ok_8(ref object o)
        {
            return GameDll.LoginStatus.LoginRst_Ok;
        }

        static StackObject* CopyToStack_LoginRst_Ok_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginRst_Ok;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginRst_Failed_9(ref object o)
        {
            return GameDll.LoginStatus.LoginRst_Failed;
        }

        static StackObject* CopyToStack_LoginRst_Failed_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginRst_Failed;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginGame_10(ref object o)
        {
            return GameDll.LoginStatus.LoginGame;
        }

        static StackObject* CopyToStack_LoginGame_10(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginGame;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginGameing_11(ref object o)
        {
            return GameDll.LoginStatus.LoginGameing;
        }

        static StackObject* CopyToStack_LoginGameing_11(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginGameing;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginGameRst_OK_12(ref object o)
        {
            return GameDll.LoginStatus.LoginGameRst_OK;
        }

        static StackObject* CopyToStack_LoginGameRst_OK_12(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginGameRst_OK;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LoginGameRst_Failed_13(ref object o)
        {
            return GameDll.LoginStatus.LoginGameRst_Failed;
        }

        static StackObject* CopyToStack_LoginGameRst_Failed_13(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.LoginGameRst_Failed;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_GoLobby_14(ref object o)
        {
            return GameDll.LoginStatus.GoLobby;
        }

        static StackObject* CopyToStack_GoLobby_14(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.LoginStatus.GoLobby;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new GameDll.LoginStatus();
            ins = (GameDll.LoginStatus)o;
            return ins;
        }


    }
}
#endif
