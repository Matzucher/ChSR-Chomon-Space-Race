shader_type canvas_item;

uniform float relativePosX;
uniform float relativePosY;


const float pixelSize = 1.0 / 4096.0;

//void vertex() {
	//// Called for every vertex the material is visible on.
//}

uint random(vec2 position) {
	position = floor((position * 4096.0));
	uvec2 q = uvec2(position);
	q *= uvec2(1597334677U, 3812015801U);
	uint n = q.x ^ q.y;
	n = n * (n ^ (n >> 15u));

	n = n % 65536u;

	return n;
}

void fragment() {
	vec2 relativePos = vec2(relativePosX, relativePosY);

	vec2 pixelatedUV = floor(UV * 4096.0) / 4096.0;

	vec2 pixelPos = pixelatedUV + relativePos;

	uint random1 = random(pixelPos);
	uint random2 = random(pixelPos);

	float Brightnes = 0.0;
	
	switch (random1){
		case 0u:
			Brightnes = 0.5;
			break;
		case 1u:
			Brightnes = 1.0;
			break;
	}
	
	COLOR = vec4(
	Brightnes,
	Brightnes,
	Brightnes,
	1.0);
	//COLOR = vec4(
	//pixelatedUV.x * 16.0,
	//pixelatedUV.y * 16.0,
	//Brightnes,
	//1.0);
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
