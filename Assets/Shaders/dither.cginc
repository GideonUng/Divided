#ifndef DITHER_FUNC
#define DITHER_FUNC

//include "noiseSimplex.cginc"

fixed4 dither(fixed4 desiredColor, fixed2 coords){
	fixed4 roundedRetColor = (round(desiredColor*255) / 255);
	
	fixed4 ditheredRetColor=roundedRetColor;
	
	ditheredRetColor = round(desiredColor*255+snoise(coords*1000))/255;
	
	return ditheredRetColor;
}

#endif