Shader "Custom/PerfectBubble"
{
    Properties
    {
        _BaseColor ("Inner Clear Tint", Color) = (1, 1, 1, 0.02)
        _RimColor ("White Rim Glow", Color) = (1, 1, 1, 0.6)
        _FresnelPower ("Fresnel Sharpness", Range(0.5, 7.0)) = 3.5
        _IridescenceStrength ("Rainbow Opacity", Range(0.0, 1.0)) = 0.25
        _IridescenceSpeed ("Color Shift Speed", Range(0.1, 5.0)) = 0.8
        
        [HideInInspector] _WaveTime ("Wave Time", Float) = 0
        [HideInInspector] _WaveScale ("Wave Scale", Float) = 0.05
    }
    
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        LOD 200
        
        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float4 worldPos : TEXCOORD2;
            };

            fixed4 _BaseColor;
            fixed4 _RimColor;
            float _FresnelPower;
            float _IridescenceStrength;
            float _IridescenceSpeed;
            float _WaveTime;
            float _WaveScale;

            v2f vert (appdata v)
            {
                v2f o;
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
                
                // Keep the wobble vertex displacement from before
                float wave = sin(worldPos.x * 2.0 + _WaveTime) * 
                             cos(worldPos.y * 2.0 + _WaveTime) * 
                             sin(worldPos.z * 2.0 + _WaveTime);
                             
                v.vertex.xyz += v.normal * wave * _WaveScale;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                o.worldPos = worldPos;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float3 viewDir = normalize(i.viewDir);

                // 1. Calculate Fresnel Rim
                float rim = 1.0 - saturate(dot(normal, viewDir));
                float fresnel = pow(rim, _FresnelPower);

                // 2. Faint Iridescence (Soft Pastel Rainbow)
                float colorShift = rim * 5.0 + (_WaveTime * _IridescenceSpeed * 0.3);
                fixed3 rainbow;
                rainbow.r = sin(colorShift + 0.0) * 0.5 + 0.5;
                rainbow.g = sin(colorShift + 2.0) * 0.5 + 0.5;
                rainbow.b = sin(colorShift + 4.0) * 0.5 + 0.5;

                // 3. Composite white reflections over the faint rainbow
                // Mix the rainbow into white using the strength slider
                fixed3 finalRimColor = lerp(_RimColor.rgb, rainbow, _IridescenceStrength);

                // 4. Transparency Output
                fixed4 finalColor;
                // Center is clear base color, edges fade into the bright white/pastel rim
                finalColor.rgb = lerp(_BaseColor.rgb, finalRimColor, fresnel);
                
                // Drastically lower the alpha in the center so it stays see-through
                finalColor.a = lerp(_BaseColor.a, _RimColor.a, fresnel);

                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Transparent/VertexLit"
}