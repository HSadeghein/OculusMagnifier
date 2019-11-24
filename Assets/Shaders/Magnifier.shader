Shader "Custom/Magnifier"
{
    Properties {
		_MainTex("Main Texture",2D ) = "white"{}
        _Color ("Main Color", Color) = (1,1,1,0)
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Geometry+2"}
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			ColorMask RGB
			Cull Off
			ZTest Less
			Stencil {
				Ref 1
				Comp equal 
				Pass Zero
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			float4 _Color;
			sampler2D _MainTex;
			struct appdata {
				float4 vertex : POSITION;
			};
			struct v2f {
				float4 pos : SV_POSITION;
			};
			v2f vert(appdata v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}
			half4 frag(v2f i) : SV_Target {
				return _Color;
			}
			ENDCG
		}
    }
}
