// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Cg transparent" {
   Properties {
      _Color ("Color", Color) = (1, 1, 1, 0.5) 
         // user-specified RGBA color including opacity
      _PowSlider ("Slider", Range (0, 20)) = 10 //Create the slider that is user-specified between 0 and 20
   }
   SubShader {
      Tags { "Queue" = "Transparent" } 
         // draw after all opaque geometry has been drawn
      Pass { 
         ZWrite Off // don't occlude other objects
         Blend SrcAlpha OneMinusSrcAlpha // standard alpha blending
 
         CGPROGRAM 
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
 
         uniform float4 _Color; // define shader property for shaders
 		 uniform float _PowSlider; //Define slider

         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float3 normal : TEXCOORD;
            float3 viewDir : TEXCOORD1;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject; 
 
            output.normal = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            output.viewDir = normalize(_WorldSpaceCameraPos 
               - mul(modelMatrix, input.vertex).xyz);
 
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
            float3 normalDirection = normalize(input.normal);
            float3 viewDirection = normalize(input.viewDir);
 
            float newOpacity = min(1.0, _Color.a 
               / abs(pow(dot(viewDirection, normalDirection), _PowSlider))); //this is where the thickness of the silhouette effect is defined using pow. 
            return float4(_Color.rgb, newOpacity);
         }
 
         ENDCG
      }
   }
}