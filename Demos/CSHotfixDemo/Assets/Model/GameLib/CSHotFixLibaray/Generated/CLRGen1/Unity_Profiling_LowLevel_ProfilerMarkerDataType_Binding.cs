
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
    unsafe class Unity_Profiling_LowLevel_ProfilerMarkerDataType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.LowLevel.ProfilerMarkerDataType);

            field = type.GetField("Int32", flag);
            app.RegisterCLRFieldGetter(field, get_Int32_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Int32_0, null);
            field = type.GetField("UInt32", flag);
            app.RegisterCLRFieldGetter(field, get_UInt32_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_UInt32_1, null);
            field = type.GetField("Int64", flag);
            app.RegisterCLRFieldGetter(field, get_Int64_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Int64_2, null);
            field = type.GetField("UInt64", flag);
            app.RegisterCLRFieldGetter(field, get_UInt64_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_UInt64_3, null);
            field = type.GetField("Float", flag);
            app.RegisterCLRFieldGetter(field, get_Float_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_Float_4, null);
            field = type.GetField("Double", flag);
            app.RegisterCLRFieldGetter(field, get_Double_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_Double_5, null);
            field = type.GetField("String16", flag);
            app.RegisterCLRFieldGetter(field, get_String16_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_String16_6, null);
            field = type.GetField("Blob8", flag);
            app.RegisterCLRFieldGetter(field, get_Blob8_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_Blob8_7, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.LowLevel.ProfilerMarkerDataType());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.LowLevel.ProfilerMarkerDataType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.LowLevel.ProfilerMarkerDataType instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.LowLevel.ProfilerMarkerDataType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Int32_0(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.Int32;
        }

        static StackObject* CopyToStack_Int32_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.Int32;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_UInt32_1(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.UInt32;
        }

        static StackObject* CopyToStack_UInt32_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.UInt32;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Int64_2(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.Int64;
        }

        static StackObject* CopyToStack_Int64_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.Int64;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_UInt64_3(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.UInt64;
        }

        static StackObject* CopyToStack_UInt64_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.UInt64;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Float_4(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.Float;
        }

        static StackObject* CopyToStack_Float_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.Float;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Double_5(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.Double;
        }

        static StackObject* CopyToStack_Double_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.Double;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_String16_6(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.String16;
        }

        static StackObject* CopyToStack_String16_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.String16;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Blob8_7(ref object o)
        {
            return Unity.Profiling.LowLevel.ProfilerMarkerDataType.Blob8;
        }

        static StackObject* CopyToStack_Blob8_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = Unity.Profiling.LowLevel.ProfilerMarkerDataType.Blob8;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.LowLevel.ProfilerMarkerDataType();
            ins = (Unity.Profiling.LowLevel.ProfilerMarkerDataType)o;
            return ins;
        }


    }
}
#endif
