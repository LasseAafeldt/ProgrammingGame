﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Cg per-vertex lighting with texture" {
   Properties {
      _MainTex ("Texture For Diffuse Material Color", 2D) = "white" {} 
      _Color ("Overall Diffuse Color Filter", Color) = (1,1,1,1)
      _SpecColor ("Specular Material Color", Color) = (1,1,1,1) 
      _Shininess ("Shininess", Float) = 10
   }
   SubShader {
      Pass {    //only done for the most important directional light without cookies
         Tags { "LightMode" = "ForwardBase" } 
            // pass for ambient light and first light source
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag
 
         #include "UnityCG.cginc" 
         uniform float4 _LightColor0; 
            // color of light source (from "Lighting.cginc")
 
         // User-specified properties
         uniform sampler2D _MainTex;    
         uniform float4 _Color; 
         uniform float4 _SpecColor; 
         uniform float _Shininess;
 
         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 tex : TEXCOORD0;
            float3 diffuseColor : TEXCOORD1;
            float3 specularColor : TEXCOORD2;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject; 
 
            float3 normalDirection = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            float3 viewDirection = normalize(_WorldSpaceCameraPos 
               - mul(modelMatrix, input.vertex).xyz);
            float3 lightDirection;
            float attenuation;
 
            if (0.0 == _WorldSpaceLightPos0.w) // directional light?
            {
               attenuation = 1.0; // no attenuation
               lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            } 
            else // point or spot light
            {
               float3 vertexToLightSource = _WorldSpaceLightPos0.xyz
                  - mul(modelMatrix, input.vertex).xyz;
               float distance = length(vertexToLightSource);
               attenuation = 1.0 / distance; // linear attenuation 
               lightDirection = normalize(vertexToLightSource);
            }
 
            float3 ambientLighting = 
               UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;
 
            float3 diffuseReflection = 
               attenuation * _LightColor0.rgb * _Color.rgb
               * max(0.0, dot(normalDirection, lightDirection));
 
            float3 specularReflection;
            if (dot(normalDirection, lightDirection) < 0.0) 
               // light source on the wrong side?
            {
               specularReflection = float3(0.0, 0.0, 0.0); 
                  // no specular reflection
            }
            else // light source on the right side
            {
               //specularReflection = attenuation * _LightColor0.rgb 
                 // * _SpecColor.rgb * pow(max(0.0, dot(
                 // reflect(-lightDirection, normalDirection), 
                 // viewDirection)), _Shininess);

                  //the colour of the specular highlights changes according to the texture map
                  specularReflection = attenuation * _LightColor0.rgb 
                  * pow(max(0.0, dot(
                  reflect(-lightDirection, normalDirection), 
                  viewDirection)), _Shininess);
            }
 
            output.diffuseColor = ambientLighting + diffuseReflection; //only the diffuse part should be changed with the texturing, therefore
            output.specularColor = specularReflection; //the specular reflection is outputted separately.
            output.tex = input.texcoord;
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
         //the colour of the specular highlights changes according to the texture map
         return float4(input.specularColor *tex2D(_MainTex, input.tex.xy) +
               input.diffuseColor * tex2D(_MainTex, input.tex.xy),
               1.0);

            //return float4(input.specularColor +
             //  input.diffuseColor * tex2D(_MainTex, input.tex.xy),
             //  1.0); //add the specular colour and diffuse colour and then tinting the colour with a textured image
         }		//the colour of the highlights does not change because it is not multiplied - it is just added.
 
         ENDCG
      }
 
      Pass { // pass for additional light sources 
         Tags { "LightMode" = "ForwardAdd" } 
            
         Blend One One // additive blending 
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc" 
         uniform float4 _LightColor0; 
            // color of light source (from "Lighting.cginc")
 
         // User-specified properties
         uniform sampler2D _MainTex;    
         uniform float4 _Color; 
         uniform float4 _SpecColor; 
         uniform float _Shininess;
 
         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 tex : TEXCOORD0;
            float3 diffuseColor : TEXCOORD1;
            float3 specularColor : TEXCOORD2;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject;
 
            float3 normalDirection = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            float3 viewDirection = normalize(_WorldSpaceCameraPos 
               - mul(modelMatrix, input.vertex).xyz);
            float3 lightDirection;
            float attenuation;
 
            if (0.0 == _WorldSpaceLightPos0.w) // directional light?
            {
               attenuation = 1.0; // no attenuation
               lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            } 
            else // point or spot light
            {
               float3 vertexToLightSource = _WorldSpaceLightPos0.xyz
                  - mul(modelMatrix, input.vertex).xyz;
               float distance = length(vertexToLightSource);
               attenuation = 1.0 / distance; // linear attenuation 
               lightDirection = normalize(vertexToLightSource);
            }
 
            float3 diffuseReflection = 
               attenuation * _LightColor0.rgb * _Color.rgb
               * max(0.0, dot(normalDirection, lightDirection));
 
            float3 specularReflection;
            if (dot(normalDirection, lightDirection) < 0.0) 
               // light source on the wrong side?
            {
               specularReflection = float3(0.0, 0.0, 0.0); 
                  // no specular reflection
            }
            else // light source on the right side
            {
               //specularReflection = attenuation * _LightColor0.rgb 
                 // * _SpecColor.rgb * pow(max(0.0, dot(
                  //reflect(-lightDirection, normalDirection), 
                 // viewDirection)), _Shininess);

                  //the colour of the specular highlights changes according to the texture map
                  specularReflection = attenuation * _LightColor0.rgb 
                  * pow(max(0.0, dot(
                  reflect(-lightDirection, normalDirection), 
                  viewDirection)), _Shininess);
            }
 
            output.diffuseColor = diffuseReflection; // no ambient
            output.specularColor = specularReflection;
            output.tex = input.texcoord;
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
           // return float4(input.specularColor +
            //   input.diffuseColor * tex2D(_MainTex, input.tex.xy),
            //   1.0);

               //the colour of the specular highlights changes according to the texture map
         return float4(input.specularColor *tex2D(_MainTex, input.tex.xy) +
               input.diffuseColor * tex2D(_MainTex, input.tex.xy),
               1.0);
         }
 
         ENDCG
      }
   }
   Fallback "Specular"
}