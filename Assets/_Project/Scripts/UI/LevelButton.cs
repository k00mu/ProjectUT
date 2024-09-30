// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using UnityEngine.UI;

namespace WaterUT.UI
{
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] GameObject locked;
		[SerializeField] GameObject ready;
		[SerializeField] GameObject done;
		[SerializeField] Image doneImg;
		[SerializeField] Image text;
		
		[Header("Sprites")]
		[SerializeField] Sprite[] lockedNumbers;
		[SerializeField] Sprite[] readyNumbers;
		[SerializeField] Sprite[] doneNumbers;
		[SerializeField] Sprite[] doneStars;


		public void Init(int level, LevelStatus status, int stars = 0)
		{
			switch (status)
			{
				case LevelStatus.Locked:
					SetLocked(level);
					break;

				case LevelStatus.Ready:
					SetReady(level);
					break;

				case LevelStatus.Done:
					SetDone(level, stars);
					break;

				default:
					throw new System.ArgumentException();
			}
		}


		void SetDone(int level, int stars)
		{
			locked.SetActive(false);
			ready.SetActive(false);
			done.SetActive(true);
			
			doneImg.sprite = doneStars[stars - 1];
			text.sprite = doneNumbers[level - 1];
		}
		
		
		void SetReady(int level)
		{
			locked.SetActive(false);
			ready.SetActive(true);
			done.SetActive(false);
			
			text.sprite = readyNumbers[level - 1];
		}


		void SetLocked(int level)
		{
			locked.SetActive(true);
			ready.SetActive(false);
			done.SetActive(false);

			text.sprite = lockedNumbers[level - 1];
		}
	}
}