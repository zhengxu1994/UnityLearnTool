
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
    unsafe class UnityEngine_EventSystems_RaycastResult_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityEngine.EventSystems.RaycastResult);
            args = new Type[]{};
            method = type.GetMethod("get_gameObject", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_gameObject_0);
            args = new Type[]{typeof(UnityEngine.GameObject)};
            method = type.GetMethod("set_gameObject", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_gameObject_1);
            args = new Type[]{};
            method = type.GetMethod("get_isValid", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_isValid_2);
            args = new Type[]{};
            method = type.GetMethod("Clear", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Clear_3);
            args = new Type[]{};
            method = type.GetMethod("ToString", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ToString_4);

            field = type.GetField("module", flag);
            app.RegisterCLRFieldGetter(field, get_module_0);
            app.RegisterCLRFieldSetter(field, set_module_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_module_0, AssignFromStack_module_0);
            field = type.GetField("distance", flag);
            app.RegisterCLRFieldGetter(field, get_distance_1);
            app.RegisterCLRFieldSetter(field, set_distance_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_distance_1, AssignFromStack_distance_1);
            field = type.GetField("index", flag);
            app.RegisterCLRFieldGetter(field, get_index_2);
            app.RegisterCLRFieldSetter(field, set_index_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_index_2, AssignFromStack_index_2);
            field = type.GetField("depth", flag);
            app.RegisterCLRFieldGetter(field, get_depth_3);
            app.RegisterCLRFieldSetter(field, set_depth_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_depth_3, AssignFromStack_depth_3);
            field = type.GetField("sortingLayer", flag);
            app.RegisterCLRFieldGetter(field, get_sortingLayer_4);
            app.RegisterCLRFieldSetter(field, set_sortingLayer_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_sortingLayer_4, AssignFromStack_sortingLayer_4);
            field = type.GetField("sortingOrder", flag);
            app.RegisterCLRFieldGetter(field, get_sortingOrder_5);
            app.RegisterCLRFieldSetter(field, set_sortingOrder_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_sortingOrder_5, AssignFromStack_sortingOrder_5);
            field = type.GetField("worldPosition", flag);
            app.RegisterCLRFieldGetter(field, get_worldPosition_6);
            app.RegisterCLRFieldSetter(field, set_worldPosition_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_worldPosition_6, AssignFromStack_worldPosition_6);
            field = type.GetField("worldNormal", flag);
            app.RegisterCLRFieldGetter(field, get_worldNormal_7);
            app.RegisterCLRFieldSetter(field, set_worldNormal_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_worldNormal_7, AssignFromStack_worldNormal_7);
            field = type.GetField("screenPosition", flag);
            app.RegisterCLRFieldGetter(field, get_screenPosition_8);
            app.RegisterCLRFieldSetter(field, set_screenPosition_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_screenPosition_8, AssignFromStack_screenPosition_8);
            field = type.GetField("displayIndex", flag);
            app.RegisterCLRFieldGetter(field, get_displayIndex_9);
            app.RegisterCLRFieldSetter(field, set_displayIndex_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_displayIndex_9, AssignFromStack_displayIndex_9);

            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new UnityEngine.EventSystems.RaycastResult());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityEngine.EventSystems.RaycastResult[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref UnityEngine.EventSystems.RaycastResult instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as UnityEngine.EventSystems.RaycastResult[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }

        static StackObject* get_gameObject_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            UnityEngine.EventSystems.RaycastResult instance_of_this_method = (UnityEngine.EventSystems.RaycastResult)typeof(UnityEngine.EventSystems.RaycastResult).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.gameObject;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_gameObject_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.GameObject @value = (UnityEngine.GameObject)typeof(UnityEngine.GameObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            UnityEngine.EventSystems.RaycastResult instance_of_this_method = (UnityEngine.EventSystems.RaycastResult)typeof(UnityEngine.EventSystems.RaycastResult).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            instance_of_this_method.gameObject = value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            return __ret;
        }

        static StackObject* get_isValid_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            UnityEngine.EventSystems.RaycastResult instance_of_this_method = (UnityEngine.EventSystems.RaycastResult)typeof(UnityEngine.EventSystems.RaycastResult).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.isValid;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* Clear_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            UnityEngine.EventSystems.RaycastResult instance_of_this_method = (UnityEngine.EventSystems.RaycastResult)typeof(UnityEngine.EventSystems.RaycastResult).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            instance_of_this_method.Clear();

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            return __ret;
        }

        static StackObject* ToString_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            UnityEngine.EventSystems.RaycastResult instance_of_this_method = (UnityEngine.EventSystems.RaycastResult)typeof(UnityEngine.EventSystems.RaycastResult).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.ToString();

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_module_0(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).module;
        }

        static StackObject* CopyToStack_module_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).module;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_module_0(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.module = (UnityEngine.EventSystems.BaseRaycaster)v;
            o = ins;
        }

        static StackObject* AssignFromStack_module_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.EventSystems.BaseRaycaster @module = (UnityEngine.EventSystems.BaseRaycaster)typeof(UnityEngine.EventSystems.BaseRaycaster).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.module = @module;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_distance_1(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).distance;
        }

        static StackObject* CopyToStack_distance_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).distance;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_distance_1(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.distance = (System.Single)v;
            o = ins;
        }

        static StackObject* AssignFromStack_distance_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @distance = *(float*)&ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.distance = @distance;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_index_2(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).index;
        }

        static StackObject* CopyToStack_index_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).index;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_index_2(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.index = (System.Single)v;
            o = ins;
        }

        static StackObject* AssignFromStack_index_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @index = *(float*)&ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.index = @index;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_depth_3(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).depth;
        }

        static StackObject* CopyToStack_depth_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).depth;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_depth_3(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.depth = (System.Int32)v;
            o = ins;
        }

        static StackObject* AssignFromStack_depth_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @depth = ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.depth = @depth;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_sortingLayer_4(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).sortingLayer;
        }

        static StackObject* CopyToStack_sortingLayer_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).sortingLayer;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_sortingLayer_4(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.sortingLayer = (System.Int32)v;
            o = ins;
        }

        static StackObject* AssignFromStack_sortingLayer_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @sortingLayer = ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.sortingLayer = @sortingLayer;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_sortingOrder_5(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).sortingOrder;
        }

        static StackObject* CopyToStack_sortingOrder_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).sortingOrder;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_sortingOrder_5(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.sortingOrder = (System.Int32)v;
            o = ins;
        }

        static StackObject* AssignFromStack_sortingOrder_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @sortingOrder = ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.sortingOrder = @sortingOrder;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_worldPosition_6(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).worldPosition;
        }

        static StackObject* CopyToStack_worldPosition_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).worldPosition;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_worldPosition_6(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.worldPosition = (UnityEngine.Vector3)v;
            o = ins;
        }

        static StackObject* AssignFromStack_worldPosition_6(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector3 @worldPosition = new UnityEngine.Vector3();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @worldPosition, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @worldPosition = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.worldPosition = @worldPosition;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_worldNormal_7(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).worldNormal;
        }

        static StackObject* CopyToStack_worldNormal_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).worldNormal;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_worldNormal_7(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.worldNormal = (UnityEngine.Vector3)v;
            o = ins;
        }

        static StackObject* AssignFromStack_worldNormal_7(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector3 @worldNormal = new UnityEngine.Vector3();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @worldNormal, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @worldNormal = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.worldNormal = @worldNormal;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_screenPosition_8(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).screenPosition;
        }

        static StackObject* CopyToStack_screenPosition_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).screenPosition;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_screenPosition_8(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.screenPosition = (UnityEngine.Vector2)v;
            o = ins;
        }

        static StackObject* AssignFromStack_screenPosition_8(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector2 @screenPosition = new UnityEngine.Vector2();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.ParseValue(ref @screenPosition, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @screenPosition = (UnityEngine.Vector2)typeof(UnityEngine.Vector2).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.screenPosition = @screenPosition;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_displayIndex_9(ref object o)
        {
            return ((UnityEngine.EventSystems.RaycastResult)o).displayIndex;
        }

        static StackObject* CopyToStack_displayIndex_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityEngine.EventSystems.RaycastResult)o).displayIndex;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_displayIndex_9(ref object o, object v)
        {
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.displayIndex = (System.Int32)v;
            o = ins;
        }

        static StackObject* AssignFromStack_displayIndex_9(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @displayIndex = ptr_of_this_method->Value;
            UnityEngine.EventSystems.RaycastResult ins =(UnityEngine.EventSystems.RaycastResult)o;
            ins.displayIndex = @displayIndex;
            o = ins;
            return ptr_of_this_method;
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new UnityEngine.EventSystems.RaycastResult();
            ins = (UnityEngine.EventSystems.RaycastResult)o;
            return ins;
        }


    }
}
#endif
