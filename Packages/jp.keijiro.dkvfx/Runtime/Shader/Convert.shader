Shader "Hidden/Dkvfx/Convert"
{
    CGINCLUDE

    #include "UnityCG.cginc"
    #include "Common.hlsl"

    sampler2D _MainTex;
    float4 _MainTex_TexelSize;

    void Vertex(
        uint vertex_id : SV_VertexID,
        out float4 position : SV_Position,
        out float2 texcoord : TEXCOORD0
    )
    {
        texcoord = float2(
            vertex_id == 1 ? 2 : 0,
            vertex_id > 1 ? 2 : 0
        );

        position = float4(
            texcoord.x * 2 - 1,
            1 - texcoord.y * 2,
            1, 1
        );
    }

    void Fragment(
        float4 position : SV_Position,
        float2 texcoord : TEXCOORD0,
        out float4 out_position : SV_Target0,
        out float4 out_color : SV_Target1
    )
    {
        float3 depth_sample = tex2D(_MainTex, DepthUV(texcoord)).rgb;
        float3 color_sample = tex2D(_MainTex, ColorUV(texcoord)).rgb;
        out_position = float4(DepthToPosition(texcoord, depth_sample), 1);
        out_color = float4(color_sample, ValidateDepth(depth_sample));
    }

    ENDCG

    SubShader
    {
        Pass
        {
            Cull Off
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}
