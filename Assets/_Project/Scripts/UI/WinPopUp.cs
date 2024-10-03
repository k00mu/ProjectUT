// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.UI;

namespace WaterUT.UI
{
	public class WinPopUp : MonoBehaviour
	{
		[SerializeField] Sprite[] numbers;
		[SerializeField] Button levelBtn;
		[SerializeField] Button restartBtn;
		[SerializeField] Button nextLevelBtn;
		[SerializeField] Sprite[] stars;
		[SerializeField] Image starsImg;
		[SerializeField] Image[] timeImg;
		
		public void Init(float time)
		{
			var timeSpan = TimeSpan.FromSeconds(time);
			var timeStr = timeSpan.ToString(@"mm\:ss");
			
			timeImg[0].sprite = numbers[timeStr[0] - '0'];
			timeImg[1].sprite = numbers[timeStr[1] - '0'];
			timeImg[2].sprite = numbers[timeStr[3] - '0'];
			timeImg[3].sprite = numbers[timeStr[4] - '0'];
			
			levelBtn.onClick.AddListener(Level);
			restartBtn.onClick.AddListener(Restart);
			nextLevelBtn.onClick.AddListener(NextLevel);
			
			int starsCount = 3;
			if (time > 60)
				starsCount = 2;
			if (time > 120)
				starsCount = 1;
			starsImg.sprite = stars[starsCount - 1];
				
			if (GameManager.Instance.LevelData.LevelsL[GameManager.Instance.currentLevel - 1].stars < starsCount)
			{
				GameManager.Instance.LevelData.LevelsL[GameManager.Instance.currentLevel - 1].stars = 3;
				GameManager.Instance.LevelData.LevelsL[GameManager.Instance.currentLevel - 1].status = LevelStatus.Done;
			}
			if (GameManager.Instance.currentLevel < 3 && GameManager.Instance.LevelData.LevelsL[GameManager.Instance.currentLevel].status == LevelStatus.Locked)
				GameManager.Instance.LevelData.LevelsL[GameManager.Instance.currentLevel].status = LevelStatus.Ready;
			GameManager.Instance.SaveData();
		}
		
		
		void Level()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.HideFluid();
			GameManager.Instance.BackToLevel();
		}
		
		void Restart()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.RestartLevel();
		}

		void NextLevel()
		{
			if (GameManager.Instance.currentLevel - 1 < 3)
			{
				AudioManager.Instance.PlayClickSFX();
				GameManager.Instance.PlayNextLevel();
			}
			else
			{
				Level();
			}
		}
	}
}