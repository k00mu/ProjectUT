// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using JetBrains.Annotations;
using Komutils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterUT.UI;

namespace WaterUT
{
	public class GameManager : MonoBehaviourSingleton<GameManager>
	{
		[SerializeField] Animator uiAnimator;
		[SerializeField] LevelButton[] levelButtons;
		[SerializeField] LevelDetailPopUp levelDetailPopUp;
		[SerializeField] WinPopUp winPopUp;
		[SerializeField] Animator fluidAnimator;
		[SerializeField] MeshRenderer fluidRenderer;
		[SerializeField] Material[] fluidMaterials; // 0 - dirty water, 1 - clean water

		public LevelDataContainer LevelData;
		public int currentLevel;


		void Start()
		{
			Screen.fullScreen = true;
			LoadData();
		}


		void LoadData()
		{
			if (PlayerPrefs.GetString("LevelData") == "")
			{
				LevelData = new LevelDataContainer();
				LevelData.LevelsL = new List<LevelData>();
				
				for (int i = 0; i < 3; i++)
				{
					LevelData.LevelsL.Add(new LevelData(LevelStatus.Locked, 0));
				}
				LevelData.LevelsL[0].status = LevelStatus.Ready;
			}
			else
			{
				LevelData = JsonUtility.FromJson<LevelDataContainer>(PlayerPrefs.GetString("LevelData"));
			}
		}
		
		
		public void SaveData()
		{
			PlayerPrefs.SetString("LevelData", JsonUtility.ToJson(LevelData));
		}


		public void Play()
		{
			uiAnimator.Play("ToLevelFromMenu");
			InitLevelButtons();
		}
		
		
		public void BackToLevel()
		{
			AudioManager.Instance.StopLiquidSFX();
			LevelManager.Instance.Stop();
			uiAnimator.Play("ToLevelFromGameplay");
			InitLevelButtons();
		}
		
		
		void InitLevelButtons()
		{
			levelButtons[0].Init(1, LevelData.LevelsL[0].status, LevelData.LevelsL[0].stars);
			for (int i = 1; i < levelButtons.Length; i++)
			{
				levelButtons[i].Init(i + 1, LevelData.LevelsL[i].status, LevelData.LevelsL[i].stars);
			}
		}
		
		
		public void PlayLevel(int level)
		{
			LevelManager.Instance.Stop();
			uiAnimator.Play("ToGameplay");
			currentLevel = level;
			StartCoroutine(PlayLevelCor(currentLevel));
		}


		IEnumerator PlayLevelCor(int level)
		{
			yield return new WaitForSeconds(0.25f);

			LevelManager.Instance.StartLevel(level);
		}
		
		
		public void PlayNextLevel()
		{
			fluidAnimator.Play("HideFluid");
			uiAnimator.Play("HideWinPopUp");
			LevelManager.Instance.Stop();
			PlayLevel(currentLevel + 1);
		}
		
		
		public void RestartLevel()
		{
			AudioManager.Instance.StopLiquidSFX();
			LevelManager.Instance.Stop();
			PlayLevel(currentLevel);
		}


		public void BackToMenu()
		{
			uiAnimator.Play("ToMenu");
		}


		public void Exit()
		{
			Helpers.QuitGame();
		}
		
		
		public void ShowLevelDetail(int level, int stars)
		{
			levelDetailPopUp.Init(level, stars);
			uiAnimator.Play("ShowLevelDetailPopUp");
		}
		
		
		public void HideLevelDetail()
		{
			uiAnimator.Play("HideLevelDetailPopUp");
		}


		void ShowPausePopUp()
		{
			uiAnimator.Play("ShowPausePopUp");
		}
		
		
		void HidePausePopUp()
		{
			uiAnimator.Play("HidePausePopUp");
		}


		public void Pause()
		{
			ShowPausePopUp();
			Time.timeScale = 0;
		}
		
		
		public void Resume()
		{
			HidePausePopUp();
			Time.timeScale = 1;
		}


		public void ShowHintPopUp()
		{
			uiAnimator.Play("ShowHintPopUp");
			Time.timeScale = 0;
		}
		
		
		public void HideHintPopUp()
		{
			uiAnimator.Play("HideHintPopUp");
			Time.timeScale = 1;
		}
		
		
		public void ShowWinPopUp(float time)
		{
			AudioManager.Instance.PlayWinSFX();
			fluidRenderer.materials = new []{ fluidMaterials[1] };
			winPopUp.Init(time);
			fluidAnimator.Play("ShowFluid");
			uiAnimator.Play("ShowWinPopUp");
		}
		
		
		public void ShowLosePopUp()
		{
			AudioManager.Instance.PlayLoseSFX();
			fluidRenderer.materials = new []{ fluidMaterials[0] };
			fluidAnimator.Play("ShowFluid");
			uiAnimator.Play("ShowLosePopUp");
		}
		
		
		public void HideFluid()
		{
			fluidAnimator.Play("HideFluid");
		}
	}
	
	
	[Serializable]
	public class LevelData
	{
		public LevelStatus status;
		public int stars;
		
		
		public LevelData(LevelStatus status, int stars)
		{
			this.status = status;
			this.stars = stars;
		}
	}
	
	
	[Serializable]
	public class LevelDataContainer
	{
		public List<LevelData> LevelsL;
	}
}