
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
    unsafe class GameDll_AssetType_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameDll.AssetType);

            field = type.GetField("level", flag);
            app.RegisterCLRFieldGetter(field, get_level_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_level_0, null);
            field = type.GetField("game_object", flag);
            app.RegisterCLRFieldGetter(field, get_game_object_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_game_object_1, null);
            field = type.GetField("shader", flag);
            app.RegisterCLRFieldGetter(field, get_shader_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_shader_2, null);
            field = type.GetField("lua_script", flag);
            app.RegisterCLRFieldGetter(field, get_lua_script_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_lua_script_3, null);
            field = type.GetField("texture_set", flag);
            app.RegisterCLRFieldGetter(field, get_texture_set_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_texture_set_4, null);


            app.RegisterCLRCreateDefaultInstance(type, () => new GameDll.AssetType());
            app.RegisterCLRCreateArrayInstance(type, s => new GameDll.AssetType[s]);


        }

        static void WriteBackInstance(CSHotFix.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref GameDll.AssetType instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as GameDll.AssetType[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_level_0(ref object o)
        {
            return GameDll.AssetType.level;
        }

        static StackObject* CopyToStack_level_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.AssetType.level;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_game_object_1(ref object o)
        {
            return GameDll.AssetType.game_object;
        }

        static StackObject* CopyToStack_game_object_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.AssetType.game_object;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_shader_2(ref object o)
        {
            return GameDll.AssetType.shader;
        }

        static StackObject* CopyToStack_shader_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.AssetType.shader;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_lua_script_3(ref object o)
        {
            return GameDll.AssetType.lua_script;
        }

        static StackObject* CopyToStack_lua_script_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.AssetType.lua_script;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static object get_texture_set_4(ref object o)
        {
            return GameDll.AssetType.texture_set;
        }

        static StackObject* CopyToStack_texture_set_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = GameDll.AssetType.texture_set;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new GameDll.AssetType();
            ins = (GameDll.AssetType)o;
            return ins;
        }


    }
}
#endif
