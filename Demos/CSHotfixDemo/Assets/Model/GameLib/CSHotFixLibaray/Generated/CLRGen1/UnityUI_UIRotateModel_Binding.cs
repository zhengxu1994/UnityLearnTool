
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
    unsafe class UnityUI_UIRotateModel_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityUI.UIRotateModel);

            field = type.GetField("RotationObj", flag);
            app.RegisterCLRFieldGetter(field, get_RotationObj_0);
            app.RegisterCLRFieldSetter(field, set_RotationObj_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_RotationObj_0, AssignFromStack_RotationObj_0);
            field = type.GetField("speed", flag);
            app.RegisterCLRFieldGetter(field, get_speed_1);
            app.RegisterCLRFieldSetter(field, set_speed_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_speed_1, AssignFromStack_speed_1);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityUI.UIRotateModel());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityUI.UIRotateModel[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_RotationObj_0(ref object o)
        {
            return ((UnityUI.UIRotateModel)o).RotationObj;
        }

        static StackObject* CopyToStack_RotationObj_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRotateModel)o).RotationObj;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_RotationObj_0(ref object o, object v)
        {
            ((UnityUI.UIRotateModel)o).RotationObj = (UnityEngine.Transform)v;
        }

        static StackObject* AssignFromStack_RotationObj_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Transform @RotationObj = (UnityEngine.Transform)typeof(UnityEngine.Transform).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIRotateModel)o).RotationObj = @RotationObj;
            return ptr_of_this_method;
        }

        static object get_speed_1(ref object o)
        {
            return ((UnityUI.UIRotateModel)o).speed;
        }

        static StackObject* CopyToStack_speed_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRotateModel)o).speed;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_speed_1(ref object o, object v)
        {
            ((UnityUI.UIRotateModel)o).speed = (System.Single)v;
        }

        static StackObject* AssignFromStack_speed_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @speed = *(float*)&ptr_of_this_method->Value;
            ((UnityUI.UIRotateModel)o).speed = @speed;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new UnityUI.UIRotateModel();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
