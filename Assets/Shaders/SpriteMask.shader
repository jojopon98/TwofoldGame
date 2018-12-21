﻿// Upgrade NOTE : replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SpriteMaskShader"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
			[PerRendererData] _MaskType("Mask Target X", Float) = 0
	}

		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
				"CanUseSpriteAtlas" = "True"
			}

			Cull Off
			Lighting Off
			ZWrite Off
			Blend One OneMinusSrcAlpha

			Pass
			{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile _ PIXELSNAP_ON
				#include "UnityCG.cginc"

				struct appdata_t
				{
					float4 vertex   : POSITION;
					float4 color    : COLOR;
					float2 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					float4 vertex   : SV_POSITION;
					fixed4 color : COLOR;
					float2 texcoord  : TEXCOORD0;
					fixed worldPos : WORLDPOS;
				};

				fixed4 _Color;
				float _MaskType;

				v2f vert(appdata_t IN)
				{
					v2f OUT;
					OUT.worldPos = mul(unity_ObjectToWorld, fixed4(IN.vertex.x, IN.vertex.y, 0, 1));
					OUT.vertex = UnityObjectToClipPos(IN.vertex);
					OUT.texcoord = IN.texcoord;
					OUT.color = IN.color * _Color;
					#ifdef PIXELSNAP_ON
					OUT.vertex = UnityPixelSnap(OUT.vertex);
					#endif

					return OUT;
				}

				sampler2D _MainTex;
				sampler2D _AlphaTex;
				float _AlphaSplitEnabled;

				fixed4 SampleSpriteTexture(float2 uv)
				{
					fixed4 color = tex2D(_MainTex, uv);

	#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
					if (_AlphaSplitEnabled)
						color.a = tex2D(_AlphaTex, uv).r;
	#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

					return color;
				}

				fixed4 frag(v2f IN) : SV_Target
				{
					fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;

					if (_MaskType > 0) {

						if (_MaskType <= 1)
							c.a = 0;
						else if (_MaskType <= 2)
							c.rgb = fixed3(c.r, 0, 0);// red
						else if (_MaskType <= 3)
							c.rgb = fixed3(0, c.g, 0); // green
						else if (_MaskType <= 4)
							c.rgb = fixed3(0, 0, c.b); // blue
						else if (_MaskType <= 5)
							c.rgb = fixed3(0, c.g, c.b); // cyan
						else if (_MaskType <= 6)
							c.rgb = fixed3(c.r, 0, c.b);// purple
						else if (_MaskType <= 7)
							c.rgb = fixed3(c.r, c.g, 0);// yellow
						else if (_MaskType <= 8)
							c.rgb = fixed3(0, 0, 0); // black
						else if (_MaskType <= 9)
							c.rgb = fixed3(1, 1, 1); // white
						else if (_MaskType <= 10)
							c.rgb = fixed3(1 - c.r, 1 - c.g, 1 - c.b); //negative
						else if (_MaskType <= 11) { //grayscale
							float amnt = c.r*0.299 + c.g*0.587 + c.b*0.114;
							c.rgb = fixed3(amnt, amnt, amnt);
						}
					}
					c.rgb *= c.a;
					return c;
				}
			ENDCG
			}
		}
}