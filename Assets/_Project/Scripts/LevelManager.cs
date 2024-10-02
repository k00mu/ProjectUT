// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using System;
using UnityEngine;

namespace WaterUT
{
	public class LevelManager : MonoBehaviourSingleton<LevelManager>
	{
		[SerializeField] Transform[] levels;

		public event Action OnStop;
		
		
		public void StartLevel(int level)
		{
			level -= 1;
			
			PlaySpaceManager.Instance.Init(levels[level].GetChild(0), levels[level].GetChild(1), 180f);
			
			levels[level].gameObject.SetActive(true);
		}


		public void Stop()
		{
			foreach (var level in levels)
			{
				level.gameObject.SetActive(false);
			}
			OnStop?.Invoke();
		}
	}
}