// Shader created with Shader Forge v1.42 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Enhanced by Antoine Guillon / Arkham Development - http://www.arkham-development.com/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.42;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7843,x:33731,y:32792,varname:node_7843,prsc:2|diff-4679-OUT,spec-7791-RGB,gloss-2617-OUT,normal-3484-OUT,amdfl-1561-OUT,difocc-9520-R,alpha-6724-OUT;n:type:ShaderForge.SFN_TexCoord,id:8531,x:31340,y:32793,varname:node_8531,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:1114,x:33461,y:32293,varname:node_1114,prsc:2,uv:2,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:8438,x:31340,y:32625,ptovrint:False,ptlb:WaveNM,ptin:_WaveNM,varname:node_8438,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:8715,x:32204,y:32822,varname:node_8715,prsc:2,ntxv:0,isnm:False|UVIN-7260-UVOUT,TEX-8438-TEX;n:type:ShaderForge.SFN_Panner,id:7260,x:32036,y:32822,varname:node_7260,prsc:2,spu:1,spv:2|UVIN-8531-UVOUT,DIST-2398-OUT;n:type:ShaderForge.SFN_Panner,id:6342,x:32036,y:32949,varname:node_6342,prsc:2,spu:2,spv:1|UVIN-8531-UVOUT,DIST-2398-OUT;n:type:ShaderForge.SFN_Tex2d,id:8063,x:32204,y:32949,varname:node_8063,prsc:2,ntxv:0,isnm:False|UVIN-6342-UVOUT,TEX-8438-TEX;n:type:ShaderForge.SFN_Slider,id:6215,x:32345,y:32312,ptovrint:False,ptlb:Glossy,ptin:_Glossy,varname:node_6215,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:4435,x:32757,y:31592,ptovrint:False,ptlb:WaterColor,ptin:_WaterColor,varname:node_4435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Time,id:7558,x:31648,y:32959,varname:node_7558,prsc:2;n:type:ShaderForge.SFN_Slider,id:3582,x:31340,y:32974,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_3582,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:2398,x:31817,y:32959,varname:node_2398,prsc:2|A-3582-OUT,B-7558-TSL;n:type:ShaderForge.SFN_Tex2d,id:7961,x:32170,y:33140,ptovrint:False,ptlb:DnoNM,ptin:_DnoNM,varname:node_7961,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:7118,x:32551,y:32822,varname:node_7118,prsc:2|A-2119-OUT,B-7961-RGB,T-5171-R;n:type:ShaderForge.SFN_VertexColor,id:5171,x:32764,y:33074,varname:node_5171,prsc:2;n:type:ShaderForge.SFN_Color,id:7771,x:32535,y:31641,ptovrint:False,ptlb:DnoColor,ptin:_DnoColor,varname:node_7771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:8559,x:32900,y:31851,varname:node_8559,prsc:2|A-1198-OUT,B-1337-OUT,T-5171-R;n:type:ShaderForge.SFN_Lerp,id:2617,x:32673,y:32285,varname:node_2617,prsc:2|A-6215-OUT,B-7338-OUT,T-5171-R;n:type:ShaderForge.SFN_Vector1,id:7338,x:32345,y:32389,varname:node_7338,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:6724,x:32861,y:33375,varname:node_6724,prsc:2|A-4925-OUT,B-307-OUT,T-5171-R;n:type:ShaderForge.SFN_Slider,id:4925,x:32326,y:33319,ptovrint:False,ptlb:WaterOpasity,ptin:_WaterOpasity,varname:node_4925,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:3867,x:32342,y:33435,varname:node_3867,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2dAsset,id:931,x:31866,y:31837,ptovrint:False,ptlb:WaterShadow,ptin:_WaterShadow,varname:node_931,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2489,x:32054,y:31798,varname:node_2489,prsc:2,ntxv:0,isnm:False|UVIN-7260-UVOUT,TEX-931-TEX;n:type:ShaderForge.SFN_Tex2d,id:5737,x:32054,y:31929,varname:node_5737,prsc:2,ntxv:0,isnm:False|UVIN-6342-UVOUT,TEX-931-TEX;n:type:ShaderForge.SFN_Multiply,id:3405,x:32225,y:31798,varname:node_3405,prsc:2|A-2489-RGB,B-5737-RGB;n:type:ShaderForge.SFN_Multiply,id:1337,x:32535,y:31821,varname:node_1337,prsc:2|A-7771-RGB,B-3405-OUT;n:type:ShaderForge.SFN_NormalBlend,id:2119,x:32379,y:32822,varname:node_2119,prsc:2|BSE-8715-RGB,DTL-8063-RGB;n:type:ShaderForge.SFN_Lerp,id:3484,x:32723,y:32822,varname:node_3484,prsc:2|A-7118-OUT,B-6297-OUT,T-5171-G;n:type:ShaderForge.SFN_Vector3,id:6297,x:32551,y:32950,varname:node_6297,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Color,id:7791,x:32345,y:32150,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_7791,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1561,x:34042,y:32459,varname:node_1561,prsc:2|A-5790-OUT,B-9520-RGB;n:type:ShaderForge.SFN_Tex2d,id:9520,x:33630,y:32293,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_9520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1114-UVOUT;n:type:ShaderForge.SFN_Slider,id:5790,x:33770,y:32137,ptovrint:False,ptlb:AOPower,ptin:_AOPower,varname:node_5790,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:3976,x:30495,y:32474,ptovrint:False,ptlb:PenaMask,ptin:_PenaMask,varname:node_3976,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9837-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5091,x:30809,y:32692,ptovrint:False,ptlb:PenaNM,ptin:_PenaNM,varname:node_5091,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_TexCoord,id:5359,x:30222,y:32147,varname:node_5359,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:4846,x:30798,y:32461,ptovrint:False,ptlb:Pena,ptin:_Pena,varname:node_4846,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9198,x:31102,y:31733,varname:node_9198,prsc:2,ntxv:0,isnm:False|UVIN-3992-UVOUT,TEX-4846-TEX;n:type:ShaderForge.SFN_Lerp,id:3316,x:32885,y:31995,varname:node_3316,prsc:2|A-8559-OUT,B-7611-OUT,T-3976-RGB;n:type:ShaderForge.SFN_Add,id:4679,x:32900,y:32148,varname:node_4679,prsc:2|A-8559-OUT,B-3316-OUT;n:type:ShaderForge.SFN_Color,id:5418,x:31102,y:31577,ptovrint:False,ptlb:AddPena,ptin:_AddPena,varname:node_5418,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:7057,x:31358,y:31813,varname:node_7057,prsc:2|A-5418-RGB,B-9198-RGB;n:type:ShaderForge.SFN_Panner,id:3992,x:30851,y:31887,varname:node_3992,prsc:2,spu:1,spv:2|UVIN-5359-UVOUT,DIST-2398-OUT;n:type:ShaderForge.SFN_Panner,id:7090,x:30862,y:32062,varname:node_7090,prsc:2,spu:2,spv:1|UVIN-5359-UVOUT,DIST-2398-OUT;n:type:ShaderForge.SFN_Tex2d,id:3728,x:31102,y:31865,varname:node_3728,prsc:2,ntxv:0,isnm:False|UVIN-7090-UVOUT,TEX-4846-TEX;n:type:ShaderForge.SFN_Add,id:2262,x:31358,y:31943,varname:node_2262,prsc:2|A-5418-RGB,B-3728-RGB;n:type:ShaderForge.SFN_Blend,id:7611,x:31606,y:31778,varname:node_7611,prsc:2,blmd:1,clmp:False|SRC-7057-OUT,DST-2262-OUT;n:type:ShaderForge.SFN_Panner,id:9837,x:30304,y:32404,varname:node_9837,prsc:2,spu:10,spv:0|UVIN-5359-UVOUT,DIST-2398-OUT;n:type:ShaderForge.SFN_Blend,id:6741,x:32757,y:31388,varname:node_6741,prsc:2,blmd:1,clmp:False|SRC-4435-RGB,DST-8541-RGB;n:type:ShaderForge.SFN_Lerp,id:1198,x:33273,y:31523,varname:node_1198,prsc:2|A-6741-OUT,B-4435-RGB,T-7214-OUT;n:type:ShaderForge.SFN_Tex2d,id:1988,x:33709,y:31174,ptovrint:False,ptlb:WaterMask,ptin:_WaterMask,varname:node_1988,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7260-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8541,x:33031,y:31212,varname:node_8541,prsc:2,ntxv:0,isnm:False|UVIN-5280-OUT,TEX-4846-TEX;n:type:ShaderForge.SFN_Multiply,id:5280,x:33560,y:31767,varname:node_5280,prsc:2|A-5675-OUT,B-7260-UVOUT;n:type:ShaderForge.SFN_Slider,id:5675,x:33236,y:31767,ptovrint:False,ptlb:PenaTiling,ptin:_PenaTiling,varname:node_5675,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:100;n:type:ShaderForge.SFN_Color,id:743,x:33709,y:31362,ptovrint:False,ptlb:WaterMaskPower,ptin:_WaterMaskPower,varname:node_743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:7214,x:33981,y:31267,varname:node_7214,prsc:2,blmd:10,clmp:True|SRC-1988-RGB,DST-743-RGB;n:type:ShaderForge.SFN_Slider,id:307,x:32441,y:33558,ptovrint:False,ptlb:DnoOpacity,ptin:_DnoOpacity,varname:node_307,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:4435-3582-4925-307-6215-7791-8438-7961-7771-931-9520-5790-3976-4846-5418-1988-5675-743;pass:END;sub:END;*/

