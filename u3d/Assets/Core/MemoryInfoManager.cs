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

	public List<MemoryInfoCompare> MemoryCompare(List<MemoryInfo> _pre , List<MemoryInfo> _cur)
	{
		List<MemoryInfoCompare> lst = new List<MemoryInfoCompare>();
		if(_pre == null || _cur == null)
		{
			return lst;
		}

		for(int i = 0 ; i<_pre.Count ; i++)
		{
			bool exist = false;
			for(int j = 0 ; j<_cur.Count ; j++)
			{
				if(_pre[i].name == _cur[j].name)
				{
					exist = true;
					break;
				}
			}
			if(!exist)
			{
				MemoryInfoCompare mic = new MemoryInfoCompare();
				mic.name = _pre[i].name;
				mic.status = MEMORY_STATUS.REMOVE;
				mic.frameCount = Time.frameCount;
				mic.size = _pre[i].size;
				lst.Add(mic);
			}
		}

		for(int i = 0 ; i<_cur.Count ; i++)
		{
			bool exist = false;
			for(int j = 0 ; j<_pre.Count ; j++)
			{
				if(_cur[i].name == _pre[j].name)
				{
					exist = true;
					break;
				}
			}
			if(!exist)
			{
				MemoryInfoCompare mic = new MemoryInfoCompare();
				mic.name = _cur[i].name;
				mic.size = _cur[i].size;
				mic.status = MEMORY_STATUS.NEW;
				mic.frameCount = Time.frameCount;
				lst.Add(mic);
			}
		}

		return lst;
	}

}
