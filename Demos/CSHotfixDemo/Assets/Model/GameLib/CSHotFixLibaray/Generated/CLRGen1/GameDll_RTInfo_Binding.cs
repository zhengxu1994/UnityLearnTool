
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
    unsafe class GameDll_RTInfo_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.RTInfo);

            field = type.GetField("m_bIsInUse", flag);
            app.RegisterCLRFieldGetter(field, get_m_bIsInUse_0);
            app.RegisterCLRFieldSetter(field, set_m_bIsInUse_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_bIsInUse_0, AssignFromStack_m_bIsInUse_0);
            field = type.GetField("m_RenderTexture", flag);
            app.RegisterCLRFieldGetter(field, get_m_RenderTexture_1);
            app.RegisterCLRFieldSetter(field, set_m_RenderTexture_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_RenderTexture_1, AssignFromStack_m_RenderTexture_1);
            field = type.GetField("m_Position", flag);
            app.RegisterCLRFieldGetter(field, get_m_Position_2);
            app.RegisterCLRFieldSetter(field, set_m_Position_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Position_2, AssignFromStack_m_Position_2);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.RTInfo());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.RTInfo[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_m_bIsInUse_0(ref object o)
        {
            return ((GameDll.RTInfo)o).m_bIsInUse;
        }

        static StackObject* CopyToStack_m_bIsInUse_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.RTInfo)o).m_bIsInUse;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_m_bIsInUse_0(ref object o, object v)
        {
            ((GameDll.RTInfo)o).m_bIsInUse = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_m_bIsInUse_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @m_bIsInUse = ptr_of_this_method->Value == 1;
            ((GameDll.RTInfo)o).m_bIsInUse = @m_bIsInUse;
            return ptr_of_this_method;
        }

        static object get_m_RenderTexture_1(ref object o)
        {
            return ((GameDll.RTInfo)o).m_RenderTexture;
        }

        static StackObject* CopyToStack_m_RenderTexture_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.RTInfo)o).m_RenderTexture;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_RenderTexture_1(ref object o, object v)
        {
            ((GameDll.RTInfo)o).m_RenderTexture = (UnityEngine.RenderTexture)v;
        }

        static StackObject* AssignFromStack_m_RenderTexture_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.RenderTexture @m_RenderTexture = (UnityEngine.RenderTexture)typeof(UnityEngine.RenderTexture).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.RTInfo)o).m_RenderTexture = @m_RenderTexture;
            return ptr_of_this_method;
        }

        static object get_m_Position_2(ref object o)
        {
            return ((GameDll.RTInfo)o).m_Position;
        }

        static StackObject* CopyToStack_m_Position_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.RTInfo)o).m_Position;
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_m_Position_2(ref object o, object v)
        {
            ((GameDll.RTInfo)o).m_Position = (UnityEngine.Vector3)v;
        }

        static StackObject* AssignFromStack_m_Position_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Vector3 @m_Position = new UnityEngine.Vector3();
            if (CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null) {
                CSHotFix.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @m_Position, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @m_Position = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            }
            ((GameDll.RTInfo)o).m_Position = @m_Position;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.RTInfo();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
