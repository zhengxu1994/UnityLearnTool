
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
    unsafe class GameDll_Const_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.Const);

            field = type.GetField("DEF_CHARACTER_POS_ADJUST_DIST", flag);
            app.RegisterCLRFieldGetter(field, get_DEF_CHARACTER_POS_ADJUST_DIST_0);
            app.RegisterCLRFieldSetter(field, set_DEF_CHARACTER_POS_ADJUST_DIST_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_DEF_CHARACTER_POS_ADJUST_DIST_0, AssignFromStack_DEF_CHARACTER_POS_ADJUST_DIST_0);
            field = type.GetField("DEF_CLIENT_ADJUST_POS_WARP_DIST", flag);
            app.RegisterCLRFieldGetter(field, get_DEF_CLIENT_ADJUST_POS_WARP_DIST_1);
            app.RegisterCLRFieldSetter(field, set_DEF_CLIENT_ADJUST_POS_WARP_DIST_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_DEF_CLIENT_ADJUST_POS_WARP_DIST_1, AssignFromStack_DEF_CLIENT_ADJUST_POS_WARP_DIST_1);
            field = type.GetField("BehaviroNone", flag);
            app.RegisterCLRFieldGetter(field, get_BehaviroNone_2);
            app.RegisterCLRFieldSetter(field, set_BehaviroNone_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_BehaviroNone_2, AssignFromStack_BehaviroNone_2);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.Const());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.Const[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_DEF_CHARACTER_POS_ADJUST_DIST_0(ref object o)
        {
            return GameDll.Const.DEF_CHARACTER_POS_ADJUST_DIST;
        }

        static StackObject* CopyToStack_DEF_CHARACTER_POS_ADJUST_DIST_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.Const.DEF_CHARACTER_POS_ADJUST_DIST;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_DEF_CHARACTER_POS_ADJUST_DIST_0(ref object o, object v)
        {
            GameDll.Const.DEF_CHARACTER_POS_ADJUST_DIST = (System.Single)v;
        }

        static StackObject* AssignFromStack_DEF_CHARACTER_POS_ADJUST_DIST_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @DEF_CHARACTER_POS_ADJUST_DIST = *(float*)&ptr_of_this_method->Value;
            GameDll.Const.DEF_CHARACTER_POS_ADJUST_DIST = @DEF_CHARACTER_POS_ADJUST_DIST;
            return ptr_of_this_method;
        }

        static object get_DEF_CLIENT_ADJUST_POS_WARP_DIST_1(ref object o)
        {
            return GameDll.Const.DEF_CLIENT_ADJUST_POS_WARP_DIST;
        }

        static StackObject* CopyToStack_DEF_CLIENT_ADJUST_POS_WARP_DIST_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.Const.DEF_CLIENT_ADJUST_POS_WARP_DIST;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_DEF_CLIENT_ADJUST_POS_WARP_DIST_1(ref object o, object v)
        {
            GameDll.Const.DEF_CLIENT_ADJUST_POS_WARP_DIST = (System.Single)v;
        }

        static StackObject* AssignFromStack_DEF_CLIENT_ADJUST_POS_WARP_DIST_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @DEF_CLIENT_ADJUST_POS_WARP_DIST = *(float*)&ptr_of_this_method->Value;
            GameDll.Const.DEF_CLIENT_ADJUST_POS_WARP_DIST = @DEF_CLIENT_ADJUST_POS_WARP_DIST;
            return ptr_of_this_method;
        }

        static object get_BehaviroNone_2(ref object o)
        {
            return GameDll.Const.BehaviroNone;
        }

        static StackObject* CopyToStack_BehaviroNone_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.Const.BehaviroNone;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_BehaviroNone_2(ref object o, object v)
        {
            GameDll.Const.BehaviroNone = (System.Int32)v;
        }

        static StackObject* AssignFromStack_BehaviroNone_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @BehaviroNone = ptr_of_this_method->Value;
            GameDll.Const.BehaviroNone = @BehaviroNone;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.Const();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
