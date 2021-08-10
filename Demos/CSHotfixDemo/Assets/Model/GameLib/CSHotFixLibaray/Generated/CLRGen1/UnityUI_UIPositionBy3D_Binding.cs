
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
    unsafe class UnityUI_UIPositionBy3D_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityUI.UIPositionBy3D);

            field = type.GetField("m_FromTransform", flag);
            app.RegisterCLRFieldGetter(field, get_m_FromTransform_0);
            app.RegisterCLRFieldSetter(field, set_m_FromTransform_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_FromTransform_0, AssignFromStack_m_FromTransform_0);
            field = type.GetField("m_SetTransrom", flag);
            app.RegisterCLRFieldGetter(field, get_m_SetTransrom_1);
            app.RegisterCLRFieldSetter(field, set_m_SetTransrom_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_SetTransrom_1, AssignFromStack_m_SetTransrom_1);
            field = type.GetField("m_Offset", flag);
            app.RegisterCLRFieldGetter(field, get_m_Offset_2);
            app.RegisterCLRFieldSetter(field, set_m_Offset_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Offset_2, AssignFromStack_m_Offset_2);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityUI.UIPositionBy3D());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityUI.UIPositionBy3D[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_m_FromTransform_0(ref object o)
        {
            return ((UnityUI.UIPositionBy3D)o).m_FromTransform;
        }

        static StackObject* CopyToStack_m_FromTransform_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIPositionBy3D)o).m_FromTransform;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_FromTransform_0(ref object o, object v)
        {
            ((UnityUI.UIPositionBy3D)o).m_FromTransform = (UnityEngine.Transform)v;
        }

        static StackObject* AssignFromStack_m_FromTransform_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Transform @m_FromTransform = (UnityEngine.Transform)typeof(UnityEngine.Transform).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIPositionBy3D)o).m_FromTransform = @m_FromTransform;
            return ptr_of_this_method;
        }

        static object get_m_SetTransrom_1(ref object o)
        {
            return ((UnityUI.UIPositionBy3D)o).m_SetTransrom;
        }

        static StackObject* CopyToStack_m_SetTransrom_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIPositionBy3D)o).m_SetTransrom;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_SetTransrom_1(ref object o, object v)
        {
            ((UnityUI.UIPositionBy3D)o).m_SetTransrom = (UnityEngine.Transform)v;
        }

        static StackObject* AssignFromStack_m_SetTransrom_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Transform @m_SetTransrom = (UnityEngine.Transform)typeof(UnityEngine.Transform).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIPositionBy3D)o).m_SetTransrom = @m_SetTransrom;
            return ptr_of_this_method;
        }

        static object get_m_Offset_2(ref object o)
        {
            return ((UnityUI.UIPositionBy3D)o).m_Offset;
        }

        static StackObject* CopyToStack_m_Offset_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIPositionBy3D)o).m_Offset;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_m_Offset_2(ref object o, object v)
        {
            ((UnityUI.UIPositionBy3D)o).m_Offset = (UnityEngine.Vector2)v;
        }

        static StackObject* AssignFromStack_m_Offset_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector2 @m_Offset = new UnityEngine.Vector2();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector2_Binding_Binder.ParseValue(ref @m_Offset, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @m_Offset = (UnityEngine.Vector2)typeof(UnityEngine.Vector2).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            ((UnityUI.UIPositionBy3D)o).m_Offset = @m_Offset;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new UnityUI.UIPositionBy3D();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
