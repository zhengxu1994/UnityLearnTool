//一个对象如果显示在屏幕上流程：模型空间 --- 世界空间  --- 观察空间 -- 裁剪空间 -- 屏幕空间
// return UnityObjectToClipPos(v) 从模型空间转换到裁剪空间
//定义属性语句后不需要加分号;
//subshader内的语句后需要加分号结尾
//ShaderLab 内的属性类型，Color Vector Range Float 2D Cube 3D 
//内置文件 include file #include "UnityCG.cginc" 包含常用的帮助函数，宏，和结构体。
//UnityShaderVariables.cginc 在编译Unity Shader时,会自动包含进来，包含了需要内置的全局变量。
//Lighting.cginc 包含了各种内置的光照模型，如果编写的是surface shader的话，会自动包含进来
//HLSLSupport.cginc 在编写Unity shader 时会自动包含进来，声明了一些跨平台的宏和定义
