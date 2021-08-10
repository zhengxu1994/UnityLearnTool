
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
    unsafe class UnityEngine_UI_ToggleGroup_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(UnityEngine.UI.ToggleGroup);
            args = new Type[]{};
            method = type.GetMethod("get_allowSwitchOff", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_allowSwitchOff_0);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_allowSwitchOff", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_allowSwitchOff_1);
            args = new Type[]{typeof(UnityEngine.UI.Toggle), typeof(System.Boolean)};
            method = type.GetMethod("NotifyToggleOn", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, NotifyToggleOn_2);
            args = new Type[]{typeof(UnityEngine.UI.Toggle)};
            method = type.GetMethod("UnregisterToggle", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, UnregisterToggle_3);
            args = new Type[]{typeof(UnityEngine.UI.Toggle)};
            method = type.GetMethod("RegisterToggle", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RegisterToggle_4);
            args = new Type[]{};
            method = type.GetMethod("EnsureValidState", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, EnsureValidState_5);
            args = new Type[]{};
            method = type.GetMethod("AnyTogglesOn", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AnyTogglesOn_6);
            args = new Type[]{};
            method = type.GetMethod("ActiveToggles", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ActiveToggles_7);
            args = new Type[]{};
            method = type.GetMethod("GetFirstActiveToggle", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetFirstActiveToggle_8);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("SetAllTogglesOff", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetAllTogglesOff_9);



            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.UI.ToggleGroup[s]);


        }


        static StackObject* get_allowSwitchOff_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.allowSwitchOff;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_allowSwitchOff_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.allowSwitchOff = value;

            return __ret;
        }

        static StackObject* NotifyToggleOn_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @sendCallback = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Toggle @toggle = (UnityEngine.UI.Toggle)typeof(UnityEngine.UI.Toggle).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.NotifyToggleOn(@toggle, @sendCallback);

            return __ret;
        }

        static StackObject* UnregisterToggle_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Toggle @toggle = (UnityEngine.UI.Toggle)typeof(UnityEngine.UI.Toggle).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.UnregisterToggle(@toggle);

            return __ret;
        }

        static StackObject* RegisterToggle_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Toggle @toggle = (UnityEngine.UI.Toggle)typeof(UnityEngine.UI.Toggle).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RegisterToggle(@toggle);

            return __ret;
        }

        static StackObject* EnsureValidState_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.EnsureValidState();

            return __ret;
        }

        static StackObject* AnyTogglesOn_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.AnyTogglesOn();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ActiveToggles_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.ActiveToggles();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetFirstActiveToggle_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetFirstActiveToggle();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetAllTogglesOff_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @sendCallback = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.ToggleGroup instance_of_this_method = (UnityEngine.UI.ToggleGroup)typeof(UnityEngine.UI.ToggleGroup).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetAllTogglesOff(@sendCallback);

            return __ret;
        }





    }
}
#endif
