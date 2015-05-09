Shader "Custom/Shadows" {
    Properties {
        _MainTex ("Greenscreen", 2D) = "white" {}
        _DirectionX ("Direction X", Float) = 0.03
        _DirectionY ("Direction Y", Float) = 0.03
        _ShadowOffset ("Offset", Float) = 2
        _ShadowStrength ("Shadow Strength", Float) = 0.3
        _ColorInside ("Color Inside", Color) = (1,1,1,1)
        _ColorOutside ("Color Outside", Color) = (0,0,0,1)
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma target 3.0
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "../../Shaders/noiseSimplex.cginc"
            #include "../../Shaders/dither.cginc"
            
            uniform fixed _DirectionX;
            uniform fixed _DirectionY;
            uniform fixed _ShadowOffset;
            uniform fixed _ShadowStrength;
            uniform sampler2D _MainTex;
            
            uniform fixed4 _ColorInside;
            uniform fixed4 _ColorOutside;
            
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
            
            fixed4 getBgColor(fixed2 coords){
            	//return tex2D(_Background, float2(coords.x+_BackgroundOffsetX, (coords.y/_BackgroundAspectRatio)+_BackgroundOffsetY)/_BackgroundScale);
            	fixed4 colorDist = _ColorOutside - _ColorInside;
            	fixed2 dist = abs(fixed2(0.5,0.5) - coords) * 2;
            	fixed4 retColor = _ColorInside + colorDist * sqrt(dist.x*dist.x+dist.y*dist.y);

            	return dither(retColor, coords);
            	//return retColor;
            }
            
            fixed4 frag(v2f_img i) : SV_Target {
            	fixed4 bgColor = getBgColor(i.uv);

                float iterations = 15;
				float effectiveIterations = iterations + _ShadowOffset;
                
                float strongestShadow = 0.0;
            	float iteration;
                for( iteration = 0; iteration < iterations; iteration += 1.0) {
                	float offsetIteration = iteration + _ShadowOffset;
                
                	float xOffset = (offsetIteration/effectiveIterations)*_DirectionX;
                	float yOffset = (offsetIteration/effectiveIterations)*_DirectionY;
                
                	fixed4 fgColor = calcCorrectColor(tex2D(_MainTex, half2(i.uv.x + xOffset, i.uv.y + yOffset)));
            		float strength = (1 - offsetIteration / effectiveIterations) * _ShadowStrength * fgColor.a;
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
