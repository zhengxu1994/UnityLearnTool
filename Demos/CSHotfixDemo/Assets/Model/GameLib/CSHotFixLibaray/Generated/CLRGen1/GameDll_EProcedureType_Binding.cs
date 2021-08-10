
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
    unsafe class GameDll_EProcedureType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.EProcedureType);

            field = type.GetField("eStart", flag);
            app.RegisterCLRFieldGetter(field, get_eStart_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_eStart_0, null);
            field = type.GetField("eLogin", flag);
            app.RegisterCLRFieldGetter(field, get_eLogin_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_eLogin_1, null);
            field = type.GetField("eLobby", flag);
            app.RegisterCLRFieldGetter(field, get_eLobby_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_eLobby_2, null);
            field = type.GetField("eChangeScene", flag);
            app.RegisterCLRFieldGetter(field, get_eChangeScene_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_eChangeScene_3, null);
            field = type.GetField("eBattle", flag);
            app.RegisterCLRFieldGetter(field, get_eBattle_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_eBattle_4, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.EProcedureType());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.EProcedureType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref GameDll.EProcedureType instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as GameDll.EProcedureType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_eStart_0(ref object o)
        {
            return GameDll.EProcedureType.eStart;
        }

        static StackObject* CopyToStack_eStart_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.EProcedureType.eStart;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_eLogin_1(ref object o)
        {
            return GameDll.EProcedureType.eLogin;
        }

        static StackObject* CopyToStack_eLogin_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.EProcedureType.eLogin;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_eLobby_2(ref object o)
        {
            return GameDll.EProcedureType.eLobby;
        }

        static StackObject* CopyToStack_eLobby_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.EProcedureType.eLobby;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_eChangeScene_3(ref object o)
        {
            return GameDll.EProcedureType.eChangeScene;
        }

        static StackObject* CopyToStack_eChangeScene_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.EProcedureType.eChangeScene;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_eBattle_4(ref object o)
        {
            return GameDll.EProcedureType.eBattle;
        }

        static StackObject* CopyToStack_eBattle_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.EProcedureType.eBattle;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new GameDll.EProcedureType();
            ins = (GameDll.EProcedureType)o;
            return ins;
        }


    }
}
#endif
