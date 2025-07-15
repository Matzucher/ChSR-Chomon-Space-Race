extends Panel


@export var item_name: String

var texture_inside: Texture2D = null


func _ready():
	texture_inside = load("res://Workshop/%s.png" % item_name)
	$TextureRect.texture = texture_inside


func _on_Slot_gui_input(event):
	if event is InputEventMouseButton && event.pressed && event.button_index == MOUSE_BUTTON_LEFT:
		WorkshopManager.emit_signal("item_selected", texture_inside)
