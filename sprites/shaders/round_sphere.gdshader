shader_type canvas_item;

void vertex() {
	// Called for every vertex the material is visible on.
}

//const 

void fragment() {
	COLOR = vec4(0.0, 0.0, 0.0, 0.0);
	if ((UV.x -0.5)*(UV.x -0.5) + (UV.y -0.5)*(UV.y -0.5) < 0.25){
		COLOR = (texture(TEXTURE, fract(UV * 16.0)) * 0.6) + (texture(TEXTURE, UV) * 0.6) + (texture(TEXTURE, fract(UV * 2.0)) * 0.5) - 0.7;
		//COLOR = (texture(TEXTURE, fract(UV * 1.0)) * 1.0);
		//vec2 textureStep = textureSize(TEXTURE, 0).x;
	}
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
