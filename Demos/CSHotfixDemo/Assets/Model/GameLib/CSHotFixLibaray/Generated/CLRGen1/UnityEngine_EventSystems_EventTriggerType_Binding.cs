
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
    unsafe class UnityEngine_EventSystems_EventTriggerType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityEngine.EventSystems.EventTriggerType);

            field = type.GetField("PointerEnter", flag);
            app.RegisterCLRFieldGetter(field, get_PointerEnter_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_PointerEnter_0, null);
            field = type.GetField("PointerExit", flag);
            app.RegisterCLRFieldGetter(field, get_PointerExit_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_PointerExit_1, null);
            field = type.GetField("PointerDown", flag);
            app.RegisterCLRFieldGetter(field, get_PointerDown_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_PointerDown_2, null);
            field = type.GetField("PointerUp", flag);
            app.RegisterCLRFieldGetter(field, get_PointerUp_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_PointerUp_3, null);
            field = type.GetField("PointerClick", flag);
            app.RegisterCLRFieldGetter(field, get_PointerClick_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_PointerClick_4, null);
            field = type.GetField("Drag", flag);
            app.RegisterCLRFieldGetter(field, get_Drag_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_Drag_5, null);
            field = type.GetField("Drop", flag);
            app.RegisterCLRFieldGetter(field, get_Drop_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_Drop_6, null);
            field = type.GetField("Scroll", flag);
            app.RegisterCLRFieldGetter(field, get_Scroll_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_Scroll_7, null);
            field = type.GetField("UpdateSelected", flag);
            app.RegisterCLRFieldGetter(field, get_UpdateSelected_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_UpdateSelected_8, null);
            field = type.GetField("Select", flag);
            app.RegisterCLRFieldGetter(field, get_Select_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_Select_9, null);
            field = type.GetField("Deselect", flag);
            app.RegisterCLRFieldGetter(field, get_Deselect_10);
            app.RegisterCLRFieldBinding(field, CopyToStack_Deselect_10, null);
            field = type.GetField("Move", flag);
            app.RegisterCLRFieldGetter(field, get_Move_11);
            app.RegisterCLRFieldBinding(field, CopyToStack_Move_11, null);
            field = type.GetField("InitializePotentialDrag", flag);
            app.RegisterCLRFieldGetter(field, get_InitializePotentialDrag_12);
            app.RegisterCLRFieldBinding(field, CopyToStack_InitializePotentialDrag_12, null);
            field = type.GetField("BeginDrag", flag);
            app.RegisterCLRFieldGetter(field, get_BeginDrag_13);
            app.RegisterCLRFieldBinding(field, CopyToStack_BeginDrag_13, null);
            field = type.GetField("EndDrag", flag);
            app.RegisterCLRFieldGetter(field, get_EndDrag_14);
            app.RegisterCLRFieldBinding(field, CopyToStack_EndDrag_14, null);
            field = type.GetField("Submit", flag);
            app.RegisterCLRFieldGetter(field, get_Submit_15);
            app.RegisterCLRFieldBinding(field, CopyToStack_Submit_15, null);
            field = type.GetField("Cancel", flag);
            app.RegisterCLRFieldGetter(field, get_Cancel_16);
            app.RegisterCLRFieldBinding(field, CopyToStack_Cancel_16, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityEngine.EventSystems.EventTriggerType());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.EventSystems.EventTriggerType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref UnityEngine.EventSystems.EventTriggerType instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as UnityEngine.EventSystems.EventTriggerType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_PointerEnter_0(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.PointerEnter;
        }

        static StackObject* CopyToStack_PointerEnter_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.PointerEnter;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PointerExit_1(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.PointerExit;
        }

        static StackObject* CopyToStack_PointerExit_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.PointerExit;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PointerDown_2(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.PointerDown;
        }

        static StackObject* CopyToStack_PointerDown_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.PointerDown;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PointerUp_3(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.PointerUp;
        }

        static StackObject* CopyToStack_PointerUp_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.PointerUp;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_PointerClick_4(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.PointerClick;
        }

        static StackObject* CopyToStack_PointerClick_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.PointerClick;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Drag_5(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Drag;
        }

        static StackObject* CopyToStack_Drag_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Drag;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Drop_6(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Drop;
        }

        static StackObject* CopyToStack_Drop_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Drop;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Scroll_7(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Scroll;
        }

        static StackObject* CopyToStack_Scroll_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Scroll;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_UpdateSelected_8(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.UpdateSelected;
        }

        static StackObject* CopyToStack_UpdateSelected_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.UpdateSelected;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Select_9(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Select;
        }

        static StackObject* CopyToStack_Select_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Select;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Deselect_10(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Deselect;
        }

        static StackObject* CopyToStack_Deselect_10(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Deselect;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Move_11(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Move;
        }

        static StackObject* CopyToStack_Move_11(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Move;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_InitializePotentialDrag_12(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.InitializePotentialDrag;
        }

        static StackObject* CopyToStack_InitializePotentialDrag_12(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.InitializePotentialDrag;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_BeginDrag_13(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.BeginDrag;
        }

        static StackObject* CopyToStack_BeginDrag_13(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.BeginDrag;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_EndDrag_14(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.EndDrag;
        }

        static StackObject* CopyToStack_EndDrag_14(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.EndDrag;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Submit_15(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Submit;
        }

        static StackObject* CopyToStack_Submit_15(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Submit;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Cancel_16(ref object o)
        {
            return UnityEngine.EventSystems.EventTriggerType.Cancel;
        }

        static StackObject* CopyToStack_Cancel_16(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = UnityEngine.EventSystems.EventTriggerType.Cancel;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new UnityEngine.EventSystems.EventTriggerType();
            ins = (UnityEngine.EventSystems.EventTriggerType)o;
            return ins;
        }


    }
}
#endif
