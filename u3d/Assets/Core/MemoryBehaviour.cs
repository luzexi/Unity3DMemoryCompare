using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBehaviour : MonoBehaviour
{

	private List<MemoryInfo> preList = new List<MemoryInfo>();
	private List<MemoryInfo> currentList = new List<MemoryInfo>();
	private List<List<MemoryInfoCompare>> compareList = new List<List<MemoryInfoCompare>>();


	// Use this for initialization
	void Start ()
	{
		//
	}
	
	// Update is called once per frame
	void Update ()
	{
		preList = currentList;
		currentList = MemoryInfoManager.instance.GetTextureMemory();
		string str = "";
		
		List<MemoryInfoCompare> comparelst = 
			MemoryInfoManager.instance.MemoryCompare(preList, currentList);

		if(comparelst.Count > 0)
		{
			for(int i = 0 ; i<comparelst.Count ; i++)
			{
				str += "" + comparelst[i].name;
				str += "  " + (float)(comparelst[i].size/1024f/256) + " MB";
				if(comparelst[i].status == MEMORY_STATUS.NEW)
				{
					str += " -- new";
				}
				if(comparelst[i].status == MEMORY_STATUS.REMOVE)
				{
					str += " -- remove";
				}
				str += " frame " + comparelst[i].frameCount;
				str += "\n";
			}
			Debug.LogWarning("memory info " + str);
		}
	}
}
