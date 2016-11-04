//sets t

Shader "Cg shader for Unity-specific skybox" {
   Properties {
      _Cube ("Environment Map", Cube) = "white" {}
   }

   SubShader {
      Tags { "Queue"="Background"  }

      Pass {
         ZWrite Off //you deactivate backface coloring
         Cull Off 

         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag

         // User-specified uniforms
         samplerCUBE _Cube;

         struct vertexInput {
            float4 vertex : POSITION;
            float3 texcoord : TEXCOORD0;
         };

         struct vertexOutput {
            float4 vertex : SV_POSITION;
            float3 texcoord : TEXCOORD0;
         };

         vertexOutput vert(vertexInput input)
         {
            vertexOutput output;
            output.vertex = mul(UNITY_MATRIX_MVP, input.vertex);
            output.texcoord = input.texcoord; //gets the texture coordinates
            return output;
         }

         fixed4 frag (vertexOutput input) : COLOR
         {
            return texCUBE (_Cube, input.texcoord); //texture lookup in the direction of the texture coordinates you have provided by Unity
         }
         ENDCG 
      }
   } 	
}