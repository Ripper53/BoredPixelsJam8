# BoredPixelsJam8

Link to game: https://ripper53.itch.io/spinny-blade

## Process
The A.I. uses sensors to retrieve data that will be processed through a system into its appropriate output. Ex. Wandering if there is no target in sight, jumping if there is a platform above, or chasing its target while avoiding obstacles it detects with its sensors. The pro is the A.I. can be dropped into any level and it will work with its environment, the con is the A.I. cannot take advantage of more complex systems such as pathfinding. However, I did not find a need for more complex systems to accomplish the goals of the A.I. when they could be solved with simpler and self-contained solutions.

The walk animations have three frames. One for each leg interval, so right leg forward and left leg back, and right leg back and left leg forward. The in-between frame was the idle frame. In total, only three frames were needed. The idle frame (which would be used as the middle frame for the walk animation), and two frames for the walk animation.

## What I Learned
The player controls were too slippery. The acceleration and deceleration numbers could be easily adjusted using Unity’s inspector, but in the state the game was released, the controls sometimes felt like walking on ice. Moving forward, I will try to make the controls feel more responsive while trying to preserve the difficulty. Having a long deceleration did not help to accomplish fair difficulty. I will keep in mind to have the controls work for the player instead of against them.
