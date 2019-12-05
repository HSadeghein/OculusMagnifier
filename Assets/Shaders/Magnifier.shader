Shader "Oculus/Magnifier"
{
    Properties {
		_MainTex("Main Texture",2D ) = "white"{}
        _Color ("Main Color", Color) = (1,1,1,1)
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Geometry+2"}
		//Blend SrcAlpha OneMinusSrcAlpha


		CGINCLUDE


		#include "UnityCG.cginc"

		float4 _Color, _MainTex_ST;
		sampler2D _MainTex;
		struct appdata {
			float4 vertex : POSITION;
			float2 uv: TEXCOORD0;
		};
		struct v2f {
			float4 pos : SV_POSITION;
			float2 uv:TEXCOORD0;
		};
		v2f vert(appdata v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);

			return o;
		}
		half4 frag(v2f i) : SV_Target {
			return tex2D(_MainTex, i.uv) * _Color;
		}
		half4 frag1(v2f i) : SV_Target {
			float4 color = tex2D(_MainTex, i.uv) * _Color;
			return color;
		}
		ENDCG
		

		pass
		{
			ColorMask RGB
			Stencil {
			Ref 1
			Comp equal 
			Pass Keep
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}


    }
}
