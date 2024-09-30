// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils;
using UnityEngine;

namespace WaterUT
{
	public class GameManager : MonoBehaviourSingleton<GameManager>
	{
		[SerializeField] Animator UIAnimator;


		public void Play()
		{
			UIAnimator.Play("ToLevel");
		}


		public void BackToMenu()
		{
			UIAnimator.Play("ToMenu");
		}


		public void Exit()
		{
			Komutils.Helpers.QuitGame();
		}
	}
}