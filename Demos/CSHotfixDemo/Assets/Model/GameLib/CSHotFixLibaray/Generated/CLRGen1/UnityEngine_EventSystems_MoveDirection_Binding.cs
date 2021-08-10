
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
    unsafe class UnityEngine_EventSystems_MoveDirection_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityEngine.EventSystems.MoveDirection);

            field = type.GetField("Left", flag);
            app.RegisterCLRFieldGetter(field, get_Left_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Left_0, null);
            field = type.GetField("Up", flag);
            app.RegisterCLRFieldGetter(field, get_Up_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Up_1, null);
            field = type.GetField("Right", flag);
            app.RegisterCLRFieldGetter(field, get_Right_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Right_2, null);
            field = type.GetField("Down", flag);
            app.RegisterCLRFieldGetter(field, get_Down_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_Down_3, null);
            field = type.GetField("None", flag);
            app.RegisterCLRFieldGetter(field, get_None_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_None_4, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityEngine.EventSystems.MoveDirection());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.EventSystems.MoveDirection[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref UnityEngine.EventSystems.MoveDirection instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as UnityEngine.EventSystems.MoveDirection[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Left_0(ref object o)
        {
            return UnityEngine.EventSystems.MoveDirection.Left;
        }

        static StackObject* CopyToStack_Left_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.MoveDirection.Left;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Up_1(ref object o)
        {
            return UnityEngine.EventSystems.MoveDirection.Up;
        }

        static StackObject* CopyToStack_Up_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.MoveDirection.Up;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Right_2(ref object o)
        {
            return UnityEngine.EventSystems.MoveDirection.Right;
        }

        static StackObject* CopyToStack_Right_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.MoveDirection.Right;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Down_3(ref object o)
        {
            return UnityEngine.EventSystems.MoveDirection.Down;
        }

        static StackObject* CopyToStack_Down_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.MoveDirection.Down;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_None_4(ref object o)
        {
            return UnityEngine.EventSystems.MoveDirection.None;
        }

        static StackObject* CopyToStack_None_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.MoveDirection.None;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new UnityEngine.EventSystems.MoveDirection();
            ins = (UnityEngine.EventSystems.MoveDirection)o;
            return ins;
        }


    }
}
#endif
