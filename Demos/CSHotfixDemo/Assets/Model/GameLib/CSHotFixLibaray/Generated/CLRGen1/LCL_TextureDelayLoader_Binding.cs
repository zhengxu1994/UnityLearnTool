
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
    unsafe class LCL_TextureDelayLoader_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.TextureDelayLoader);

            field = type.GetField("m_Image", flag);
            app.RegisterCLRFieldGetter(field, get_m_Image_0);
            app.RegisterCLRFieldSetter(field, set_m_Image_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_Image_0, AssignFromStack_m_Image_0);
            field = type.GetField("m_ABName", flag);
            app.RegisterCLRFieldGetter(field, get_m_ABName_1);
            app.RegisterCLRFieldSetter(field, set_m_ABName_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_ABName_1, AssignFromStack_m_ABName_1);
            field = type.GetField("m_AssetName", flag);
            app.RegisterCLRFieldGetter(field, get_m_AssetName_2);
            app.RegisterCLRFieldSetter(field, set_m_AssetName_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_AssetName_2, AssignFromStack_m_AssetName_2);
            field = type.GetField("m_DelayTime", flag);
            app.RegisterCLRFieldGetter(field, get_m_DelayTime_3);
            app.RegisterCLRFieldSetter(field, set_m_DelayTime_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_m_DelayTime_3, AssignFromStack_m_DelayTime_3);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.TextureDelayLoader());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.TextureDelayLoader[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_m_Image_0(ref object o)
        {
            return ((LCL.TextureDelayLoader)o).m_Image;
        }

        static StackObject* CopyToStack_m_Image_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.TextureDelayLoader)o).m_Image;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_Image_0(ref object o, object v)
        {
            ((LCL.TextureDelayLoader)o).m_Image = (UnityEngine.UI.Image)v;
        }

        static StackObject* AssignFromStack_m_Image_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.UI.Image @m_Image = (UnityEngine.UI.Image)typeof(UnityEngine.UI.Image).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.TextureDelayLoader)o).m_Image = @m_Image;
            return ptr_of_this_method;
        }

        static object get_m_ABName_1(ref object o)
        {
            return ((LCL.TextureDelayLoader)o).m_ABName;
        }

        static StackObject* CopyToStack_m_ABName_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.TextureDelayLoader)o).m_ABName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_ABName_1(ref object o, object v)
        {
            ((LCL.TextureDelayLoader)o).m_ABName = (System.String)v;
        }

        static StackObject* AssignFromStack_m_ABName_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @m_ABName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.TextureDelayLoader)o).m_ABName = @m_ABName;
            return ptr_of_this_method;
        }

        static object get_m_AssetName_2(ref object o)
        {
            return ((LCL.TextureDelayLoader)o).m_AssetName;
        }

        static StackObject* CopyToStack_m_AssetName_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.TextureDelayLoader)o).m_AssetName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_m_AssetName_2(ref object o, object v)
        {
            ((LCL.TextureDelayLoader)o).m_AssetName = (System.String)v;
        }

        static StackObject* AssignFromStack_m_AssetName_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @m_AssetName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.TextureDelayLoader)o).m_AssetName = @m_AssetName;
            return ptr_of_this_method;
        }

        static object get_m_DelayTime_3(ref object o)
        {
            return ((LCL.TextureDelayLoader)o).m_DelayTime;
        }

        static StackObject* CopyToStack_m_DelayTime_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.TextureDelayLoader)o).m_DelayTime;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_m_DelayTime_3(ref object o, object v)
        {
            ((LCL.TextureDelayLoader)o).m_DelayTime = (System.Single)v;
        }

        static StackObject* AssignFromStack_m_DelayTime_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @m_DelayTime = *(float*)&ptr_of_this_method->Value;
            ((LCL.TextureDelayLoader)o).m_DelayTime = @m_DelayTime;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.TextureDelayLoader();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
