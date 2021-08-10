
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
    unsafe class Unity_Profiling_LowLevel_MarkerFlags_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.LowLevel.MarkerFlags);

            field = type.GetField("Default", flag);
            app.RegisterCLRFieldGetter(field, get_Default_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Default_0, null);
            field = type.GetField("Script", flag);
            app.RegisterCLRFieldGetter(field, get_Script_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Script_1, null);
            field = type.GetField("ScriptInvoke", flag);
            app.RegisterCLRFieldGetter(field, get_ScriptInvoke_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_ScriptInvoke_2, null);
            field = type.GetField("ScriptDeepProfiler", flag);
            app.RegisterCLRFieldGetter(field, get_ScriptDeepProfiler_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_ScriptDeepProfiler_3, null);
            field = type.GetField("AvailabilityEditor", flag);
            app.RegisterCLRFieldGetter(field, get_AvailabilityEditor_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_AvailabilityEditor_4, null);
            field = type.GetField("Warning", flag);
            app.RegisterCLRFieldGetter(field, get_Warning_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_Warning_5, null);
            field = type.GetField("Counter", flag);
            app.RegisterCLRFieldGetter(field, get_Counter_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_Counter_6, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.LowLevel.MarkerFlags());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.LowLevel.MarkerFlags[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.LowLevel.MarkerFlags instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.LowLevel.MarkerFlags[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Default_0(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.Default;
        }

        static StackObject* CopyToStack_Default_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.Default;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Script_1(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.Script;
        }

        static StackObject* CopyToStack_Script_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.Script;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_ScriptInvoke_2(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.ScriptInvoke;
        }

        static StackObject* CopyToStack_ScriptInvoke_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.ScriptInvoke;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_ScriptDeepProfiler_3(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.ScriptDeepProfiler;
        }

        static StackObject* CopyToStack_ScriptDeepProfiler_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.ScriptDeepProfiler;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_AvailabilityEditor_4(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.AvailabilityEditor;
        }

        static StackObject* CopyToStack_AvailabilityEditor_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.AvailabilityEditor;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Warning_5(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.Warning;
        }

        static StackObject* CopyToStack_Warning_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.Warning;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Counter_6(ref object o)
        {
            return Unity.Profiling.LowLevel.MarkerFlags.Counter;
        }

        static StackObject* CopyToStack_Counter_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.MarkerFlags.Counter;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.LowLevel.MarkerFlags();
            ins = (Unity.Profiling.LowLevel.MarkerFlags)o;
            return ins;
        }


    }
}
#endif
