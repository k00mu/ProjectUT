// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using UnityEngine;

namespace WaterUT
{
	public class LevelManager : MonoBehaviourSingleton<LevelManager>
	{
		[SerializeField] Transform[] levels;
		
		
		public void StartLevel(int level)
		{
			level -= 1;
			
			PlaySpaceManager.Instance.Init(levels[level].GetChild(0), levels[level].GetChild(1));
			
			levels[level].gameObject.SetActive(true);
		}
	}
}