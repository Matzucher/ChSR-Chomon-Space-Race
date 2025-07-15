extends Node2D


func _ready():
	WorkshopManager.tilemap = $Grid


func place_object(obj):
	$Node2D/Node2D.add_child(obj)
