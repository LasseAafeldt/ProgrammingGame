// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Cg shader with reflection map" {
   Properties {
      _Cube("Reflection Map", Cube) = "" {}
   }
   SubShader {
      Pass {   
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 

         #include "UnityCG.cginc"

         // User-specified uniforms
         uniform samplerCUBE _Cube;   

         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float3 normalDir : TEXCOORD0;
            float3 viewDir : TEXCOORD1;

            float3 reflectionDir : TEXCOORD2;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject; 

            //when moving the reflectionDir to the vertex shader the viewDir and normalDir should be assigned a type down here.
            //If the reflectionDir is in the fragment shader it should be output.viewDir and output.normalDir without float3 in front. 
            float3 viewDir = mul(modelMatrix, input.vertex).xyz 
               - _WorldSpaceCameraPos;
            float3 normalDir = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);

            //reflectionDir in the vertex shader.
            //the fragment shader needs to get the reflectedDir
            output.reflectionDir = reflect(viewDir, normalize(normalDir));

            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
         //reflection dir in the fragment shader
//            float3 reflectedDir = 
//               reflect(input.viewDir, normalize(input.normalDir));
            return texCUBE(_Cube, input.reflectionDir);
         }
 
         ENDCG
      }
   }
}