
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
    unsafe class GameDll_Timer_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.Timer);
            args = new Type[]{};
            method = type.GetMethod("CreateClass", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CreateClass_0);
            args = new Type[]{typeof(System.Object)};
            method = type.GetMethod("New", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, New_1);
            args = new Type[]{};
            method = type.GetMethod("Delete", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Delete_2);
            args = new Type[]{};
            method = type.GetMethod("DestroyClass", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, DestroyClass_3);
            args = new Type[]{};
            method = type.GetMethod("GetId", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetId_4);

            field = type.GetField("perCall", flag);
            app.RegisterCLRFieldGetter(field, get_perCall_0);
            app.RegisterCLRFieldSetter(field, set_perCall_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_perCall_0, AssignFromStack_perCall_0);
            field = type.GetField("finishCall", flag);
            app.RegisterCLRFieldGetter(field, get_finishCall_1);
            app.RegisterCLRFieldSetter(field, set_finishCall_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_finishCall_1, AssignFromStack_finishCall_1);
            field = type.GetField("intervalMMSeconds", flag);
            app.RegisterCLRFieldGetter(field, get_intervalMMSeconds_2);
            app.RegisterCLRFieldSetter(field, set_intervalMMSeconds_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_intervalMMSeconds_2, AssignFromStack_intervalMMSeconds_2);
            field = type.GetField("totalMMSeconds", flag);
            app.RegisterCLRFieldGetter(field, get_totalMMSeconds_3);
            app.RegisterCLRFieldSetter(field, set_totalMMSeconds_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_totalMMSeconds_3, AssignFromStack_totalMMSeconds_3);
            field = type.GetField("currTick", flag);
            app.RegisterCLRFieldGetter(field, get_currTick_4);
            app.RegisterCLRFieldSetter(field, set_currTick_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_currTick_4, AssignFromStack_currTick_4);
            field = type.GetField("IntervalPastTime", flag);
            app.RegisterCLRFieldGetter(field, get_IntervalPastTime_5);
            app.RegisterCLRFieldSetter(field, set_IntervalPastTime_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_IntervalPastTime_5, AssignFromStack_IntervalPastTime_5);
            field = type.GetField("userData", flag);
            app.RegisterCLRFieldGetter(field, get_userData_6);
            app.RegisterCLRFieldSetter(field, set_userData_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_userData_6, AssignFromStack_userData_6);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.Timer());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.Timer[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* CreateClass_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = GameDll.Timer.CreateClass();

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
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
            GameDll.Timer instance_of_this_method = (GameDll.Timer)typeof(GameDll.Timer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.New(@param);

            return __ret;
        }

        static StackObject* Delete_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            GameDll.Timer instance_of_this_method = (GameDll.Timer)typeof(GameDll.Timer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Delete();

            return __ret;
        }

        static StackObject* DestroyClass_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            GameDll.Timer instance_of_this_method = (GameDll.Timer)typeof(GameDll.Timer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.DestroyClass();

            return __ret;
        }

        static StackObject* GetId_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            GameDll.Timer instance_of_this_method = (GameDll.Timer)typeof(GameDll.Timer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetId();

            __ret->ObjectType = ObjectTypes.Long;
            *(long*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }


        static object get_perCall_0(ref object o)
        {
            return ((GameDll.Timer)o).perCall;
        }

        static StackObject* CopyToStack_perCall_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).perCall;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_perCall_0(ref object o, object v)
        {
            ((GameDll.Timer)o).perCall = (System.Action<System.Int32>)v;
        }

        static StackObject* AssignFromStack_perCall_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.Int32> @perCall = (System.Action<System.Int32>)typeof(System.Action<System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Timer)o).perCall = @perCall;
            return ptr_of_this_method;
        }

        static object get_finishCall_1(ref object o)
        {
            return ((GameDll.Timer)o).finishCall;
        }

        static StackObject* CopyToStack_finishCall_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).finishCall;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_finishCall_1(ref object o, object v)
        {
            ((GameDll.Timer)o).finishCall = (System.Action)v;
        }

        static StackObject* AssignFromStack_finishCall_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @finishCall = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Timer)o).finishCall = @finishCall;
            return ptr_of_this_method;
        }

        static object get_intervalMMSeconds_2(ref object o)
        {
            return ((GameDll.Timer)o).intervalMMSeconds;
        }

        static StackObject* CopyToStack_intervalMMSeconds_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).intervalMMSeconds;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_intervalMMSeconds_2(ref object o, object v)
        {
            ((GameDll.Timer)o).intervalMMSeconds = (System.Int32)v;
        }

        static StackObject* AssignFromStack_intervalMMSeconds_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @intervalMMSeconds = ptr_of_this_method->Value;
            ((GameDll.Timer)o).intervalMMSeconds = @intervalMMSeconds;
            return ptr_of_this_method;
        }

        static object get_totalMMSeconds_3(ref object o)
        {
            return ((GameDll.Timer)o).totalMMSeconds;
        }

        static StackObject* CopyToStack_totalMMSeconds_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).totalMMSeconds;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_totalMMSeconds_3(ref object o, object v)
        {
            ((GameDll.Timer)o).totalMMSeconds = (System.Int32)v;
        }

        static StackObject* AssignFromStack_totalMMSeconds_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @totalMMSeconds = ptr_of_this_method->Value;
            ((GameDll.Timer)o).totalMMSeconds = @totalMMSeconds;
            return ptr_of_this_method;
        }

        static object get_currTick_4(ref object o)
        {
            return ((GameDll.Timer)o).currTick;
        }

        static StackObject* CopyToStack_currTick_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).currTick;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_currTick_4(ref object o, object v)
        {
            ((GameDll.Timer)o).currTick = (System.Int32)v;
        }

        static StackObject* AssignFromStack_currTick_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @currTick = ptr_of_this_method->Value;
            ((GameDll.Timer)o).currTick = @currTick;
            return ptr_of_this_method;
        }

        static object get_IntervalPastTime_5(ref object o)
        {
            return ((GameDll.Timer)o).IntervalPastTime;
        }

        static StackObject* CopyToStack_IntervalPastTime_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).IntervalPastTime;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_IntervalPastTime_5(ref object o, object v)
        {
            ((GameDll.Timer)o).IntervalPastTime = (System.Int32)v;
        }

        static StackObject* AssignFromStack_IntervalPastTime_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @IntervalPastTime = ptr_of_this_method->Value;
            ((GameDll.Timer)o).IntervalPastTime = @IntervalPastTime;
            return ptr_of_this_method;
        }

        static object get_userData_6(ref object o)
        {
            return ((GameDll.Timer)o).userData;
        }

        static StackObject* CopyToStack_userData_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((GameDll.Timer)o).userData;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance, true);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method, true);
        }

        static void set_userData_6(ref object o, object v)
        {
            ((GameDll.Timer)o).userData = (System.Object)v;
        }

        static StackObject* AssignFromStack_userData_6(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Object @userData = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((GameDll.Timer)o).userData = @userData;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.Timer();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
