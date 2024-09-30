// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using UnityEngine;
using WaterUT.UI;

namespace WaterUT
{
	public class GameManager : MonoBehaviourSingleton<GameManager>
	{
		[SerializeField] Animator UIAnimator;
		[SerializeField] LevelButton[] levelButtons;
		[SerializeField] LevelDetailPopUp levelDetailPopUp;


		void Start()
		{
			Screen.fullScreen = true;
		}


		public void Play()
		{
			UIAnimator.Play("ToLevel");
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
			UIAnimator.Play("ToGameplay");
		}


		public void BackToMenu()
		{
			UIAnimator.Play("ToMenu");
		}


		public void Exit()
		{
			Komutils.Helpers.QuitGame();
		}
		
		
		public void ShowLevelDetail(int level, int stars)
		{
			levelDetailPopUp.Init(level, stars);
			UIAnimator.Play("ShowLevelDetailPopUp");
		}
		
		
		public void HideLevelDetail()
		{
			UIAnimator.Play("HideLevelDetailPopUp");
		}


		void ShowPausePopUp()
		{
			UIAnimator.Play("ShowPausePopUp");
		}
		
		
		void HidePausePopUp()
		{
			UIAnimator.Play("HidePausePopUp");
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
	}
}