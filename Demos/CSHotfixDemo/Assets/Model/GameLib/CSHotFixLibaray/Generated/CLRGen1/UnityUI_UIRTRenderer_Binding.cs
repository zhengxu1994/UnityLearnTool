
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
    unsafe class UnityUI_UIRTRenderer_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(UnityUI.UIRTRenderer);

            field = type.GetField("Camera", flag);
            app.RegisterCLRFieldGetter(field, get_Camera_0);
            app.RegisterCLRFieldSetter(field, set_Camera_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Camera_0, AssignFromStack_Camera_0);
            field = type.GetField("Texture", flag);
            app.RegisterCLRFieldGetter(field, get_Texture_1);
            app.RegisterCLRFieldSetter(field, set_Texture_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Texture_1, AssignFromStack_Texture_1);
            field = type.GetField("Width", flag);
            app.RegisterCLRFieldGetter(field, get_Width_2);
            app.RegisterCLRFieldSetter(field, set_Width_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Width_2, AssignFromStack_Width_2);
            field = type.GetField("Height", flag);
            app.RegisterCLRFieldGetter(field, get_Height_3);
            app.RegisterCLRFieldSetter(field, set_Height_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_Height_3, AssignFromStack_Height_3);
            field = type.GetField("Depth", flag);
            app.RegisterCLRFieldGetter(field, get_Depth_4);
            app.RegisterCLRFieldSetter(field, set_Depth_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_Depth_4, AssignFromStack_Depth_4);
            field = type.GetField("Format", flag);
            app.RegisterCLRFieldGetter(field, get_Format_5);
            app.RegisterCLRFieldSetter(field, set_Format_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_Format_5, AssignFromStack_Format_5);


            app.RegisterCLRCreateDefaultInstance(type, () => new UnityUI.UIRTRenderer());
            app.RegisterCLRCreateArrayInstance(type, s => new UnityUI.UIRTRenderer[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_Camera_0(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Camera;
        }

        static StackObject* CopyToStack_Camera_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Camera;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Camera_0(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Camera = (UnityEngine.Camera)v;
        }

        static StackObject* AssignFromStack_Camera_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.Camera @Camera = (UnityEngine.Camera)typeof(UnityEngine.Camera).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIRTRenderer)o).Camera = @Camera;
            return ptr_of_this_method;
        }

        static object get_Texture_1(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Texture;
        }

        static StackObject* CopyToStack_Texture_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Texture;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Texture_1(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Texture = (UnityEngine.RenderTexture)v;
        }

        static StackObject* AssignFromStack_Texture_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.RenderTexture @Texture = (UnityEngine.RenderTexture)typeof(UnityEngine.RenderTexture).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIRTRenderer)o).Texture = @Texture;
            return ptr_of_this_method;
        }

        static object get_Width_2(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Width;
        }

        static StackObject* CopyToStack_Width_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Width;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Width_2(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Width = (System.Int32)v;
        }

        static StackObject* AssignFromStack_Width_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @Width = ptr_of_this_method->Value;
            ((UnityUI.UIRTRenderer)o).Width = @Width;
            return ptr_of_this_method;
        }

        static object get_Height_3(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Height;
        }

        static StackObject* CopyToStack_Height_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Height;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Height_3(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Height = (System.Int32)v;
        }

        static StackObject* AssignFromStack_Height_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @Height = ptr_of_this_method->Value;
            ((UnityUI.UIRTRenderer)o).Height = @Height;
            return ptr_of_this_method;
        }

        static object get_Depth_4(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Depth;
        }

        static StackObject* CopyToStack_Depth_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Depth;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_Depth_4(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Depth = (System.Int32)v;
        }

        static StackObject* AssignFromStack_Depth_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @Depth = ptr_of_this_method->Value;
            ((UnityUI.UIRTRenderer)o).Depth = @Depth;
            return ptr_of_this_method;
        }

        static object get_Format_5(ref object o)
        {
            return ((UnityUI.UIRTRenderer)o).Format;
        }

        static StackObject* CopyToStack_Format_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((UnityUI.UIRTRenderer)o).Format;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Format_5(ref object o, object v)
        {
            ((UnityUI.UIRTRenderer)o).Format = (UnityEngine.RenderTextureFormat)v;
        }

        static StackObject* AssignFromStack_Format_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.RenderTextureFormat @Format = (UnityEngine.RenderTextureFormat)typeof(UnityEngine.RenderTextureFormat).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((UnityUI.UIRTRenderer)o).Format = @Format;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new UnityUI.UIRTRenderer();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
