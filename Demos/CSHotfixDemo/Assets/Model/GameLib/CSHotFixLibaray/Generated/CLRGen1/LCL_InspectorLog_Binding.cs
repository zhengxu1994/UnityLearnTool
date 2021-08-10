
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
    unsafe class LCL_InspectorLog_Binding
    {
        public static void Register(CSHotFix.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LCL.InspectorLog);

            field = type.GetField("Log", flag);
            app.RegisterCLRFieldGetter(field, get_Log_0);
            app.RegisterCLRFieldSetter(field, set_Log_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Log_0, AssignFromStack_Log_0);


            app.RegisterCLRCreateDefaultInstance(type, () => new LCL.InspectorLog());
            app.RegisterCLRCreateArrayInstance(type, s => new LCL.InspectorLog[s]);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_Log_0(ref object o)
        {
            return ((LCL.InspectorLog)o).Log;
        }

        static StackObject* CopyToStack_Log_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((LCL.InspectorLog)o).Log;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Log_0(ref object o, object v)
        {
            ((LCL.InspectorLog)o).Log = (System.String)v;
        }

        static StackObject* AssignFromStack_Log_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @Log = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((LCL.InspectorLog)o).Log = @Log;
            return ptr_of_this_method;
        }



        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            CSHotFix.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new LCL.InspectorLog();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
#endif
