// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using UnityEngine.UI;

namespace WaterUT.UI
{
	public class PauseSlider : MonoBehaviour
	{
		[SerializeField] Sprite[] toggleSprite; // 0 = off, 1 = on
		[SerializeField] Image toggleImg;
		
		[SerializeField] Button toggleBtn;
		[SerializeField] Button hintBtn;
		[SerializeField] Button pauseBtn;

		Animator animator;
		bool isOn;


		void Awake()
		{
			animator = GetComponent<Animator>();
		}
		
		
		void Start()
		{
			toggleBtn.onClick.AddListener(Toggle);
			hintBtn.onClick.AddListener(Hint);
			pauseBtn.onClick.AddListener(Pause);
		}
		
		
		void Toggle()
		{
			AudioManager.Instance.PlayClickSFX();
			isOn = !isOn;
			toggleImg.sprite = toggleSprite[isOn ? 0 : 1];
			animator.Play(isOn ? "On" : "Off");
		}
		
		
		void Hint()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.ShowHintPopUp();
		}


		void Pause()
		{
			AudioManager.Instance.PlayClickSFX();
			GameManager.Instance.Pause();
		}
	}
}