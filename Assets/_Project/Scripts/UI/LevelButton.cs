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

		Button btn;


		void OnEnable()
		{
			btn = GetComponent<Button>();
		}
		

		public void Init(int level, LevelStatus status, int stars = 0)
		{
			btn.onClick.RemoveAllListeners();
			switch (status)
			{
				case LevelStatus.Locked:
					SetLocked(level);
					break;

				case LevelStatus.Ready:
					SetReady(level);
					AddLevelDetailListener(level, stars);
					break;

				case LevelStatus.Done:
					SetDone(level, stars);
					AddLevelDetailListener(level, stars);
					break;

				default:
					throw new System.ArgumentException();
			}
		}
		
		
		void AddLevelDetailListener(int level, int stars)
		{
			btn.onClick.AddListener(() => {
				AudioManager.Instance.PlayClickSFX();
				GameManager.Instance.ShowLevelDetail(level, stars);
			});
		}


		void SetDone(int level, int stars)
		{
			locked.SetActive(false);
			ready.SetActive(false);
			done.SetActive(true);
			
			doneImg.sprite = doneStars[stars - 2];
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