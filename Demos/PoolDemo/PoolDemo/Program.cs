using System;

namespace Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            PoolManager.Inst.GetPool<Student>(() => {
                return new Student();
            }, (student) => {
                student.Free();
            }, 10);
            var student1 = PoolManager.Inst.Alloc<Student>();
            student1.name = "张三";
            student1.age = 19;

            var student2 = PoolManager.Inst.Alloc<Student>();
            student2.name = "李四";
            student2.age = 21;

            Console.WriteLine($"name1 :{student1.name}");
            Console.WriteLine($"name2 :{student2.name}");

            PoolManager.Inst.Free<Student>(student1);
            PoolManager.Inst.Free<Student>(student2);

            Console.WriteLine($"age1 :{student1.age}");
            Console.WriteLine($"age2 :{student2.age}");

            Console.WriteLine($"count :{PoolManager.Inst.PoolCount}");

            var succ = PoolManager.Inst.Destroy<Student>();

            Console.WriteLine($"destroy :{succ}");

            Console.WriteLine($"newcount :{PoolManager.Inst.PoolCount}");

            PoolManager.Inst.GetPool<Student>(() => {
                return new Student();
            }, (student) => {
                student.Free();
            }, 10);

            PoolManager.Inst.DestroyAll();

            Console.WriteLine($"newcount after detroyAll :{PoolManager.Inst.PoolCount}");
            Console.ReadLine();
        }
    }

    public class Student : IDisposable
    {
        public string name;
        public int age;

        public void Free()
        {
            name = null;
            age = -1;
        }

        public void Dispose()
        {
            name = null;
        }
    }
}
