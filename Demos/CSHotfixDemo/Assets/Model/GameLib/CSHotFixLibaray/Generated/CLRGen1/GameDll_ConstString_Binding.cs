
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
    unsafe class GameDll_ConstString_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.ConstString);

            field = type.GetField("FenHao_Semicolon", flag);
            app.RegisterCLRFieldGetter(field, get_FenHao_Semicolon_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_FenHao_Semicolon_0, null);
            field = type.GetField("JiaHao_Plus", flag);
            app.RegisterCLRFieldGetter(field, get_JiaHao_Plus_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_JiaHao_Plus_1, null);
            field = type.GetField("Position", flag);
            app.RegisterCLRFieldGetter(field, get_Position_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Position_2, null);
            field = type.GetField("Distance", flag);
            app.RegisterCLRFieldGetter(field, get_Distance_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_Distance_3, null);
            field = type.GetField("Target", flag);
            app.RegisterCLRFieldGetter(field, get_Target_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_Target_4, null);
            field = type.GetField("NearstEnemy", flag);
            app.RegisterCLRFieldGetter(field, get_NearstEnemy_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_NearstEnemy_5, null);
            field = type.GetField("MinEnemy", flag);
            app.RegisterCLRFieldGetter(field, get_MinEnemy_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_MinEnemy_6, null);
            field = type.GetField("FollowObj", flag);
            app.RegisterCLRFieldGetter(field, get_FollowObj_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_FollowObj_7, null);
            field = type.GetField("Duration", flag);
            app.RegisterCLRFieldGetter(field, get_Duration_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_Duration_8, null);
            field = type.GetField("Speed", flag);
            app.RegisterCLRFieldGetter(field, get_Speed_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_Speed_9, null);
            field = type.GetField("Tree", flag);
            app.RegisterCLRFieldGetter(field, get_Tree_10);
            app.RegisterCLRFieldBinding(field, CopyToStack_Tree_10, null);
            field = type.GetField("AddPosition", flag);
            app.RegisterCLRFieldGetter(field, get_AddPosition_11);
            app.RegisterCLRFieldBinding(field, CopyToStack_AddPosition_11, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.ConstString());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.ConstString[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_FenHao_Semicolon_0(ref object o)
        {
            return GameDll.ConstString.FenHao_Semicolon;
        }

        static StackObject* CopyToStack_FenHao_Semicolon_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.FenHao_Semicolon;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static object get_JiaHao_Plus_1(ref object o)
        {
            return GameDll.ConstString.JiaHao_Plus;
        }

        static StackObject* CopyToStack_JiaHao_Plus_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.JiaHao_Plus;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static object get_Position_2(ref object o)
        {
            return GameDll.ConstString.Position;
        }

        static StackObject* CopyToStack_Position_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Position;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Distance_3(ref object o)
        {
            return GameDll.ConstString.Distance;
        }

        static StackObject* CopyToStack_Distance_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Distance;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Target_4(ref object o)
        {
            return GameDll.ConstString.Target;
        }

        static StackObject* CopyToStack_Target_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Target;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_NearstEnemy_5(ref object o)
        {
            return GameDll.ConstString.NearstEnemy;
        }

        static StackObject* CopyToStack_NearstEnemy_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.NearstEnemy;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_MinEnemy_6(ref object o)
        {
            return GameDll.ConstString.MinEnemy;
        }

        static StackObject* CopyToStack_MinEnemy_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.MinEnemy;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_FollowObj_7(ref object o)
        {
            return GameDll.ConstString.FollowObj;
        }

        static StackObject* CopyToStack_FollowObj_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.FollowObj;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Duration_8(ref object o)
        {
            return GameDll.ConstString.Duration;
        }

        static StackObject* CopyToStack_Duration_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Duration;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Speed_9(ref object o)
        {
            return GameDll.ConstString.Speed;
        }

        static StackObject* CopyToStack_Speed_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Speed;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_Tree_10(ref object o)
        {
            return GameDll.ConstString.Tree;
        }

        static StackObject* CopyToStack_Tree_10(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.Tree;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_AddPosition_11(ref object o)
        {
            return GameDll.ConstString.AddPosition;
        }

        static StackObject* CopyToStack_AddPosition_11(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.ConstString.AddPosition;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new GameDll.ConstString();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
