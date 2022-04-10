Name: Player
Summary: Controllable 2D player character
Description: This prefab is for a 2D player character.

Components:
Rigidbody2D: This component is used for Unity's physics calculations

PlayerClass Script: This script keeps track of things like player health, strength, speed,
		    and inventory (if using inventory scripts as well).
		    Also allows for character movement, attacking, dodging.

Box Collider 2D: This component is the player's collider to handle collisions with the world and other objects.

Box Collider 2D: This component is a trigger for the player that is slightly larger than the player.
		 It helps make it easier for the player to pick up items and interact with NPC's and enemies

Animator: This component provides the player with various animations that depend on the player character's current state