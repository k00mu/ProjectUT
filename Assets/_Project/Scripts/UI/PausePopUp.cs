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
	public class PausePopUp : MonoBehaviour
	{
		[SerializeField] Button levelBtn;
		[SerializeField] Button resumeBtn;
		[SerializeField] Button restartBtn;


		void OnEnable()
		{
			levelBtn.onClick.AddListener(Level);
			resumeBtn.onClick.AddListener(Resume);
			restartBtn.onClick.AddListener(Restart);
		}
		
		
		void OnDisable()
		{
			levelBtn.onClick.RemoveListener(Level);
			resumeBtn.onClick.RemoveListener(Resume);
			restartBtn.onClick.RemoveListener(Restart);
		}
		
		
		void Level()
		{
			// stop/reset the game
			GameManager.Instance.Play();
		}
		
		
		void Resume()
		{
			GameManager.Instance.Resume();
		}
		
		
		void Restart()
		{
			// restart the game
		}
	}
}