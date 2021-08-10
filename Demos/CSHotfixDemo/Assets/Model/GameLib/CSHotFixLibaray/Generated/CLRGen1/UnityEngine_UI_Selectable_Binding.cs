
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
    unsafe class UnityEngine_UI_Selectable_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(UnityEngine.UI.Selectable);
            args = new Type[]{};
            method = type.GetMethod("get_allSelectablesArray", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_allSelectablesArray_0);
            args = new Type[]{};
            method = type.GetMethod("get_allSelectableCount", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_allSelectableCount_1);
            args = new Type[]{typeof(UnityEngine.UI.Selectable[])};
            method = type.GetMethod("AllSelectablesNoAlloc", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AllSelectablesNoAlloc_2);
            args = new Type[]{};
            method = type.GetMethod("get_navigation", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_navigation_3);
            args = new Type[]{typeof(UnityEngine.UI.Navigation)};
            method = type.GetMethod("set_navigation", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_navigation_4);
            args = new Type[]{};
            method = type.GetMethod("get_transition", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_transition_5);
            args = new Type[]{typeof(UnityEngine.UI.Selectable.Transition)};
            method = type.GetMethod("set_transition", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_transition_6);
            args = new Type[]{};
            method = type.GetMethod("get_colors", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_colors_7);
            args = new Type[]{typeof(UnityEngine.UI.ColorBlock)};
            method = type.GetMethod("set_colors", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_colors_8);
            args = new Type[]{};
            method = type.GetMethod("get_spriteState", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_spriteState_9);
            args = new Type[]{typeof(UnityEngine.UI.SpriteState)};
            method = type.GetMethod("set_spriteState", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_spriteState_10);
            args = new Type[]{};
            method = type.GetMethod("get_animationTriggers", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_animationTriggers_11);
            args = new Type[]{typeof(UnityEngine.UI.AnimationTriggers)};
            method = type.GetMethod("set_animationTriggers", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_animationTriggers_12);
            args = new Type[]{};
            method = type.GetMethod("get_targetGraphic", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_targetGraphic_13);
            args = new Type[]{typeof(UnityEngine.UI.Graphic)};
            method = type.GetMethod("set_targetGraphic", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_targetGraphic_14);
            args = new Type[]{};
            method = type.GetMethod("get_interactable", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_interactable_15);
            args = new Type[]{typeof(System.Boolean)};
            method = type.GetMethod("set_interactable", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_interactable_16);
            args = new Type[]{};
            method = type.GetMethod("get_image", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_image_17);
            args = new Type[]{typeof(UnityEngine.UI.Image)};
            method = type.GetMethod("set_image", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_image_18);
            args = new Type[]{};
            method = type.GetMethod("get_animator", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_animator_19);
            args = new Type[]{};
            method = type.GetMethod("IsInteractable", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsInteractable_20);
            args = new Type[]{typeof(UnityEngine.Vector3)};
            method = type.GetMethod("FindSelectable", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, FindSelectable_21);
            args = new Type[]{};
            method = type.GetMethod("FindSelectableOnLeft", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, FindSelectableOnLeft_22);
            args = new Type[]{};
            method = type.GetMethod("FindSelectableOnRight", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, FindSelectableOnRight_23);
            args = new Type[]{};
            method = type.GetMethod("FindSelectableOnUp", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, FindSelectableOnUp_24);
            args = new Type[]{};
            method = type.GetMethod("FindSelectableOnDown", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, FindSelectableOnDown_25);
            args = new Type[]{typeof(UnityEngine.EventSystems.AxisEventData)};
            method = type.GetMethod("OnMove", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnMove_26);
            args = new Type[]{typeof(UnityEngine.EventSystems.PointerEventData)};
            method = type.GetMethod("OnPointerDown", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnPointerDown_27);
            args = new Type[]{typeof(UnityEngine.EventSystems.PointerEventData)};
            method = type.GetMethod("OnPointerUp", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnPointerUp_28);
            args = new Type[]{typeof(UnityEngine.EventSystems.PointerEventData)};
            method = type.GetMethod("OnPointerEnter", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnPointerEnter_29);
            args = new Type[]{typeof(UnityEngine.EventSystems.PointerEventData)};
            method = type.GetMethod("OnPointerExit", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnPointerExit_30);
            args = new Type[]{typeof(UnityEngine.EventSystems.BaseEventData)};
            method = type.GetMethod("OnSelect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnSelect_31);
            args = new Type[]{typeof(UnityEngine.EventSystems.BaseEventData)};
            method = type.GetMethod("OnDeselect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnDeselect_32);
            args = new Type[]{};
            method = type.GetMethod("Select", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Select_33);



            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.UI.Selectable[s]);


        }


        static StackObject* get_allSelectablesArray_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = UnityEngine.UI.Selectable.allSelectablesArray;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_allSelectableCount_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = UnityEngine.UI.Selectable.allSelectableCount;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* AllSelectablesNoAlloc_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable[] @selectables = (UnityEngine.UI.Selectable[])typeof(UnityEngine.UI.Selectable[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = UnityEngine.UI.Selectable.AllSelectablesNoAlloc(@selectables);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_navigation_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.navigation;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_navigation_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Navigation @value = (UnityEngine.UI.Navigation)typeof(UnityEngine.UI.Navigation).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.navigation = value;

            return __ret;
        }

        static StackObject* get_transition_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.transition;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_transition_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable.Transition @value = (UnityEngine.UI.Selectable.Transition)typeof(UnityEngine.UI.Selectable.Transition).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.transition = value;

            return __ret;
        }

        static StackObject* get_colors_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.colors;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_colors_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.ColorBlock @value = (UnityEngine.UI.ColorBlock)typeof(UnityEngine.UI.ColorBlock).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.colors = value;

            return __ret;
        }

        static StackObject* get_spriteState_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.spriteState;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_spriteState_10(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.SpriteState @value = (UnityEngine.UI.SpriteState)typeof(UnityEngine.UI.SpriteState).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.spriteState = value;

            return __ret;
        }

        static StackObject* get_animationTriggers_11(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.animationTriggers;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_animationTriggers_12(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.AnimationTriggers @value = (UnityEngine.UI.AnimationTriggers)typeof(UnityEngine.UI.AnimationTriggers).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.animationTriggers = value;

            return __ret;
        }

        static StackObject* get_targetGraphic_13(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.targetGraphic;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_targetGraphic_14(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Graphic @value = (UnityEngine.UI.Graphic)typeof(UnityEngine.UI.Graphic).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.targetGraphic = value;

            return __ret;
        }

        static StackObject* get_interactable_15(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.interactable;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* set_interactable_16(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @value = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.interactable = value;

            return __ret;
        }

        static StackObject* get_image_17(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.image;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_image_18(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Image @value = (UnityEngine.UI.Image)typeof(UnityEngine.UI.Image).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.image = value;

            return __ret;
        }

        static StackObject* get_animator_19(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.animator;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* IsInteractable_20(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsInteractable();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* FindSelectable_21(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.Vector3 @dir = new UnityEngine.Vector3();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @dir, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @dir = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
                __intp.Free(ptr_of_this_method);
            }

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.FindSelectable(@dir);

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* FindSelectableOnLeft_22(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.FindSelectableOnLeft();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* FindSelectableOnRight_23(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.FindSelectableOnRight();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* FindSelectableOnUp_24(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.FindSelectableOnUp();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* FindSelectableOnDown_25(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.FindSelectableOnDown();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* OnMove_26(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.AxisEventData @eventData = (UnityEngine.EventSystems.AxisEventData)typeof(UnityEngine.EventSystems.AxisEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnMove(@eventData);

            return __ret;
        }

        static StackObject* OnPointerDown_27(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.PointerEventData @eventData = (UnityEngine.EventSystems.PointerEventData)typeof(UnityEngine.EventSystems.PointerEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnPointerDown(@eventData);

            return __ret;
        }

        static StackObject* OnPointerUp_28(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.PointerEventData @eventData = (UnityEngine.EventSystems.PointerEventData)typeof(UnityEngine.EventSystems.PointerEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnPointerUp(@eventData);

            return __ret;
        }

        static StackObject* OnPointerEnter_29(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.PointerEventData @eventData = (UnityEngine.EventSystems.PointerEventData)typeof(UnityEngine.EventSystems.PointerEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnPointerEnter(@eventData);

            return __ret;
        }

        static StackObject* OnPointerExit_30(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.PointerEventData @eventData = (UnityEngine.EventSystems.PointerEventData)typeof(UnityEngine.EventSystems.PointerEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnPointerExit(@eventData);

            return __ret;
        }

        static StackObject* OnSelect_31(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.BaseEventData @eventData = (UnityEngine.EventSystems.BaseEventData)typeof(UnityEngine.EventSystems.BaseEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnSelect(@eventData);

            return __ret;
        }

        static StackObject* OnDeselect_32(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.EventSystems.BaseEventData @eventData = (UnityEngine.EventSystems.BaseEventData)typeof(UnityEngine.EventSystems.BaseEventData).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnDeselect(@eventData);

            return __ret;
        }

        static StackObject* Select_33(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.UI.Selectable instance_of_this_method = (UnityEngine.UI.Selectable)typeof(UnityEngine.UI.Selectable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Select();

            return __ret;
        }





    }
}
#endif
