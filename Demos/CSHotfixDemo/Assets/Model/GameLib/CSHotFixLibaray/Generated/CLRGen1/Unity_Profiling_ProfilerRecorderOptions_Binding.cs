
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
    unsafe class Unity_Profiling_ProfilerRecorderOptions_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.ProfilerRecorderOptions);

            field = type.GetField("None", flag);
            app.RegisterCLRFieldGetter(field, get_None_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_None_0, null);
            field = type.GetField("StartImmediately", flag);
            app.RegisterCLRFieldGetter(field, get_StartImmediately_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_StartImmediately_1, null);
            field = type.GetField("KeepAliveDuringDomainReload", flag);
            app.RegisterCLRFieldGetter(field, get_KeepAliveDuringDomainReload_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_KeepAliveDuringDomainReload_2, null);
            field = type.GetField("CollectOnlyOnCurrentThread", flag);
            app.RegisterCLRFieldGetter(field, get_CollectOnlyOnCurrentThread_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_CollectOnlyOnCurrentThread_3, null);
            field = type.GetField("WrapAroundWhenCapacityReached", flag);
            app.RegisterCLRFieldGetter(field, get_WrapAroundWhenCapacityReached_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_WrapAroundWhenCapacityReached_4, null);
            field = type.GetField("SumAllSamplesInFrame", flag);
            app.RegisterCLRFieldGetter(field, get_SumAllSamplesInFrame_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_SumAllSamplesInFrame_5, null);
            field = type.GetField("Default", flag);
            app.RegisterCLRFieldGetter(field, get_Default_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_Default_6, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.ProfilerRecorderOptions());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.ProfilerRecorderOptions[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.ProfilerRecorderOptions instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.ProfilerRecorderOptions[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_None_0(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.None;
        }

        static StackObject* CopyToStack_None_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.None;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_StartImmediately_1(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.StartImmediately;
        }

        static StackObject* CopyToStack_StartImmediately_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.StartImmediately;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_KeepAliveDuringDomainReload_2(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.KeepAliveDuringDomainReload;
        }

        static StackObject* CopyToStack_KeepAliveDuringDomainReload_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.KeepAliveDuringDomainReload;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_CollectOnlyOnCurrentThread_3(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.CollectOnlyOnCurrentThread;
        }

        static StackObject* CopyToStack_CollectOnlyOnCurrentThread_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.CollectOnlyOnCurrentThread;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_WrapAroundWhenCapacityReached_4(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.WrapAroundWhenCapacityReached;
        }

        static StackObject* CopyToStack_WrapAroundWhenCapacityReached_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.WrapAroundWhenCapacityReached;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_SumAllSamplesInFrame_5(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.SumAllSamplesInFrame;
        }

        static StackObject* CopyToStack_SumAllSamplesInFrame_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.SumAllSamplesInFrame;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Default_6(ref object o)
        {
            return Unity.Profiling.ProfilerRecorderOptions.Default;
        }

        static StackObject* CopyToStack_Default_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerRecorderOptions.Default;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.ProfilerRecorderOptions();
            ins = (Unity.Profiling.ProfilerRecorderOptions)o;
            return ins;
        }


    }
}
#endif
