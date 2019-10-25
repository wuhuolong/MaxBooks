// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "pl_puzzle_Hidden/ui_mask"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}//底图
		_MaskTex("MaskTex", 2D) = "white" {}//需要缩放的图
		_Progress("Progress",Range(-0.5,0.5)) = 0//缩放比例
		_Color("Color",color) = (0,0,0,0)//底图颜色
			_blurOffset("Blur",Range(0,0.01)) = 0.0075//模糊系数
	}
		SubShader
		{
			Tags{"RenderType" = "Transparent" "Queue" = "Transparent"}
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float2 uv2:TXCOORD1;
					float4 vertex : SV_POSITION;
				};

				sampler2D _MaskTex;
				sampler2D _MainTex;
				float _Progress;
				float4 _MaskTex_ST;
				fixed4 _Color;
				fixed _blurOffset;

				v2f vert(appdata v)
				{
					v2f o;
					//o.vertex = UnityObjectToClipPos(v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					//o.uv2 = cos(o.uv*_Time.x);
					return o;
				}


				fixed4 frag(v2f i) : SV_Target
				{
					//fixed4 col = tex2D(_MainTex, i.uv);
					//// just invert the colors
					//col.rgb = 1 - col.rgb;
				//	_Progress = log2(0.5 - _Progress);
				//_MaskTex_ST.xy = _Progress;
				//	_MaskTex_ST.zw = (_Progress - 1)*-0.5;
				//	fixed4 maskcol = tex2D(_MaskTex, i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw);
				//	//高斯模糊
				//	//leftup
				//	fixed4 maskcol1 = tex2D(_MaskTex,i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw + fixed2(-_blurOffset,_blurOffset));
				//	//leftdown
				//	fixed4 maskcol2 = tex2D(_MaskTex, i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw + fixed2(-_blurOffset, -_blurOffset));
				//	//rightup
				//	fixed4 maskcol3 = tex2D(_MaskTex, i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw + fixed2(_blurOffset, _blurOffset));
				//	//rightdown
				//	fixed4 maskcol4 = tex2D(_MaskTex, i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw + fixed2(_blurOffset, -_blurOffset));
				//	fixed4 mix = (maskcol + maskcol1 + maskcol2 + maskcol3 + maskcol4)*0.2;
				//	mix = lerp(maskcol, mix, 0.5);
				//	fixed4 outcol = tex2D(_MainTex, i.uv);
				//	outcol.w = outcol.a*(1-mix.a);
				//	outcol = fixed4(_Color.x, _Color.y, _Color.z, _Color.w);
	   //             return outcol;
					//*******
					//_Progress = pow(_Progress,2);
			_Progress = log(0.5 - _Progress);

		_MaskTex_ST.xy = _Progress;
		_MaskTex_ST.zw = (_Progress - 1)*-0.5;
		//缩放图 同时做为掩膜图 
		fixed4 maskcol = tex2D(_MaskTex, i.uv*_MaskTex_ST.xy + _MaskTex_ST.zw);
		//底图取样
		fixed4 outcol = tex2D(_MainTex,i.uv);
		//去除缩放图的alpha值 
		outcol.w = outcol.a*(1 - maskcol.a);
		return outcol;
				}
				ENDCG
			}
		}
}
