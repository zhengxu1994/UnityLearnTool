
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
    unsafe class LCL_UIAtals_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.UIAtals);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("GetSprite", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetSprite_0);
            args = new Type[]{typeof(UnityEngine.UI.Image), typeof(System.String)};
            method = type.GetMethod("SetSprite", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetSprite_1);

            field = type.GetField("mainTexture", flag);
            app.RegisterCLRFieldGetter(field, get_mainTexture_0);
            app.RegisterCLRFieldSetter(field, set_mainTexture_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_mainTexture_0, AssignFromStack_mainTexture_0);
            field = type.GetField("spriteLists", flag);
            app.RegisterCLRFieldGetter(field, get_spriteLists_1);
            app.RegisterCLRFieldSetter(field, set_spriteLists_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_spriteLists_1, AssignFromStack_spriteLists_1);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.UIAtals());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.UIAtals[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* GetSprite_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @spritename = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            LCL.UIAtals instance_of_this_method = (LCL.UIAtals)typeof(LCL.UIAtals).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetSprite(@spritename);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetSprite_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @spritename = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            UnityEngine.UI.Image @im = (UnityEngine.UI.Image)typeof(UnityEngine.UI.Image).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            LCL.UIAtals instance_of_this_method = (LCL.UIAtals)typeof(LCL.UIAtals).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetSprite(@im, @spritename);

            return __ret;
        }


        static object get_mainTexture_0(ref object o)
        {
            return ((LCL.UIAtals)o).mainTexture;
        }

        static StackObject* CopyToStack_mainTexture_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.UIAtals)o).mainTexture;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_mainTexture_0(ref object o, object v)
        {
            ((LCL.UIAtals)o).mainTexture = (UnityEngine.Texture2D)v;
        }

        static StackObject* AssignFromStack_mainTexture_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Texture2D @mainTexture = (UnityEngine.Texture2D)typeof(UnityEngine.Texture2D).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.UIAtals)o).mainTexture = @mainTexture;
            return ptr_of_this_method;
        }

        static object get_spriteLists_1(ref object o)
        {
            return ((LCL.UIAtals)o).spriteLists;
        }

        static StackObject* CopyToStack_spriteLists_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.UIAtals)o).spriteLists;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_spriteLists_1(ref object o, object v)
        {
            ((LCL.UIAtals)o).spriteLists = (System.Collections.Generic.List<UnityEngine.Sprite>)v;
        }

        static StackObject* AssignFromStack_spriteLists_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Collections.Generic.List<UnityEngine.Sprite> @spriteLists = (System.Collections.Generic.List<UnityEngine.Sprite>)typeof(System.Collections.Generic.List<UnityEngine.Sprite>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.UIAtals)o).spriteLists = @spriteLists;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.UIAtals();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
