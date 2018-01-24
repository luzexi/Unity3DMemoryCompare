using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryInfo
{
	public Texture tex;
	public int size;
	public string name;
}

public enum MEMORY_STATUS
{
	NONE,
	NEW,
	REMOVE,
}

public class MemoryInfoCompare
{
	public int frameCount;
	public string name;
	public int size;
	public MEMORY_STATUS status;
}
