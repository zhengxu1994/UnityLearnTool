
#ifndef FMST01_CONST
#define FMST01_CONST

#define _PI 3.14159265359
#define _PI2 6.28318530718
#define _Deg2Rad 0.01745329 //PI/180.
#define _Rad2Deg 57.2957795 //180./PI

#define USING_UNITY_SHADER_TIME   // 使用Unity 中的时间变量

	#if defined(USING_UNITY_SHADER_TIME)
		#include "UnityShaderVariables.cginc" 
	#else
		float4 _Time;
	#endif//USING_UNITY_SHADER_TIME

	#define _fTime (_Time.y)   // global time   
#endif