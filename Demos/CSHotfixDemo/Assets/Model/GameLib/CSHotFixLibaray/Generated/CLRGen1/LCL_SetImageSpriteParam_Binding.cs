
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
    unsafe class LCL_SetImageSpriteParam_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.SetImageSpriteParam);

            field = type.GetField("abName", flag);
            app.RegisterCLRFieldGetter(field, get_abName_0);
            app.RegisterCLRFieldSetter(field, set_abName_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_abName_0, AssignFromStack_abName_0);
            field = type.GetField("assetName", flag);
            app.RegisterCLRFieldGetter(field, get_assetName_1);
            app.RegisterCLRFieldSetter(field, set_assetName_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_assetName_1, AssignFromStack_assetName_1);
            field = type.GetField("img", flag);
            app.RegisterCLRFieldGetter(field, get_img_2);
            app.RegisterCLRFieldSetter(field, set_img_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_img_2, AssignFromStack_img_2);
            field = type.GetField("call", flag);
            app.RegisterCLRFieldGetter(field, get_call_3);
            app.RegisterCLRFieldSetter(field, set_call_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_call_3, AssignFromStack_call_3);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.SetImageSpriteParam());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.SetImageSpriteParam[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_abName_0(ref object o)
        {
            return ((LCL.SetImageSpriteParam)o).abName;
        }

        static StackObject* CopyToStack_abName_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetImageSpriteParam)o).abName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_abName_0(ref object o, object v)
        {
            ((LCL.SetImageSpriteParam)o).abName = (System.String)v;
        }

        static StackObject* AssignFromStack_abName_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @abName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetImageSpriteParam)o).abName = @abName;
            return ptr_of_this_method;
        }

        static object get_assetName_1(ref object o)
        {
            return ((LCL.SetImageSpriteParam)o).assetName;
        }

        static StackObject* CopyToStack_assetName_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetImageSpriteParam)o).assetName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_assetName_1(ref object o, object v)
        {
            ((LCL.SetImageSpriteParam)o).assetName = (System.String)v;
        }

        static StackObject* AssignFromStack_assetName_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @assetName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetImageSpriteParam)o).assetName = @assetName;
            return ptr_of_this_method;
        }

        static object get_img_2(ref object o)
        {
            return ((LCL.SetImageSpriteParam)o).img;
        }

        static StackObject* CopyToStack_img_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetImageSpriteParam)o).img;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_img_2(ref object o, object v)
        {
            ((LCL.SetImageSpriteParam)o).img = (UnityEngine.UI.Image)v;
        }

        static StackObject* AssignFromStack_img_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.UI.Image @img = (UnityEngine.UI.Image)typeof(UnityEngine.UI.Image).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetImageSpriteParam)o).img = @img;
            return ptr_of_this_method;
        }

        static object get_call_3(ref object o)
        {
            return ((LCL.SetImageSpriteParam)o).call;
        }

        static StackObject* CopyToStack_call_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.SetImageSpriteParam)o).call;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_call_3(ref object o, object v)
        {
            ((LCL.SetImageSpriteParam)o).call = (System.Action<LCL.SetImageSpriteParam, UnityEngine.Sprite>)v;
        }

        static StackObject* AssignFromStack_call_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action<LCL.SetImageSpriteParam, UnityEngine.Sprite> @call = (System.Action<LCL.SetImageSpriteParam, UnityEngine.Sprite>)typeof(System.Action<LCL.SetImageSpriteParam, UnityEngine.Sprite>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.SetImageSpriteParam)o).call = @call;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.SetImageSpriteParam();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
