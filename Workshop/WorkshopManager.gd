extends Node

signal item_selected


var tilemap

func _ready():
	connect("item_selected", Callable(self, "item_select"))



func item_select(texture: Texture2D):
	var block = load("res://Workshop/Block.tscn").instantiate()
	block.texture = texture
	
	if texture.get_size().y > 16:
		block.offset.y = -16
	
	
	get_tree().call_group("OfficeGroup", "place_object", block)
