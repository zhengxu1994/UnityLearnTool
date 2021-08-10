
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
    unsafe class LCL_SetLayer_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.SetLayer);
            args = new Type[]{};
            method = type.GetMethod("OnSetLayer", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OnSetLayer_0);

            field = type.GetField("m_Layer", flag);
            app.RegisterCLRFieldGetter(field, get_m_Layer_0);
            app.RegisterCLRFieldSetter(field, set_m_Layer_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Layer_0, AssignFromStack_m_Layer_0);
            field = type.GetField("m_Prefab", flag);
            app.RegisterCLRFieldGetter(field, get_m_Prefab_1);
            app.RegisterCLRFieldSetter(field, set_m_Prefab_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Prefab_1, AssignFromStack_m_Prefab_1);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.SetLayer());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.SetLayer[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* OnSetLayer_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            LCL.SetLayer instance_of_this_method = (LCL.SetLayer)typeof(LCL.SetLayer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.OnSetLayer();

            return __ret;
        }


        static object get_m_Layer_0(ref object o)
        {
            return ((LCL.SetLayer)o).m_Layer;
        }

        static StackObject* CopyToStack_m_Layer_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetLayer)o).m_Layer;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_Layer_0(ref object o, object v)
        {
            ((LCL.SetLayer)o).m_Layer = (System.String)v;
        }

        static StackObject* AssignFromStack_m_Layer_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @m_Layer = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetLayer)o).m_Layer = @m_Layer;
            return ptr_of_this_method;
        }

        static object get_m_Prefab_1(ref object o)
        {
            return ((LCL.SetLayer)o).m_Prefab;
        }

        static StackObject* CopyToStack_m_Prefab_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetLayer)o).m_Prefab;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_Prefab_1(ref object o, object v)
        {
            ((LCL.SetLayer)o).m_Prefab = (LCL.PrefabHolder)v;
        }

        static StackObject* AssignFromStack_m_Prefab_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            LCL.PrefabHolder @m_Prefab = (LCL.PrefabHolder)typeof(LCL.PrefabHolder).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetLayer)o).m_Prefab = @m_Prefab;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.SetLayer();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