Shader "Custom/WaterAR" {
    Properties {
        _WaterColor ("WaterColor", Color) = (0.5,0.5,0.5,1)
        _WaveSpeed ("WaveSpeed", Range(0, 5)) = 0
        _WaterOpasity ("WaterOpasity", Range(0, 1)) = 0
        _DnoOpacity ("DnoOpacity", Range(0, 1)) = 0
        _Glossy ("Glossy", Range(0, 1)) = 0
        _Specular ("Specular", Color) = (0.5,0.5,0.5,1)
        _WaveNM ("WaveNM", 2D) = "bump" {}
        _DnoNM ("DnoNM", 2D) = "bump" {}
        _DnoColor ("DnoColor", Color) = (0.5,0.5,0.5,1)
        _WaterShadow ("WaterShadow", 2D) = "white" {}
        _AO ("AO", 2D) = "white" {}
        _AOPower ("AOPower", Range(0, 1)) = 0
        _PenaMask ("PenaMask", 2D) = "white" {}
        _Pena ("Pena", 2D) = "white" {}
        _AddPena ("AddPena", Color) = (0.5,0.5,0.5,1)
        _WaterMask ("WaterMask", 2D) = "white" {}
        _PenaTiling ("PenaTiling", Range(0, 100)) = 0
        _WaterMaskPower ("WaterMaskPower", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite On
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif //UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _WaveNM; uniform float4 _WaveNM_ST;
            uniform float _Glossy;
            uniform float4 _WaterColor;
            uniform float _WaveSpeed;
            uniform sampler2D _DnoNM; uniform float4 _DnoNM_ST;
            uniform float4 _DnoColor;
            uniform float _WaterOpasity;
            uniform sampler2D _WaterShadow; uniform float4 _WaterShadow_ST;
            uniform float4 _Specular;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform float _AOPower;
            uniform sampler2D _PenaMask; uniform float4 _PenaMask_ST;
            uniform sampler2D _Pena; uniform float4 _Pena_ST;
            uniform float4 _AddPena;
            uniform sampler2D _WaterMask; uniform float4 _WaterMask_ST;
            uniform float _PenaTiling;
            uniform float4 _WaterMaskPower;
            uniform float _DnoOpacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7558 = _Time;
                float node_2398 = (_WaveSpeed*node_7558.r);
                float2 node_7260 = (i.uv0+node_2398*float2(1,2));
                float3 node_8715 = UnpackNormal(tex2D(_WaveNM,TRANSFORM_TEX(node_7260, _WaveNM)));
                float2 node_6342 = (i.uv0+node_2398*float2(2,1));
                float3 node_8063 = UnpackNormal(tex2D(_WaveNM,TRANSFORM_TEX(node_6342, _WaveNM)));
                float3 node_2119_nrm_base = node_8715.rgb + float3(0,0,1);
                float3 node_2119_nrm_detail = node_8063.rgb * float3(-1,-1,1);
                float3 node_2119_nrm_combined = node_2119_nrm_base*dot(node_2119_nrm_base, node_2119_nrm_detail)/node_2119_nrm_base.z - node_2119_nrm_detail;
                float3 node_2119 = node_2119_nrm_combined;
                float3 _DnoNM_var = UnpackNormal(tex2D(_DnoNM,TRANSFORM_TEX(i.uv0, _DnoNM)));
                float3 normalLocal = lerp(lerp(node_2119,_DnoNM_var.rgb,i.vertexColor.r),float3(0,0,1),i.vertexColor.g);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_Glossy,0.0,i.vertexColor.r);
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = _Specular.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv2, _AO));
                indirectDiffuse += (_AOPower*_AO_var.rgb); // Diffuse Ambient Light
                indirectDiffuse *= _AO_var.r; // Diffuse AO
                float2 node_5280 = (_PenaTiling*node_7260);
                float4 node_8541 = tex2D(_Pena,TRANSFORM_TEX(node_5280, _Pena));
                float4 _WaterMask_var = tex2D(_WaterMask,TRANSFORM_TEX(node_7260, _WaterMask));
                float4 node_2489 = tex2D(_WaterShadow,TRANSFORM_TEX(node_7260, _WaterShadow));
                float4 node_5737 = tex2D(_WaterShadow,TRANSFORM_TEX(node_6342, _WaterShadow));
                float3 node_8559 = lerp(lerp((_WaterColor.rgb*node_8541.rgb),_WaterColor.rgb,saturate(( _WaterMaskPower.rgb > 0.5 ? (1.0-(1.0-2.0*(_WaterMaskPower.rgb-0.5))*(1.0-_WaterMask_var.rgb)) : (2.0*_WaterMaskPower.rgb*_WaterMask_var.rgb) ))),(_DnoColor.rgb*(node_2489.rgb*node_5737.rgb)),i.vertexColor.r);
                float2 node_3992 = (i.uv1+node_2398*float2(1,2));
                float4 node_9198 = tex2D(_Pena,TRANSFORM_TEX(node_3992, _Pena));
                float2 node_7090 = (i.uv1+node_2398*float2(2,1));
                float4 node_3728 = tex2D(_Pena,TRANSFORM_TEX(node_7090, _Pena));
                float2 node_9837 = (i.uv1+node_2398*float2(10,0));
                float4 _PenaMask_var = tex2D(_PenaMask,TRANSFORM_TEX(node_9837, _PenaMask));
                float3 diffuseColor = (node_8559+lerp(node_8559,((_AddPena.rgb+node_9198.rgb)*(_AddPena.rgb+node_3728.rgb)),_PenaMask_var.rgb));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,lerp(_WaterOpasity,_DnoOpacity,i.vertexColor.r));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDADD
            #define UNITY_PASS_FORWARDADD
            #endif //UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _WaveNM; uniform float4 _WaveNM_ST;
            uniform float _Glossy;
            uniform float4 _WaterColor;
            uniform float _WaveSpeed;
            uniform sampler2D _DnoNM; uniform float4 _DnoNM_ST;
            uniform float4 _DnoColor;
            uniform float _WaterOpasity;
            uniform sampler2D _WaterShadow; uniform float4 _WaterShadow_ST;
            uniform float4 _Specular;
            uniform sampler2D _PenaMask; uniform float4 _PenaMask_ST;
            uniform sampler2D _Pena; uniform float4 _Pena_ST;
            uniform float4 _AddPena;
            uniform sampler2D _WaterMask; uniform float4 _WaterMask_ST;
            uniform float _PenaTiling;
            uniform float4 _WaterMaskPower;
            uniform float _DnoOpacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                float4 vertexColor : COLOR;
                UNITY_LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                UNITY_TRANSFER_LIGHTING(o, float2(0,0));
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7558 = _Time;
                float node_2398 = (_WaveSpeed*node_7558.r);
                float2 node_7260 = (i.uv0+node_2398*float2(1,2));
                float3 node_8715 = UnpackNormal(tex2D(_WaveNM,TRANSFORM_TEX(node_7260, _WaveNM)));
                float2 node_6342 = (i.uv0+node_2398*float2(2,1));
                float3 node_8063 = UnpackNormal(tex2D(_WaveNM,TRANSFORM_TEX(node_6342, _WaveNM)));
                float3 node_2119_nrm_base = node_8715.rgb + float3(0,0,1);
                float3 node_2119_nrm_detail = node_8063.rgb * float3(-1,-1,1);
                float3 node_2119_nrm_combined = node_2119_nrm_base*dot(node_2119_nrm_base, node_2119_nrm_detail)/node_2119_nrm_base.z - node_2119_nrm_detail;
                float3 node_2119 = node_2119_nrm_combined;
                float3 _DnoNM_var = UnpackNormal(tex2D(_DnoNM,TRANSFORM_TEX(i.uv0, _DnoNM)));
                float3 normalLocal = lerp(lerp(node_2119,_DnoNM_var.rgb,i.vertexColor.r),float3(0,0,1),i.vertexColor.g);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_Glossy,0.0,i.vertexColor.r);
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = _Specular.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_5280 = (_PenaTiling*node_7260);
                float4 node_8541 = tex2D(_Pena,TRANSFORM_TEX(node_5280, _Pena));
                float4 _WaterMask_var = tex2D(_WaterMask,TRANSFORM_TEX(node_7260, _WaterMask));
                float4 node_2489 = tex2D(_WaterShadow,TRANSFORM_TEX(node_7260, _WaterShadow));
                float4 node_5737 = tex2D(_WaterShadow,TRANSFORM_TEX(node_6342, _WaterShadow));
                float3 node_8559 = lerp(lerp((_WaterColor.rgb*node_8541.rgb),_WaterColor.rgb,saturate(( _WaterMaskPower.rgb > 0.5 ? (1.0-(1.0-2.0*(_WaterMaskPower.rgb-0.5))*(1.0-_WaterMask_var.rgb)) : (2.0*_WaterMaskPower.rgb*_WaterMask_var.rgb) ))),(_DnoColor.rgb*(node_2489.rgb*node_5737.rgb)),i.vertexColor.r);
                float2 node_3992 = (i.uv1+node_2398*float2(1,2));
                float4 node_9198 = tex2D(_Pena,TRANSFORM_TEX(node_3992, _Pena));
                float2 node_7090 = (i.uv1+node_2398*float2(2,1));
                float4 node_3728 = tex2D(_Pena,TRANSFORM_TEX(node_7090, _Pena));
                float2 node_9837 = (i.uv1+node_2398*float2(10,0));
                float4 _PenaMask_var = tex2D(_PenaMask,TRANSFORM_TEX(node_9837, _PenaMask));
                float3 diffuseColor = (node_8559+lerp(node_8559,((_AddPena.rgb+node_9198.rgb)*(_AddPena.rgb+node_3728.rgb)),_PenaMask_var.rgb));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * lerp(_WaterOpasity,_DnoOpacity,i.vertexColor.r),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_SHADOWCASTER
            #define UNITY_PASS_SHADOWCASTER
            #endif //UNITY_PASS_SHADOWCASTER
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
