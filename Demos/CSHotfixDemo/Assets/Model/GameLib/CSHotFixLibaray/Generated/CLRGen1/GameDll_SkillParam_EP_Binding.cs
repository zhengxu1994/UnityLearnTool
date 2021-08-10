
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
    unsafe class GameDll_SkillParam_EP_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.SkillParam_EP);
            args = new Type[]{};
            method = type.GetMethod("DestroyClass", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, DestroyClass_0);
            args = new Type[]{typeof(System.Object)};
            method = type.GetMethod("New", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, New_1);

            field = type.GetField("m_CasterId", flag);
            app.RegisterCLRFieldGetter(field, get_m_CasterId_0);
            app.RegisterCLRFieldSetter(field, set_m_CasterId_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_CasterId_0, AssignFromStack_m_CasterId_0);
            field = type.GetField("m_TargetId", flag);
            app.RegisterCLRFieldGetter(field, get_m_TargetId_1);
            app.RegisterCLRFieldSetter(field, set_m_TargetId_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_TargetId_1, AssignFromStack_m_TargetId_1);
            field = type.GetField("m_SkillId", flag);
            app.RegisterCLRFieldGetter(field, get_m_SkillId_2);
            app.RegisterCLRFieldSetter(field, set_m_SkillId_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_SkillId_2, AssignFromStack_m_SkillId_2);
            field = type.GetField("m_x", flag);
            app.RegisterCLRFieldGetter(field, get_m_x_3);
            app.RegisterCLRFieldSetter(field, set_m_x_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_x_3, AssignFromStack_m_x_3);
            field = type.GetField("m_z", flag);
            app.RegisterCLRFieldGetter(field, get_m_z_4);
            app.RegisterCLRFieldSetter(field, set_m_z_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_z_4, AssignFromStack_m_z_4);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.SkillParam_EP());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.SkillParam_EP[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* DestroyClass_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            GameDll.SkillParam_EP instance_of_this_method = (GameDll.SkillParam_EP)typeof(GameDll.SkillParam_EP).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.DestroyClass();

            return __ret;
        }

        static StackObject* New_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @param = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            GameDll.SkillParam_EP instance_of_this_method = (GameDll.SkillParam_EP)typeof(GameDll.SkillParam_EP).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.New(@param);

            return __ret;
        }


        static object get_m_CasterId_0(ref object o)
        {
            return ((GameDll.SkillParam_EP)o).m_CasterId;
        }

        static StackObject* CopyToStack_m_CasterId_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.SkillParam_EP)o).m_CasterId;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_CasterId_0(ref object o, object v)
        {
            ((GameDll.SkillParam_EP)o).m_CasterId = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_CasterId_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_CasterId = ptr_of_this_method->Value;
            ((GameDll.SkillParam_EP)o).m_CasterId = @m_CasterId;
            return ptr_of_this_method;
        }

        static object get_m_TargetId_1(ref object o)
        {
            return ((GameDll.SkillParam_EP)o).m_TargetId;
        }

        static StackObject* CopyToStack_m_TargetId_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.SkillParam_EP)o).m_TargetId;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_TargetId_1(ref object o, object v)
        {
            ((GameDll.SkillParam_EP)o).m_TargetId = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_TargetId_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_TargetId = ptr_of_this_method->Value;
            ((GameDll.SkillParam_EP)o).m_TargetId = @m_TargetId;
            return ptr_of_this_method;
        }

        static object get_m_SkillId_2(ref object o)
        {
            return ((GameDll.SkillParam_EP)o).m_SkillId;
        }

        static StackObject* CopyToStack_m_SkillId_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.SkillParam_EP)o).m_SkillId;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static void set_m_SkillId_2(ref object o, object v)
        {
            ((GameDll.SkillParam_EP)o).m_SkillId = (System.UInt32)v;
        }

        static StackObject* AssignFromStack_m_SkillId_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.UInt32 @m_SkillId = (uint)ptr_of_this_method->Value;
            ((GameDll.SkillParam_EP)o).m_SkillId = @m_SkillId;
            return ptr_of_this_method;
        }

        static object get_m_x_3(ref object o)
        {
            return ((GameDll.SkillParam_EP)o).m_x;
        }

        static StackObject* CopyToStack_m_x_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.SkillParam_EP)o).m_x;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_x_3(ref object o, object v)
        {
            ((GameDll.SkillParam_EP)o).m_x = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_x_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_x = ptr_of_this_method->Value;
            ((GameDll.SkillParam_EP)o).m_x = @m_x;
            return ptr_of_this_method;
        }

        static object get_m_z_4(ref object o)
        {
            return ((GameDll.SkillParam_EP)o).m_z;
        }

        static StackObject* CopyToStack_m_z_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.SkillParam_EP)o).m_z;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_z_4(ref object o, object v)
        {
            ((GameDll.SkillParam_EP)o).m_z = (System.Int32)v;
        }

        static StackObject* AssignFromStack_m_z_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @m_z = ptr_of_this_method->Value;
            ((GameDll.SkillParam_EP)o).m_z = @m_z;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.SkillParam_EP();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
