
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
    unsafe class Unity_Profiling_ProfilerRecorderSample_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(Unity.Profiling.ProfilerRecorderSample);
            args = new Type[]{};
            method = type.GetMethod("get_Value", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Value_0);
            args = new Type[]{};
            method = type.GetMethod("get_Count", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Count_1);


            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.ProfilerRecorderSample());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.ProfilerRecorderSample[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.ProfilerRecorderSample instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.ProfilerRecorderSample[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }

        static StackObject* get_Value_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            Unity.Profiling.ProfilerRecorderSample instance_of_this_method = (Unity.Profiling.ProfilerRecorderSample)typeof(Unity.Profiling.ProfilerRecorderSample).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            __ret->ObjectType = ObjectTypes.Long;
            *(long*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_Count_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            Unity.Profiling.ProfilerRecorderSample instance_of_this_method = (Unity.Profiling.ProfilerRecorderSample)typeof(Unity.Profiling.ProfilerRecorderSample).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.Count;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            __ret->ObjectType = ObjectTypes.Long;
            *(long*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }



        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.ProfilerRecorderSample();
            ins = (Unity.Profiling.ProfilerRecorderSample)o;
            return ins;
        }


    }
}
#endif
