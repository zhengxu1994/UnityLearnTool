using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using SpaceA;
using SpaceB;

namespace CSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //People p = new People();
            //Man m = new Man();
            //Student st = new Student();
            //if (st is People)
            //{
            //    Console.WriteLine("is true");
            //}

            //People pnew = st as People;
            //if(pnew != null)
            //{
            //    Console.WriteLine("as true");
            //}

            //st.Test();

            //float a = 6.8f;
            //Console.WriteLine((int)a);

            //byte b = 200;//byte 最大为255 因为从0开始 所以256个
            //b = (Byte)(b + 500);//700 - 256（byte最大值）* 2 = 188 永远截取byte整数倍
            //Console.WriteLine(b);

            //People p1 = new People();
            //p1.name = "123";
            //People p2 = new People();
            //p2.name = "123";

            //Console.WriteLine(p1 == p2);

            //struct1 t1 = new struct1();
            //t1.name = "123";
            //struct1 t2 = new struct1();
            //t1.name = "123";

            //Console.WriteLine(t1.Equals(t2));

            //DynamicDemo.Test();

            //ClassA classa = new ClassA();
            //classa.a = 100;
            //ClassB classb = new ClassB();
            //classb.a = 1000;

            //AbstractClass.Test();

            int[] a = { 8, 4, 12, 2, 6, 10, 14 };
            BinaryTree<int> tree = new BinaryTree<int>();
            for (int i = 0; i < a.Length; i++)
            {
                tree.Add(a[i]);
            }

            //Console.WriteLine(tree.Contain(10));
            tree.ShowInOrder();
            tree.ShowPreOrder();
        }
    }

    //显示排列这个值类型的字段
    [StructLayout(LayoutKind.Explicit)]
    public struct SomeValType
    {
        [FieldOffset(0)]
        private readonly Byte m_b; //m_b和m_x字段在该类型的实例中相互重叠

        [FieldOffset(0)]
        private readonly Int16 m_x;
    }

    public class People
    {
        public string name;

        public virtual void Test()
        {
            Console.WriteLine("Test ===");
        }
    }

    public class Man : People
    {
        public int sex;

        /// <summary>
        /// 密封，子类无法在复写
        /// </summary>
        public sealed override void Test()
        {
            Console.WriteLine("Test1 ===");
            base.Test();
        }
    }

    public class Student : Man
    {
        public int score;

    }

    public struct struct1
    {
        public string name;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    /// <summary>
    /// 动态类型demo
    /// </summary>
    internal static class DynamicDemo
    {
        public static void Test()
        {
            dynamic value;
            for (int demo = 0; demo < 2; demo++)
            {
                value = (demo == 0) ? (dynamic)5 : (dynamic)"A";
                value = value + value;
                M(value);
            }
        }

        private static void M(int n)
        {
            Console.WriteLine("M(int) :{0}", n);
        }

        private static void M(string str)
        {
            Console.WriteLine("M(string) : {0}", str);
        }
    }

    internal sealed class StaticMemberDynamicWrapper : DynamicObject
    {
        private readonly TypeInfo m_type;

        public StaticMemberDynamicWrapper(Type type) { m_type = type.GetTypeInfo(); }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return m_type.DeclaredMembers.Select(mi => mi.Name);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            var field = FindField(binder.Name);
            if (field != null) { result = field.GetValue(null); return true; }
            var prop = FindProperty(binder.Name, true);
            if (prop != null) {
                result = prop.GetValue(null, null);
                return true;
            }
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var field = FindField(binder.Name);
            if (field != null) { field.SetValue(null, value);return true; }
            var prop = FindProperty(binder.Name, false);
            if (prop != null) {
                prop.SetValue(null, value, null);
                return true;
            }
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            MethodInfo method = FindMethod(binder.Name, args.Select(c => c.GetType()).ToArray());
            if (method == null) { result = null;return false; }
            result = method.Invoke(null, args);
            return true;
        }

        private MethodInfo FindMethod(string name,Type[] paramTypes)
        {
            return m_type.DeclaredMethods.FirstOrDefault(
                mi => mi.IsPublic && mi.IsStatic && mi.Name == name && ParametersMatch(mi.GetParameters(), paramTypes)
               ); ;
        }

        private Boolean ParametersMatch(ParameterInfo[] parameters,Type[] paramTypes)
        {
            if (parameters.Length != paramTypes.Length) return false;
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType != paramTypes[i]) return false;
            }
            return true;
        }

        private FieldInfo FindField(string name)
        {
            return m_type.DeclaredFields.FirstOrDefault(fi => fi.IsPublic && fi.IsStatic
            && fi.Name == name);
        }

        private PropertyInfo FindProperty(string name, bool get)
        {
            if(get)
            {
                return m_type.DeclaredProperties.FirstOrDefault(pi => pi.Name == name
                && pi.GetMethod != null && pi.GetMethod.IsPublic && pi.GetMethod.IsStatic);
            }
            return  m_type.DeclaredProperties.FirstOrDefault(pi => pi.Name == name
                && pi.SetMethod != null && pi.SetMethod.IsPublic && pi.SetMethod.IsStatic);
        }
    }

}


namespace SpaceA
{
   internal class ClassA
   {
        internal int a;
   }

   public abstract class AbstractClass
    {
        public static void Test()
        {
            Console.WriteLine("AbstractClass");
        }
    }
}

namespace SpaceB
{
    internal class ClassB : ClassA
    {
        void Test()
        {
            a = 10;
        }
    }
}
