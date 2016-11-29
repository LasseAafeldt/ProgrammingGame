Shader "Custom/ConstructionModules" {
	Properties{
		_MainTex("Texture", Rect) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0) //background color
		_X ("X", Float) = 1.0
      	_Y ("Y", Float) = 0.0
      	_Width ("Width", Float) = 128
      	_Height ("Height", Float) = 128
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
				uniform float _X;
				uniform float _Y;
				uniform float _Width;
				uniform float _Height;

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
						(_X+_ScreenParams.x  //center in x direction
						+ _Width + _ScreenParams.x/2 * (input.vertex.x)), //sets how much of the screen should be filled. By dividing with 2 you change the size of the overlay
						(_Y+_ScreenParams.y / 4 //center in y direction
						+ _Height+ _ScreenParams.y/8 * (input.vertex.y))); //sets how much of the screen should be filled, multiply with 2 to fill entire screen
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
