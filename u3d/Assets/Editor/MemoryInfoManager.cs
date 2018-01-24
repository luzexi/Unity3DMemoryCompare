using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryInfoManager
{
	private static MemoryInfoManager mInstance;
	public static MemoryInfoManager instance
	{
		get
		{
			if(mInstance == null)
			{
				mInstance = new MemoryInfoManager();
			}
			return mInstance;
		}
	}

	private const int MaxListCount = 200;


	int ListSort(MemoryInfo a , MemoryInfo b)
    {
    	if(a.size > b.size)
    		return -1;
    	if(a.size < b.size)
    		return 1;
    	return a.name.CompareTo(b.name);
    }

	public List<MemoryInfo> GetTextureMemory()
	{
		UnityEngine.Object[] objs = Resources.FindObjectsOfTypeAll(typeof(Texture));
    	List<MemoryInfo> lst = new List<MemoryInfo>();
    	for(int i = 0 ; i<objs.Length && i < MaxListCount ; i++)
    	{
    		// Debug.LogError("objs " +objs[i].name);
    		MemoryInfo mi = new MemoryInfo();
    		Texture tex = objs[i] as Texture;
    		// mi.tex = objs[i] as Texture;
    		mi.size = tex.width * tex.height;
    		mi.name = objs[i].name;
    		if(mi.name.IndexOf("@")<0)
    			lst.Add(mi);
    	}
    	lst.Sort(ListSort);

    	return lst;
	}


}
