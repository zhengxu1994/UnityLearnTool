using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;
namespace CScriptDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly("../../../../../CSDemo/CSDemo/bin/Debug/netcoreapp3.1/CSDemo.dll");
            var method = assembly.MainModule.Types.FirstOrDefault((t => t.Name == "Program")).
                Methods.FirstOrDefault((m) => m.Name == "Main");

            var worker = method.Body.GetILProcessor();
            string FrontTime = DateTime.Now.ToString();
            var ins = method.Body.Instructions[0];//Get First IL Step
            worker.InsertBefore(ins, worker.Create(OpCodes.Ldstr, FrontTime));
            worker.InsertBefore(ins, worker.Create(OpCodes.Call,
            assembly.MainModule.ImportReference(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }))));

            string BackTime = DateTime.Now.ToString();
            ins = method.Body.Instructions[method.Body.Instructions.Count - 1]; //Get Lastest IL Step
            worker.InsertBefore(ins, worker.Create(OpCodes.Ldstr, BackTime));
            worker.InsertBefore(ins, worker.Create(OpCodes.Call,
            assembly.MainModule.ImportReference(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }))));

            assembly.Write("../../../../../CSDemo/CSDemo/bin/Debug/netcoreapp3.1/CSDemo.dll");
        }
    }
}
