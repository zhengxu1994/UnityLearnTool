
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
    unsafe class Unity_Profiling_ProfilerFlowEventType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.ProfilerFlowEventType);

            field = type.GetField("Begin", flag);
            app.RegisterCLRFieldGetter(field, get_Begin_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Begin_0, null);
            field = type.GetField("ParallelNext", flag);
            app.RegisterCLRFieldGetter(field, get_ParallelNext_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_ParallelNext_1, null);
            field = type.GetField("End", flag);
            app.RegisterCLRFieldGetter(field, get_End_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_End_2, null);
            field = type.GetField("Next", flag);
            app.RegisterCLRFieldGetter(field, get_Next_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_Next_3, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.ProfilerFlowEventType());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.ProfilerFlowEventType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.ProfilerFlowEventType instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.ProfilerFlowEventType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Begin_0(ref object o)
        {
            return Unity.Profiling.ProfilerFlowEventType.Begin;
        }

        static StackObject* CopyToStack_Begin_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerFlowEventType.Begin;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_ParallelNext_1(ref object o)
        {
            return Unity.Profiling.ProfilerFlowEventType.ParallelNext;
        }

        static StackObject* CopyToStack_ParallelNext_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerFlowEventType.ParallelNext;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_End_2(ref object o)
        {
            return Unity.Profiling.ProfilerFlowEventType.End;
        }

        static StackObject* CopyToStack_End_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerFlowEventType.End;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Next_3(ref object o)
        {
            return Unity.Profiling.ProfilerFlowEventType.Next;
        }

        static StackObject* CopyToStack_Next_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.ProfilerFlowEventType.Next;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.ProfilerFlowEventType();
            ins = (Unity.Profiling.ProfilerFlowEventType)o;
            return ins;
        }


    }
}
#endif
