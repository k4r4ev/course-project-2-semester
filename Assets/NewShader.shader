Shader "Custom/Hologram" {
    Properties{
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimPower("Rim Power", Range(0.5,8)) = 3
    }

        SubShader{
            Tags { "Queue" = "Transparent" }

            Pass {
                ZWrite On            // write depth data to z-buffer
                ColorMask 0            // but won't write color to frame buffer
            }
            CGPROGRAM

            #pragma surface surf Lambert alpha:fade

            float4 _RimColor;
            float _RimPower;

            struct Input {
                float3 viewDir;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                half dotp = dot(normalize(IN.viewDir), o.Normal);
                half rim = 1 - saturate(dotp);
                float rimPow = pow(rim,_RimPower);
                o.Emission = _RimColor.rgb * rimPow;
                o.Alpha = rimPow;
            }
            ENDCG
    }
        FallBack "Diffuse"
}