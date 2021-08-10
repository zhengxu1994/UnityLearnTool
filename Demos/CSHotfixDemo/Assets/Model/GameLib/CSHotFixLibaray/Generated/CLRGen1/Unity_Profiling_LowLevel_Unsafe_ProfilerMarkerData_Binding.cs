
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
    unsafe class Unity_Profiling_LowLevel_Unsafe_ProfilerMarkerData_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData);

            field = type.GetField("Type", flag);
            app.RegisterCLRFieldGetter(field, get_Type_0);
            app.RegisterCLRFieldSetter(field, set_Type_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Type_0, AssignFromStack_Type_0);
            field = type.GetField("Size", flag);
            app.RegisterCLRFieldGetter(field, get_Size_1);
            app.RegisterCLRFieldSetter(field, set_Size_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Size_1, AssignFromStack_Size_1);
            field = type.GetField("Ptr", flag);
            app.RegisterCLRFieldGetter(field, get_Ptr_2);
            app.RegisterCLRFieldSetter(field, set_Ptr_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Ptr_2, AssignFromStack_Ptr_2);

            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Type_0(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Type;
        }

        static StackObject* CopyToStack_Type_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Type;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Type_0(ref object o, object v)
        {
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Type = (System.Byte)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Type_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Byte @Type = (byte)ptr_of_this_method->Value;
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Type = @Type;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Size_1(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Size;
        }

        static StackObject* CopyToStack_Size_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Size;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static void set_Size_1(ref object o, object v)
        {
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Size = (System.UInt32)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Size_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.UInt32 @Size = (uint)ptr_of_this_method->Value;
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Size = @Size;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Ptr_2(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Ptr;
        }

        static StackObject* CopyToStack_Ptr_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o).Ptr;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Ptr_2(ref object o, object v)
        {
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Ptr = (System.Void*)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Ptr_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Void* @Ptr = (System.Void*)typeof(System.Void*).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData ins =(Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            ins.Ptr = @Ptr;
            o = ins;
            return ptr_of_this_method;
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData();
            ins = (Unity.Profiling.LowLevel.Unsafe.ProfilerMarkerData)o;
            return ins;
        }


    }
}
#endif
