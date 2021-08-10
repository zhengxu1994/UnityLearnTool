
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
    unsafe class LCL_AfterImageEffects_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.AfterImageEffects);

            field = type.GetField("_OpenAfterImage", flag);
            app.RegisterCLRFieldGetter(field, get__OpenAfterImage_0);
            app.RegisterCLRFieldSetter(field, set__OpenAfterImage_0);
            app.RegisterCLRFieldBinding(field, CopyToStack__OpenAfterImage_0, AssignFromStack__OpenAfterImage_0);
            field = type.GetField("_AfterImageColor", flag);
            app.RegisterCLRFieldGetter(field, get__AfterImageColor_1);
            app.RegisterCLRFieldSetter(field, set__AfterImageColor_1);
            app.RegisterCLRFieldBinding(field, CopyToStack__AfterImageColor_1, AssignFromStack__AfterImageColor_1);
            field = type.GetField("_SurvivalTime", flag);
            app.RegisterCLRFieldGetter(field, get__SurvivalTime_2);
            app.RegisterCLRFieldSetter(field, set__SurvivalTime_2);
            app.RegisterCLRFieldBinding(field, CopyToStack__SurvivalTime_2, AssignFromStack__SurvivalTime_2);
            field = type.GetField("_IntervalTime", flag);
            app.RegisterCLRFieldGetter(field, get__IntervalTime_3);
            app.RegisterCLRFieldSetter(field, set__IntervalTime_3);
            app.RegisterCLRFieldBinding(field, CopyToStack__IntervalTime_3, AssignFromStack__IntervalTime_3);
            field = type.GetField("_InitialAlpha", flag);
            app.RegisterCLRFieldGetter(field, get__InitialAlpha_4);
            app.RegisterCLRFieldSetter(field, set__InitialAlpha_4);
            app.RegisterCLRFieldBinding(field, CopyToStack__InitialAlpha_4, AssignFromStack__InitialAlpha_4);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.AfterImageEffects());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.AfterImageEffects[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get__OpenAfterImage_0(ref object o)
        {
            return ((LCL.AfterImageEffects)o)._OpenAfterImage;
        }

        static StackObject* CopyToStack__OpenAfterImage_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.AfterImageEffects)o)._OpenAfterImage;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set__OpenAfterImage_0(ref object o, object v)
        {
            ((LCL.AfterImageEffects)o)._OpenAfterImage = (System.Boolean)v;
        }

        static StackObject* AssignFromStack__OpenAfterImage_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @_OpenAfterImage = ptr_of_this_method->Value == 1;
            ((LCL.AfterImageEffects)o)._OpenAfterImage = @_OpenAfterImage;
            return ptr_of_this_method;
        }

        static object get__AfterImageColor_1(ref object o)
        {
            return ((LCL.AfterImageEffects)o)._AfterImageColor;
        }

        static StackObject* CopyToStack__AfterImageColor_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.AfterImageEffects)o)._AfterImageColor;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set__AfterImageColor_1(ref object o, object v)
        {
            ((LCL.AfterImageEffects)o)._AfterImageColor = (UnityEngine.Color)v;
        }

        static StackObject* AssignFromStack__AfterImageColor_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Color @_AfterImageColor = (UnityEngine.Color)typeof(UnityEngine.Color).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.AfterImageEffects)o)._AfterImageColor = @_AfterImageColor;
            return ptr_of_this_method;
        }

        static object get__SurvivalTime_2(ref object o)
        {
            return ((LCL.AfterImageEffects)o)._SurvivalTime;
        }

        static StackObject* CopyToStack__SurvivalTime_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.AfterImageEffects)o)._SurvivalTime;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set__SurvivalTime_2(ref object o, object v)
        {
            ((LCL.AfterImageEffects)o)._SurvivalTime = (System.Single)v;
        }

        static StackObject* AssignFromStack__SurvivalTime_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @_SurvivalTime = *(float*)&ptr_of_this_method->Value;
            ((LCL.AfterImageEffects)o)._SurvivalTime = @_SurvivalTime;
            return ptr_of_this_method;
        }

        static object get__IntervalTime_3(ref object o)
        {
            return ((LCL.AfterImageEffects)o)._IntervalTime;
        }

        static StackObject* CopyToStack__IntervalTime_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.AfterImageEffects)o)._IntervalTime;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set__IntervalTime_3(ref object o, object v)
        {
            ((LCL.AfterImageEffects)o)._IntervalTime = (System.Single)v;
        }

        static StackObject* AssignFromStack__IntervalTime_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @_IntervalTime = *(float*)&ptr_of_this_method->Value;
            ((LCL.AfterImageEffects)o)._IntervalTime = @_IntervalTime;
            return ptr_of_this_method;
        }

        static object get__InitialAlpha_4(ref object o)
        {
            return ((LCL.AfterImageEffects)o)._InitialAlpha;
        }

        static StackObject* CopyToStack__InitialAlpha_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.AfterImageEffects)o)._InitialAlpha;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set__InitialAlpha_4(ref object o, object v)
        {
            ((LCL.AfterImageEffects)o)._InitialAlpha = (System.Single)v;
        }

        static StackObject* AssignFromStack__InitialAlpha_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @_InitialAlpha = *(float*)&ptr_of_this_method->Value;
            ((LCL.AfterImageEffects)o)._InitialAlpha = @_InitialAlpha;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.AfterImageEffects();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
