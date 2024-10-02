// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WaterUT
{
	public class PlaySpaceManager : MonoBehaviourSingleton<PlaySpaceManager>
	{
		[SerializeField] TextMeshProUGUI timerText;
		float timerDuration;
		float timer;
		bool isPlaying;
		
		List<Provider> providersL;
		List<Pipe> pipesL;
		
		Coroutine redistributeCor;


		void Update()
		{
			if (!isPlaying) 
				return;
			
			timer -= Time.deltaTime;
			timerText.text = TimeSpan.FromSeconds(timer).ToString(@"mm\:ss");

			if (!(timer <= 0f))
				return;
			
			Lose();
		}


		public void Lose()
		{
			isPlaying = false;
			redistributeCor = null;
			
			GameManager.Instance.ShowLosePopUp();
		}
		
		
		public void Win()
		{
			isPlaying = false;
			redistributeCor = null;
			
			GameManager.Instance.ShowWinPopUp(GetPlayTime());
		}


		public void Init(Transform providerContainer, Transform pipeContainer, float duration)
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
			
			timerDuration = duration;
			timer = duration;
			isPlaying = true;
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
		
		
		float GetPlayTime()
		{
			return timerDuration - timer;
		}
	}
}