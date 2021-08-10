
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
    unsafe class LCL_ABObject_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.ABObject);
            args = new Type[]{typeof(System.Object)};
            method = type.GetMethod("New", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, New_0);
            args = new Type[]{};
            method = type.GetMethod("DestroyClass", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, DestroyClass_1);

            field = type.GetField("m_UObjectList", flag);
            app.RegisterCLRFieldGetter(field, get_m_UObjectList_0);
            app.RegisterCLRFieldSetter(field, set_m_UObjectList_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_UObjectList_0, AssignFromStack_m_UObjectList_0);
            field = type.GetField("m_Id", flag);
            app.RegisterCLRFieldGetter(field, get_m_Id_1);
            app.RegisterCLRFieldSetter(field, set_m_Id_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Id_1, AssignFromStack_m_Id_1);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.ABObject());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.ABObject[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* New_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @param = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            LCL.ABObject instance_of_this_method = (LCL.ABObject)typeof(LCL.ABObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.New(@param);

            return __ret;
        }

        static StackObject* DestroyClass_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            LCL.ABObject instance_of_this_method = (LCL.ABObject)typeof(LCL.ABObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.DestroyClass();

            return __ret;
        }


        static object get_m_UObjectList_0(ref object o)
        {
            return ((LCL.ABObject)o).m_UObjectList;
        }

        static StackObject* CopyToStack_m_UObjectList_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.ABObject)o).m_UObjectList;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_UObjectList_0(ref object o, object v)
        {
            ((LCL.ABObject)o).m_UObjectList = (System.Collections.Generic.List<UnityEngine.Object>)v;
        }

        static StackObject* AssignFromStack_m_UObjectList_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Collections.Generic.List<UnityEngine.Object> @m_UObjectList = (System.Collections.Generic.List<UnityEngine.Object>)typeof(System.Collections.Generic.List<UnityEngine.Object>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.ABObject)o).m_UObjectList = @m_UObjectList;
            return ptr_of_this_method;
        }

        static object get_m_Id_1(ref object o)
        {
            return ((LCL.ABObject)o).m_Id;
        }

        static StackObject* CopyToStack_m_Id_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.ABObject)o).m_Id;
            __ret->ObjectType = ObjectTypes.Long;
            *(long*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_Id_1(ref object o, object v)
        {
            ((LCL.ABObject)o).m_Id = (System.Int64)v;
        }

        static StackObject* AssignFromStack_m_Id_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int64 @m_Id = *(long*)&ptr_of_this_method->Value;
            ((LCL.ABObject)o).m_Id = @m_Id;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.ABObject();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
