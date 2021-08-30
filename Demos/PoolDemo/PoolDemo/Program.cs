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

            PoolManager.Inst.Recycle<Student>(student1);
            PoolManager.Inst.Recycle<Student>(student2);

            Console.WriteLine($"age1 :{student1.age}");
            Console.WriteLine($"age2 :{student2.age}");
            Console.WriteLine($"active1 :{student2.IsActive()}");

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

    public class Student : IDisposable,IActivateEntity
    {
        public string name;
        public int age;
        private bool _active = true;//是否被激活，对象池回收对象激活为false

        public void Free()
        {
            name = null;
            age = -1;
        }

        public void Dispose()
        {
            name = null;
        }

        public bool IsActive()
        {
            return _active;
        }

        public void SetActive(bool active)
        {
            this._active = active;
        }
    }
}
