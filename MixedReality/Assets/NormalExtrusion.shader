Shader "Example/Normal Extrusion" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _Amount ("Extrusion Amount", Range(-1,1)) = 0.5
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
      };
      //it is easier to work in world coordinates when working with surface shaders than working in local/object coordinates. 

      float _Amount;
      void vert (inout appdata_full v) { //appdata_full is predefined
          v.vertex.xyz += v.normal * _Amount; //v.normal is the pervertex normal in world coordinates. The entire equation is in world coordinates
          //add the normal vector for xyz and times a certain amount. the effect is that you move all the verticies along the normal vector
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }