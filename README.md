# Steering behavior

Simple unity project containing steering behavior. This is one of the subjects that I have learned in Game AI course of Iran Game Development Institute at summer 2021.

You can find the base code repository [here](https://github.com/donamin/ai-in-games/tree/master/SteeringBehaviors).
As can be seen, the base project only implemented Seek And Flee, Arrive and Align behavior. I have added face, pursue, and wandering. In addition, some changes are done on the base code too.
Also, agent script is added that has the option of mixing different behavior with each other.
## Seek And Flee

Seek behavior tries to match the position of the character with the position of the target. On the other hand, flee behavior tries to get as far from the target as possible.

This effect can be seen in the following video. Seek agent is shown with green color and the flee one has red color. 

<p align="center">
  <img src="https://github.com/NamiNaziri/Steering_Behavior/blob/main/Misc/SeekAndFlee.gif?raw=true" />
</p>


## Arrive

In arrive behavior the character slow downs when is reaching the target.

<p align="center">
  <img src="https://github.com/NamiNaziri/Steering_Behavior/blob/main/Misc/Arrive.gif?raw=true" />
</p>

## Pursue

This behavior is just like seek but in seek we moved base on target position on current frame but in pursue we try to aniticipate where the target will be in the future base on its current velocity.

In the following gif the line trace with green color shows the target destination if this was a seek behavior and the yellow line shows the pursue behavior.

<p align="center">
  <img src="https://github.com/NamiNaziri/Steering_Behavior/blob/main/Misc/Pursue.gif?raw=true" />
</p>
