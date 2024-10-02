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
			
			// handle stars
		}
		
		
		void Level()
		{
			GameManager.Instance.BackToLevel();
		}
		
		void Restart()
		{
			GameManager.Instance.RestartLevel();
		}

		void NextLevel()
		{
			GameManager.Instance.PlayNextLevel();
		}
	}
}