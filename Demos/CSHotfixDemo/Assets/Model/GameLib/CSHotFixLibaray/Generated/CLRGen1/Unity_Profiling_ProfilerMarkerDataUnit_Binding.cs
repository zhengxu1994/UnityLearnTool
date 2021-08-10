
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
    unsafe class Unity_Profiling_ProfilerMarkerDataUnit_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.ProfilerMarkerDataUnit);

            field = type.GetField("Undefined", flag);
            app.RegisterCLRFieldGetter(field, get_Undefined_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Undefined_0, null);
            field = type.GetField("TimeNanoseconds", flag);
            app.RegisterCLRFieldGetter(field, get_TimeNanoseconds_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_TimeNanoseconds_1, null);
            field = type.GetField("Bytes", flag);
            app.RegisterCLRFieldGetter(field, get_Bytes_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Bytes_2, null);
            field = type.GetField("Count", flag);
            app.RegisterCLRFieldGetter(field, get_Count_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_Count_3, null);
            field = type.GetField("Percent", flag);
            app.RegisterCLRFieldGetter(field, get_Percent_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_Percent_4, null);
            field = type.GetField("FrequencyHz", flag);
            app.RegisterCLRFieldGetter(field, get_FrequencyHz_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_FrequencyHz_5, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.ProfilerMarkerDataUnit());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.ProfilerMarkerDataUnit[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.ProfilerMarkerDataUnit instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.ProfilerMarkerDataUnit[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Undefined_0(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.Undefined;
        }

        static StackObject* CopyToStack_Undefined_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.Undefined;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_TimeNanoseconds_1(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.TimeNanoseconds;
        }

        static StackObject* CopyToStack_TimeNanoseconds_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.TimeNanoseconds;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Bytes_2(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.Bytes;
        }

        static StackObject* CopyToStack_Bytes_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.Bytes;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Count_3(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.Count;
        }

        static StackObject* CopyToStack_Count_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.Count;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Percent_4(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.Percent;
        }

        static StackObject* CopyToStack_Percent_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.Percent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_FrequencyHz_5(ref object o)
        {
            return Unity.Profiling.ProfilerMarkerDataUnit.FrequencyHz;
        }

        static StackObject* CopyToStack_FrequencyHz_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerMarkerDataUnit.FrequencyHz;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.ProfilerMarkerDataUnit();
            ins = (Unity.Profiling.ProfilerMarkerDataUnit)o;
            return ins;
        }


    }
}
#endif
