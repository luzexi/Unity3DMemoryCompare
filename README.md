# Unity3DMemoryCompare
Unity3D memory compare every frame in editor


MemoryBehaviour will comapre all of the texture every frame.

If the texture is created or removed from memory, MemoryBehaviour will find it and write in the console.

The only step to start Memory Compare tool is make a new Object and bind with MemoryBehaviour.

The log will show as fellow:

Texture Name | Size | new or remove | frame count

memory info Splash  16 MB -- remove -- frame 34

water  4 MB -- new -- frame 34

Fast_Snow  1 MB -- new -- frame 34

Light_Snow  1 MB -- new -- frame 34

Blizzard_Snow  0.25 MB -- new -- frame 34

t_fx_water  0.25 MB -- new -- frame 34

EN_LevelUp_SD  0.1562119 MB -- new -- frame 34

callingcard_16  0.1441956 MB -- new -- frame 34
