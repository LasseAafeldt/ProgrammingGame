﻿Shader "Custom/ScreenOverlayMissionAccomplishedMiniProject" {
	Properties{
		_MainTex("Texture", Rect) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0) //background color
	}
		SubShader{
			Tags{ "Queue" = "Overlay" }
			Pass {
				Blend SrcAlpha OneMinusSrcAlpha // use alpha blending
				ZTest Always // deactivate depth test

 

				CGPROGRAM

				// Physically based Standard lighting model, and enable shadows on all light types
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"
					// defines float4 _ScreenParams with x = width;  
					// y = height; z = 1 + 1.0/width; w = 1 + 1.0/height
					// and defines float4 _ProjectionParams 
					// with x = 1 or x = -1 for flipped projection matrix;
					// y = near clipping plane; z = far clipping plane; and
					// w = 1 / far clipping plane

				uniform sampler2D _MainTex;
				uniform float4 _Color;
				struct vertexInput {
					float4 vertex : POSITION;
					float4 texcoord : TEXCOORD0;
				};
				struct vertexOutput {
					float4 pos : SV_POSITION;
					float4 tex : TEXCOORD0;
				};

				vertexOutput vert(vertexInput input)
				{
					vertexOutput output;
					float2 rasterPosition = float2(
						(_ScreenParams.x / 2 //center in x direction
						+ _ScreenParams.x * (input.vertex.x)), //sets how much of the screen should be filled
						(_ScreenParams.y / 2 //center in y direction
						+ _ScreenParams.y * (input.vertex.y))) * 2; //sets how much of the screen should be filled, multiply with 2 to fill entire screen
					output.pos = float4(
						rasterPosition.x / _ScreenParams.x - 1.0,
						_ProjectionParams.x * (rasterPosition.y / _ScreenParams.y - 1.0),
						0,1);

					output.tex = float4(input.vertex.x + 0.5,
						input.vertex.y + 0.45, 0, 0.0);
					// for a cube, vertex.x and vertex.y 
					// are -0.5 or 0.5
					return output;
				}
				float4 frag(vertexOutput input) : COLOR
				{
					return _Color * tex2D(_MainTex, input.tex.xy);
				}
			ENDCG
		}
	}
}
