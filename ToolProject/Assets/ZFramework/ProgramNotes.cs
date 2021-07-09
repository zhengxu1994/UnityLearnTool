//记录项目中遇到的问题
//1.特效在一开始播放的时候闪烁了一下，这个问题大多是因为特效的Animator的CullMode参数设置错误导致的
//CullMode :  AlwaysAnimate(总是在播放动画，即使对象在屏幕外)
//CullUpdateTransforms（当渲染器不可见时，转换的重新定位、IK和写入被禁用）
//CullComplete （当渲染器不可见时，动画是完全禁用的。）
//应该使用第三个参数，当特效被隐藏后就应该完全禁用动画。



//2.Path.GetFileNameWithOutExtension 直接获取一个文件的文件名称 不带拓展
//3.Assembly.Load() 加载dll和pbd，可以通过遍历程序集获取所有类，做一些预处理。
//4.AssetBundle的依赖和冗余，ab在打包时会自动检测引用关系，如果有a b c三个文件，
//a b被设置了ab名称那么就会被打包，如果a b 都引用了c ，那么就是造成a和b的包里都有c，所以尽量把c也单独打包，在加载a的时候先加载c就可以。


//5.ab包资源加载流程，ab文件存在硬盘上 / 网络上--> 文件内存镜像 --> 从文件中加载文件并实例化（内存）
//6.ab包打包压缩算法lz4 BuildAssetBundleOptions.ChunkBasedCompression

//7.加载ab必然涉及到文件路径，
//Resources:全部的资源都会被压缩，转化为二进制，跟随游戏包一起被打包，打包后这个路径是不存在的，不可写也不可读，只能通过Resources.Load()方法加载
//StreamingAssets:全部资源会被原封不动的打包出去，在移动平台中只能读取不能写入，在其他平台可以通过File类读取写入，在任意平台都以AssetBundle.LoadFromFile读取ab包
//StreamingAssets.streamingAssetsPath,在安卓平台 pc平台的路径直接用Application.streamingAssetsPath就可以，苹果就用"file://{Application.streamingAssetsPath}"
//Application.persistentDataPath：可读写目录，任意平台可以使用System.File库进行读写操作，WWW,UWR,AssetBundle.LoadFromFile更不在话下。
//移动平台可以使用"{Application.persistentDataPath}/{Application.productName}/"进行访问，非移动平台直接使用Application.persistentDataPath即可访问。

//8.计算网络文件大小 ，HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; respone = request.GetResponse();  length = respone.ContentLength;

//9.二进制 & | ^运算， &当两个二进制进行比较，每个位置上的值（0/1）相同时，返回1不同则返回0，|当两个二进制进行比较，每个位置上只要有一个是1就返回1，只有都是0时才返回0 ,^当两个二进制比较时，只要
//位置上的两个数相同不管都是0或者1都返回0，否则就返回1.
