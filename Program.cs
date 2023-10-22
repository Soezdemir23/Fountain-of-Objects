// See https://aka.ms/new-console-template for more information
/*
 * + 2d array nxn
 * + there is north east south and west
 * + most rooms are empty rooms and nothing else
 * + player has to enter commands like:
 *   + move north
 *   + move east
 *   + move south
 *   + move west
 * + (0,0) is the entrance of the cave and also the exit. Starting position. Can 
 *   see light coming from outside when in that room
 *   + "You see light in this room coming from outside the cavern. 
 *     This is the entrance."
 * + (0,2) is the fountain room, containing the fountain of objects itself. 
 *   + Can be enabled or disabled
 *      + if disabled: "You hear the water dripping from the fountain. 
 *        The Fountain of Objects is here!"
 *      + if enabled: "You hear the rushing waters from the Fountain of Objects. 
 *        It has been reactivated!"
 *      + off by default
 *      + can be enabled in the fountain room, if the user types "enable fountain"
 *        inside the fountain room only.
 * + player wins,if they enter the exit room with the object from the fountain enabled
 * + use different colors to emphasis different type of text.
 *  + intro, ending, etc. in magenta
 *  + input from the user in cyan
 *  + descriptive text in white
 *  
 *  We have a field parent class
 *  We have an entity parent class
 *  We have a gameboard class
 *  We have a text parent class
 *  We have a class that handles the game logic
 */

using Fountain_of_Objects;

new Gameboard();
