Cloudy Land
by Joey DeMarco

Cloudly land is a simple, one stage platformer that's centered around a "crank puzzle". To open the way to the next area, the play must lower cranks to lower/raise the wall that's in their way. One crank will trigger other cranks along with it, but once all cranks are down, the way is open forever... maybe. To play the game, simply launch the demarj3_platformer exe file (A zipped version of the game has also been included along with all the game's scripts).


Camera Movement:		
	For camera motion, I have the camera as a child of the player.
TileMaps:			
	I have 3 seperate tilemaps. The first is for the ground, the second is for spikes, and the third is to tell the opossums where to reverse speed.
Animations:	
	The player, enemies, and collectables are all animated.
Inheritance:		
	The frog and opossum enemy both inherit from the enemy class. They differ in the way they move and interact with the player, which is made more clear in the respective scripts (opossumScript and frogScript).
Delegates:
	I have a delegate in the crankScript that is responsible for checking for a puzzle completion.
Coroutine:	
	After a puzzle is complete, a sound effect is played, time is paused, and the camera zooms out to show the player the progress they have made from the puzzle and from earlier in the level. The camera then zooms back in and the wall preventing the player from proceeding is lowered/raised. This coroutine can be found in the cameraScript cs file (found in the Scripts directory).
Scene Management:	
	I have a scene manager script to handle moving between scenes.
Joints/Effectors:	
	The first wall that the player is presented with has a joint on its lower left corner. When the player beats the first puzzle, the walls rotation is unfrozen and the door falls down relative to the joint, forming a bridge for the player to walk across.
Known Bugs:
	* Frog jump animation not playing.
	* Player damage animation not playing.
	* Player can maneuver themselves onto the falling platform in such a way to make the player script believe they are still jumping/not grounded.
Future Work:
	* Refinement of how the frog follows the player.
		* Currently the player can stand in place in such a way to have the frog hop to their left and right, avoiding all potential damage.
	* More levels.
	* More puzzles.
	* More enemies.
	* Custom Art (Sprites, Backgrounds, Animation, Tileset, etc).
	* Custom Sound Effects and Music.

press cranks with the action button Z. Puzzle solution are below.











puzzle 1 solution: 1, 4, 3, 2, 1
puzzle 2 solution: 1, 4, 3, 2, 6, 8
puzzle 2 #8 is hidden earlier in the level