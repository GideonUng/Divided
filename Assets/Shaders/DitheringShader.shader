Shader "Custom/DitheringShader" {
    Properties {
        _ColorLeft ("Color Left", Color) = (0.13333333,0.13333333,0.13333333,1)
        _ColorRight ("Color Right", Color) = (0.1137254901960784,0.1137254901960784,0.1137254901960784,1)
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma target 3.0
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "noiseSimplex.cginc"
            #include "dither.cginc"
            
            uniform fixed4 _ColorLeft;
            uniform fixed4 _ColorRight;

            fixed4 frag(v2f_img i) : SV_Target {
            	fixed4 colorDist = _ColorLeft - _ColorRight;
            	fixed2 dist = abs(fixed2(0.5,0.5) - i.uv);
            	fixed4 retColor = _ColorRight + colorDist * sqrt(dist.x*dist.x+dist.y*dist.y);

            	return dither(retColor, i.uv);
            	//return retColor;
            }
            
            ENDCG
        }
    }
}
