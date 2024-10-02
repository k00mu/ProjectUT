// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using UnityEngine.UI;

namespace WaterUT.UI
{
	public class PausePopUp : MonoBehaviour
	{
		[SerializeField] Button levelBtn;
		[SerializeField] Button resumeBtn;


		void OnEnable()
		{
			levelBtn.onClick.AddListener(Level);
			resumeBtn.onClick.AddListener(Resume);
		}
		
		
		void OnDisable()
		{
			levelBtn.onClick.RemoveListener(Level);
			resumeBtn.onClick.RemoveListener(Resume);
		}
		
		
		void Level()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.Resume();
			GameManager.Instance.BackToLevel();
		}
		
		
		void Resume()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.Resume();
		}
	}
}