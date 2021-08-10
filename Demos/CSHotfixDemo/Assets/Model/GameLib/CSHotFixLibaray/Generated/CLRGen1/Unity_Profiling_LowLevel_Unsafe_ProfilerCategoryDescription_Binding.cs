
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
    unsafe class Unity_Profiling_LowLevel_Unsafe_ProfilerCategoryDescription_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription);
            args = new Type[]{};
            method = type.GetMethod("get_Name", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Name_0);

            field = type.GetField("Id", flag);
            app.RegisterCLRFieldGetter(field, get_Id_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Id_0, null);
            field = type.GetField("Color", flag);
            app.RegisterCLRFieldGetter(field, get_Color_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Color_1, null);
            field = type.GetField("NameUtf8Len", flag);
            app.RegisterCLRFieldGetter(field, get_NameUtf8Len_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_NameUtf8Len_2, null);
            field = type.GetField("NameUtf8", flag);
            app.RegisterCLRFieldGetter(field, get_NameUtf8_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_NameUtf8_3, null);

            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription());
            app.RegisterCLRCreateArrayInstance(type, s => new Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription instance_of_this_method)
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
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }

        static StackObject* get_Name_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription instance_of_this_method = (Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)typeof(Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));

            var result_of_this_method = instance_of_this_method.Name;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            WriteBackInstance(__domain, ptr_of_this_method, __mStack, ref instance_of_this_method);

            __intp.Free(ptr_of_this_method);
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_Id_0(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).Id;
        }

        static StackObject* CopyToStack_Id_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).Id;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static object get_Color_1(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).Color;
        }

        static StackObject* CopyToStack_Color_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).Color;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_NameUtf8Len_2(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).NameUtf8Len;
        }

        static StackObject* CopyToStack_NameUtf8Len_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).NameUtf8Len;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static object get_NameUtf8_3(ref object o)
        {
            return ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).NameUtf8;
        }

        static StackObject* CopyToStack_NameUtf8_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o).NameUtf8;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription();
            ins = (Unity.Profiling.LowLevel.Unsafe.ProfilerCategoryDescription)o;
            return ins;
        }


    }
}
#endif
