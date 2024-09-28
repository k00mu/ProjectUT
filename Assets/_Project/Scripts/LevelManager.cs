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
	public class LevelManager : MonoBehaviourSingleton<LevelManager>
	{
		[SerializeField] private Transform providerContainer;
		[SerializeField] private Transform pipeContainer;
		private List<Provider> providersL;
		private List<Pipe> pipesL;
		
		private Coroutine redistributeCor;


		protected override void Awake()
		{
			base.Awake();
			
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
		}


		private void Start()
		{
			Redistribute();
		}


		public void Redistribute()
		{
			if (redistributeCor != null)
				return;
			
			redistributeCor = StartCoroutine(RedistributeCor());
		}
		
		
		private IEnumerator RedistributeCor()
		{
			foreach (var pipe in pipesL)
			{
				pipe.Empty();
			}
			
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			
			foreach (var provider in providersL)
			{
				provider.Redistribute();
			}
			
			redistributeCor = null;
		}
	}
}