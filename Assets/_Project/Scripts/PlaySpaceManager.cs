// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterUT
{
	public class PlaySpaceManager : MonoBehaviourSingleton<PlaySpaceManager>
	{
		List<Provider> providersL;
		List<Pipe> pipesL;
		
		Coroutine redistributeCor;


		public void Init(Transform providerContainer, Transform pipeContainer)
		{
			providersL = new List<Provider>();
			for (int i = 0; i < providerContainer.childCount; i++)
			{
				providersL.Add(providerContainer.GetChild(i).GetComponent<Provider>());
			}
			
			pipesL = new List<Pipe>();
			for (int i = 0; i < pipeContainer.childCount; i++)
			{
				pipesL.Add(pipeContainer.GetChild(i).GetComponent<Pipe>());
			}
			
			Redistribute();
		}


		public void Redistribute()
		{
			if (redistributeCor != null)
				return;
			
			redistributeCor = StartCoroutine(RedistributeCor());
		}
		
		
		IEnumerator RedistributeCor()
		{
			foreach (var pipe in pipesL)
			{
				pipe.Empty();
			}
			
			yield return new WaitForSeconds(0.05f);
			
			foreach (var provider in providersL)
			{
				provider.Redistribute();
			}
			
			redistributeCor = null;
		}
	}
}