
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
    unsafe class UnityUI_UIEventType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityUI.UIEventType);

            field = type.GetField("onSubmit", flag);
            app.RegisterCLRFieldGetter(field, get_onSubmit_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_onSubmit_0, null);
            field = type.GetField("onClick", flag);
            app.RegisterCLRFieldGetter(field, get_onClick_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_onClick_1, null);
            field = type.GetField("onHover", flag);
            app.RegisterCLRFieldGetter(field, get_onHover_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_onHover_2, null);
            field = type.GetField("onToggleChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onToggleChanged_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_onToggleChanged_3, null);
            field = type.GetField("onSliderChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onSliderChanged_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_onSliderChanged_4, null);
            field = type.GetField("onScrollbarChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onScrollbarChanged_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_onScrollbarChanged_5, null);
            field = type.GetField("onDrapDownChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onDrapDownChanged_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_onDrapDownChanged_6, null);
            field = type.GetField("onInputFieldChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onInputFieldChanged_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_onInputFieldChanged_7, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityUI.UIEventType());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityUI.UIEventType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref UnityUI.UIEventType instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as UnityUI.UIEventType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_onSubmit_0(ref object o)
        {
            return UnityUI.UIEventType.onSubmit;
        }

        static StackObject* CopyToStack_onSubmit_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onSubmit;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onClick_1(ref object o)
        {
            return UnityUI.UIEventType.onClick;
        }

        static StackObject* CopyToStack_onClick_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onClick;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onHover_2(ref object o)
        {
            return UnityUI.UIEventType.onHover;
        }

        static StackObject* CopyToStack_onHover_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onHover;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onToggleChanged_3(ref object o)
        {
            return UnityUI.UIEventType.onToggleChanged;
        }

        static StackObject* CopyToStack_onToggleChanged_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onToggleChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onSliderChanged_4(ref object o)
        {
            return UnityUI.UIEventType.onSliderChanged;
        }

        static StackObject* CopyToStack_onSliderChanged_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onSliderChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onScrollbarChanged_5(ref object o)
        {
            return UnityUI.UIEventType.onScrollbarChanged;
        }

        static StackObject* CopyToStack_onScrollbarChanged_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onScrollbarChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onDrapDownChanged_6(ref object o)
        {
            return UnityUI.UIEventType.onDrapDownChanged;
        }

        static StackObject* CopyToStack_onDrapDownChanged_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onDrapDownChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_onInputFieldChanged_7(ref object o)
        {
            return UnityUI.UIEventType.onInputFieldChanged;
        }

        static StackObject* CopyToStack_onInputFieldChanged_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityUI.UIEventType.onInputFieldChanged;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new UnityUI.UIEventType();
            ins = (UnityUI.UIEventType)o;
            return ins;
        }


    }
}
#endif
