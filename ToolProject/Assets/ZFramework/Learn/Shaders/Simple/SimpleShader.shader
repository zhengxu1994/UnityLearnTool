//一个最简单的shader 拥有一个顶点着色器 和一个片元着色器
//模型顶点处理顺序 模型空间--世界空间（根据游戏中的世界坐标系将模型顶点坐标转换为对应的坐标系坐标）--观察空间（以摄像机位置为原点，摄像机局部坐标轴
//转换的坐标）--裁剪空间也叫齐次裁剪空间（完全在摄像机视野外的部分的图元进行剔除，部分在摄像机外的图元进行裁剪）
//最终获取到的图元信息交由片元着色器处理
Shader "ZXShader/SimpleShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color",Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				// float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				// float2 uv : TEXCOORD0;
				// UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			// sampler2D _MainTex;
			// float4 _MainTex_ST;

			v2f vert (appdata v)
			{
				v2f o;
				//将模型顶点坐标转换为裁剪空间坐标
				o.vertex = UnityObjectToClipPos(v.vertex);
				// o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				// UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			fixed4 _Color;
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				// fixed4 col = tex2D(_MainTex, i.uv);
				// // apply fog
				// UNITY_APPLY_FOG(i.fogCoord, col);
				// return col;
				// return fixed4(1,1,1,1);
				return _Color;
			}
			ENDCG
		}
	}
}
