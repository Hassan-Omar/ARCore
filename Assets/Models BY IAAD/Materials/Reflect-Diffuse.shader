// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Mobile/Reflective/Diffuse" {
Properties {
    _Ref ("Reflection Strength", Range (0, 1)) = 1
    _Color ("Main Color", 2D) = "white" {}
    _ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
    _Cube ("Reflection Cubemap", Cube) = "_Skybox" {}
}
SubShader {
    LOD 200
    Tags { "RenderType"="Opaque" }

CGPROGRAM
#pragma surface surf Lambert


samplerCUBE _Cube;
sampler2D _Color;

fixed4 _ReflectColor;
float _Ref;

struct Input {
    float2 uv_Color;
    float3 worldRefl;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 col = tex2D(_Color, IN.uv_Color);
    fixed4 c = col * col;
    o.Albedo = c.rgb;

    fixed4 reflcol = texCUBE (_Cube, IN.worldRefl);
    reflcol *= _Ref;
    o.Emission = reflcol.rgb * _ReflectColor.rgb;
    o.Alpha = reflcol.a * _ReflectColor.a;
}
ENDCG
}

FallBack "Legacy Shaders/Reflective/VertexLit"
}
