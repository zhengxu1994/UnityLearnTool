
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
    unsafe class UnityEngine_UI_CanvasUpdate_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityEngine.UI.CanvasUpdate);

            field = type.GetField("Prelayout", flag);
            app.RegisterCLRFieldGetter(field, get_Prelayout_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Prelayout_0, null);
            field = type.GetField("Layout", flag);
            app.RegisterCLRFieldGetter(field, get_Layout_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Layout_1, null);
            field = type.GetField("PostLayout", flag);
            app.RegisterCLRFieldGetter(field, get_PostLayout_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_PostLayout_2, null);
            field = type.GetField("PreRender", flag);
            app.RegisterCLRFieldGetter(field, get_PreRender_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_PreRender_3, null);
            field = type.GetField("LatePreRender", flag);
            app.RegisterCLRFieldGetter(field, get_LatePreRender_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_LatePreRender_4, null);
            field = type.GetField("MaxUpdateValue", flag);
            app.RegisterCLRFieldGetter(field, get_MaxUpdateValue_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_MaxUpdateValue_5, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityEngine.UI.CanvasUpdate());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.UI.CanvasUpdate[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref UnityEngine.UI.CanvasUpdate instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as UnityEngine.UI.CanvasUpdate[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Prelayout_0(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.Prelayout;
        }

        static StackObject* CopyToStack_Prelayout_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.Prelayout;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Layout_1(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.Layout;
        }

        static StackObject* CopyToStack_Layout_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.Layout;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PostLayout_2(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.PostLayout;
        }

        static StackObject* CopyToStack_PostLayout_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.PostLayout;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PreRender_3(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.PreRender;
        }

        static StackObject* CopyToStack_PreRender_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.PreRender;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_LatePreRender_4(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.LatePreRender;
        }

        static StackObject* CopyToStack_LatePreRender_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.LatePreRender;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_MaxUpdateValue_5(ref object o)
        {
            return UnityEngine.UI.CanvasUpdate.MaxUpdateValue;
        }

        static StackObject* CopyToStack_MaxUpdateValue_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.UI.CanvasUpdate.MaxUpdateValue;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new UnityEngine.UI.CanvasUpdate();
            ins = (UnityEngine.UI.CanvasUpdate)o;
            return ins;
        }


    }
}
#endif
