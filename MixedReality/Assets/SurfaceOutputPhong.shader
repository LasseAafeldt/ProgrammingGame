Shader "Example/Diffuse Simple" {
	Properties {
		_SpecColor ("Specular", Color) = (1,1,1)
	}
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf BlinnPhong

      struct Input {
          float4 color : COLOR;
      };

      //SurfaceOutput can be changed to one of the other output structures, SurfaceOutputStandard or SurfaceOutputStandardSpecular.These has other outputs. 
      void surf (Input IN, inout SurfaceOutput o) {
      //you can use albedo and emission together or separately
          //o.Albedo = float3(1,1,1); //setting the diffuse color to white. You can also just write o.Albedo = 1; You have the shading from the lightsource.
          //o.Emission = float3(1,1,0); //the difference is that there is no shading as when using Albedo. The emission does not care about the light source - it just outputs the colour
 		  //o.Emission = o.Normal; //The normal vector is defined in worldspace - if rotated, it does not change.
 		  //o.Normal = float3(1,1,0); //probably do not write to the surface normal in the surface output.
          o.Gloss = 1.0;
          o.Specular = 0.5;
      }
      ENDCG
    }
    Fallback "Diffuse"
  }