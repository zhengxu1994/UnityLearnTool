using System;
namespace Test
{
    public class DisposeClass : IDisposable
    {
        //是否回收
        private bool _disposed;
        
        /// <summary>
        /// 当需要回收非托管资源的DisposableClass类，
        /// 就调用Dispoase()方法。而这个方法不会被CLR自动调用，需要手动调用。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 析构函数
        /// 当托管堆上的对象没有被其它对象引用，GC会在回收对象之前，调用对象的析构函数。
        /// 这里的~DisposableClass()析构函数的意义在于告诉GC你可以回收我，
        /// Dispose(false)表示在GC回收的时候，就不需要手动回收了。
        /// </summary>
        ~DisposeClass()
        {
            Dispose(false);
        }

        /// <summary>
        /// 通过此方法，所有的托管和非托管资源都能被回收。
        /// 参数disposing表示是否需要释放那些实现IDisposable接口的托管对象。
        /// 设置为虚方法是想让子类也参与到垃圾回收逻辑中，还不会影响到基类。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;//已经回收不在执行
            if(disposing)
            {
                //TODO:  释放那些实现了IDispose接口的托管对象
                //如果disposings设置为true，就表示DisposablClass类依赖某些实现了IDisposable接口的托管对象，
                //可以通过这里的Dispose(bool disposing)方法调用这些托管对象的Dispose()方法进行回收。

            }
            //TODO: 释放非托管资源 ，设置对象为null
            //如果disposings设置为false,就表示DisposableClass类依赖某些没有实现IDisposable的非托管资源，
            //那就把这些非托管资源对象设置为null，等待GC调用DisposableClass类的析构函数，把这些非托管资源进行回收。
            //比如说我自定义的一些数据封装对象，设置他们的引用为null，或者将他们放回对象池中

            //在.NET 2.0之前，如果一个对象的析构函数抛出异常，这个异常会被CLR忽略。但.NET 2.0以后，如果析构函数抛出异常就会导致应用程序的崩溃。所以，保证析构函数不抛异常变得非常重要。
            //还有，Dispose()方法允许抛出异常吗？答案是否定的。如果Dispose()方法有抛出异常的可能，那就需要使用try / catch来手动捕获
            try
            {
                
            }catch (Exception ex)
            {
                //Log.Warn(ex) 记录日志

            }

            _disposed = true;
        }
    }

    public class SubDisposableClass : DisposeClass
    {
        private bool _disposed; //表示是否已经被回收

        protected override void Dispose(bool disposing)
        {
            if (!_disposed) //如果还没有被回收
            {
                if (disposing) //如果需要回收一些托管资源
                {
                    //TODO:回收托管资源，调用IDisposable的Dispose()方法就可以
                }
                //TODO：回收非托管资源，把之设置为null，等待CLR调用析构函数的时候回收
                _disposed = true;
            }
            base.Dispose(disposing);//再调用父类的垃圾回收逻辑
        }
    }
}
