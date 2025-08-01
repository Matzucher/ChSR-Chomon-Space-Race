shader_type canvas_item;

//const
const float texelSize = 1.0 / 2048.0;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	//vec2 PixelatedUV = UV - (0.5 * floor(UV/0.5));
	vec2 PixelatedUV = floor(UV * 16384.0) / 16384.0;
	//PixelatedUV = PixelatedUV - (0.1 * floor(UV/0.1));
	COLOR = vec4(0.0, 0.0, 0.0, 0.0);

	if ((PixelatedUV.x -0.5)*(PixelatedUV.x -0.5) + (PixelatedUV.y -0.5)*(PixelatedUV.y -0.5) < 0.25){
		COLOR = ((texture(TEXTURE, fract(PixelatedUV * 16.0))) + (texture(TEXTURE, PixelatedUV)) + (texture(TEXTURE, fract((PixelatedUV  * 4.0) + (texelSize) * 3.0))) - 1.3) * 2.0;
		//COLOR = (texture(TEXTURE, fract(UV * 1.0)) * 1.0);

		if (texture(TEXTURE, fract(PixelatedUV + (0.0016666666666666666 * TIME))).b > 0.8){
			COLOR = texture(TEXTURE, fract(PixelatedUV + (0.0016666666666666666 * TIME)));
		}
		if (texture(TEXTURE, fract(PixelatedUV + vec2((0.0026666666666666666 * TIME), (0.0024666666666666666 * TIME)))).b < 0.2){
			COLOR = vec4(1.0, 1.0, 1.0, 1.0) - texture(TEXTURE, fract(PixelatedUV + (0.0016666666666666666 * TIME)));
		}
		COLOR.r = COLOR.r * ((PixelatedUV.x * 0.8) + 0.2);
		COLOR.g = COLOR.g * ((PixelatedUV.x * 0.8) + 0.2);
		COLOR.b = COLOR.b * ((PixelatedUV.x * 0.8) + 0.2);

		//+ (texture(TEXTURE, fract(PixelatedUV * 1.0 + (texelSize * 2.0)))) * vec4(0.1, 0.1, 0.1, 1.0)
		//+ (texture(TEXTURE, fract(PixelatedUV * 1.0 + (texelSize * 5.0)))) * vec4(0.1, 0.1, 0.1, 1.0));
		COLOR.a = 1.0;
		//COLOR = (texture(TEXTURE, fract(PixelatedUV + (0.0016666666666666666 * TIME)))) + (texture(TEXTURE, fract(PixelatedUV * 32.0 + (texelSize * 2.0))) - 0.5);
		//vec2 textureStep = textureSize(TEXTURE, 0).x;
	}
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
