// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
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

		int currentLevel;


		void Start()
		{
			Screen.fullScreen = true;
		}


		public void Play()
		{
			uiAnimator.Play("ToLevelFromMenu");
			InitLevelButtons();
		}
		
		
		public void BackToLevel()
		{
			LevelManager.Instance.Stop();
			uiAnimator.Play("ToLevelFromGameplay");
			InitLevelButtons();
		}
		
		
		void InitLevelButtons()
		{
			levelButtons[0].Init(1, LevelStatus.Ready);
			for (int i = 1; i < levelButtons.Length; i++)
			{
				levelButtons[i].Init(i + 1, LevelStatus.Locked);
			}
		}
		
		
		public void PlayLevel(int level)
		{
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
			fluidRenderer.materials = new []{ fluidMaterials[1] };
			winPopUp.Init(time);
			fluidAnimator.Play("ShowFluid");
			uiAnimator.Play("ShowWinPopUp");
		}
		
		
		public void ShowLosePopUp()
		{
			fluidRenderer.materials = new []{ fluidMaterials[0] };
			fluidAnimator.Play("ShowFluid");
			uiAnimator.Play("ShowLosePopUp");
		}
	}
}