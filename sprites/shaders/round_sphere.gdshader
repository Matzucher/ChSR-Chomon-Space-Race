shader_type canvas_item;

//const 
const float texelSize = 1.0 / 2048.0;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	COLOR = vec4(0.0, 0.0, 0.0, 0.0);
	if ((UV.x -0.5)*(UV.x -0.5) + (UV.y -0.5)*(UV.y -0.5) < 0.25){
		//COLOR = (texture(TEXTURE, fract(UV * 32.0))) + (texture(TEXTURE, UV)) + (texture(TEXTURE, fract(UV + (0.005 * TIME)))) + (texture(TEXTURE, fract((UV  * 4.0) + (texelSize) * 3.0))) - 2.0;
		//COLOR = (texture(TEXTURE, fract(UV * 1.0)) * 1.0);
		COLOR = ((texture(TEXTURE, fract(UV + (0.0016666666666666666 * TIME))) * vec4(0.9, 0.9, 0.6, 1.0))
		* (texture(TEXTURE, fract(UV * 1.0 + (texelSize * 2.0))))) + (fract(texture(TEXTURE, fract(UV * 16.0)) - 0.4) * 0.2);
		
		//COLOR = (texture(TEXTURE, fract(UV + (0.0016666666666666666 * TIME)))) + (texture(TEXTURE, fract(UV * 32.0 + (texelSize * 2.0))) - 0.5);
		//vec2 textureStep = textureSize(TEXTURE, 0).x;
	}
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
