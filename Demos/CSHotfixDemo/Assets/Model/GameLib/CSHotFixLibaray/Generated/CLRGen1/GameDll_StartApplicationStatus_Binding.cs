
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
    unsafe class GameDll_StartApplicationStatus_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.StartApplicationStatus);

            field = type.GetField("None", flag);
            app.RegisterCLRFieldGetter(field, get_None_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_None_0, null);
            field = type.GetField("FirstOpenGame", flag);
            app.RegisterCLRFieldGetter(field, get_FirstOpenGame_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_FirstOpenGame_1, null);
            field = type.GetField("InitingResMgr", flag);
            app.RegisterCLRFieldGetter(field, get_InitingResMgr_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_InitingResMgr_2, null);
            field = type.GetField("AppInitOk", flag);
            app.RegisterCLRFieldGetter(field, get_AppInitOk_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_AppInitOk_3, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.StartApplicationStatus());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.StartApplicationStatus[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref GameDll.StartApplicationStatus instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as GameDll.StartApplicationStatus[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_None_0(ref object o)
        {
            return GameDll.StartApplicationStatus.None;
        }

        static StackObject* CopyToStack_None_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.StartApplicationStatus.None;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_FirstOpenGame_1(ref object o)
        {
            return GameDll.StartApplicationStatus.FirstOpenGame;
        }

        static StackObject* CopyToStack_FirstOpenGame_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.StartApplicationStatus.FirstOpenGame;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_InitingResMgr_2(ref object o)
        {
            return GameDll.StartApplicationStatus.InitingResMgr;
        }

        static StackObject* CopyToStack_InitingResMgr_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.StartApplicationStatus.InitingResMgr;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_AppInitOk_3(ref object o)
        {
            return GameDll.StartApplicationStatus.AppInitOk;
        }

        static StackObject* CopyToStack_AppInitOk_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.StartApplicationStatus.AppInitOk;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new GameDll.StartApplicationStatus();
            ins = (GameDll.StartApplicationStatus)o;
            return ins;
        }


    }
}
#endif
