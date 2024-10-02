﻿// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WaterUT.UI
{
	public class LevelDetailPopUp : MonoBehaviour
	{
		[SerializeField] Sprite[] stars;
		[SerializeField] Image starsImg;
		[SerializeField] TextMeshProUGUI levelText;
		[SerializeField] Button playBtn;
		[SerializeField] Button closeBtn;
		
		public void Init(int level, int stars = 0)
		{
			levelText.text = $"Level {level}";
			starsImg.sprite = this.stars[stars];
			
			playBtn.onClick.AddListener(() => {
				AudioManager.Instance.PlayClickSFX();
				GameManager.Instance.PlayLevel(level);
				playBtn.onClick.RemoveAllListeners();
				closeBtn.onClick.RemoveAllListeners();
			});
			closeBtn.onClick.AddListener(() => {
				AudioManager.Instance.PlayClickSFX();
				GameManager.Instance.HideLevelDetail();
				playBtn.onClick.RemoveAllListeners();
				closeBtn.onClick.RemoveAllListeners();
			});
		}
	}
}