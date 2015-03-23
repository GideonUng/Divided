Shader "Custom/Shadows" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Background ("Background", 2D) = "white" {}
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
            uniform sampler2D _Background;

			fixed calcAlpha(fixed4 color){
				if(color.r < color.b){
					return color.g - color.r;
				} else {
					return color.g - color.b;
				}
			}
			
			fixed4 calcCorrectColor(fixed4 color) {
				fixed alpha = calcAlpha(color);
				
				//return fixed4(color.r, color.g - (alpha), color.b, color.a);
				return fixed4(0.0, 0.0, 0.0, color.a);
			}

            fixed blend(fixed background, fixed foreground, fixed alpha){
            	return background * (1-alpha) + alpha * foreground;
            }

            fixed4 blend(fixed4 background, fixed4 foreground, fixed alpha){
            	return fixed4(blend(background.r, foreground.r, alpha),blend(background.g, foreground.g, alpha),blend(background.b, foreground.b, alpha),1.0);
            }
            
            fixed4 frag(v2f_img i) : SV_Target {
            	//fixed4 correctColor = calcCorrectColor(tex2D(_MainTex, i.uv));
            	//return blend(tex2D(_Background, i.uv), correctColor, correctColor.a);

            	fixed4 bgColor = tex2D(_Background, i.uv);
                        
            	float shadowLength = 0.03;
                float iterations = 15;
                float shadowStrength = 0.3;
                
                float strongestShadow = 0.0;
                float iteration = 0;
                for( iteration = shadowLength/iterations; iteration <= shadowLength; iteration += shadowLength/iterations) {
                	fixed4 fgColor = calcCorrectColor(tex2D(_MainTex, half2(i.uv.x + iteration, i.uv.y + iteration)));
            		float strength = (1 - iteration / shadowLength) * shadowStrength * fgColor.a;
            		strongestShadow = max(strongestShadow, strength);
                }
                
                bgColor = blend(bgColor, fixed4(0.0, 0.0, 0.0, 1.0), strongestShadow);
                return bgColor;
                fixed4 localFgColor = calcCorrectColor(tex2D(_MainTex, i.uv));
                return blend(bgColor, localFgColor, localFgColor.a);
            }
            
            ENDCG
        }
    }
}
