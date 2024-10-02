// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================
using Komutils;
using UnityEngine;
namespace WaterUT
{
	public class AudioManager : MonoBehaviourSingleton<AudioManager>
	{
		[SerializeField] AudioSource bgmSource;
		[SerializeField] AudioSource sfxOnceSource;
		[SerializeField] AudioSource sfxSource;
		
		[SerializeField] AudioClip clickClip;
		[SerializeField] AudioClip winClip;
		[SerializeField] AudioClip loseClip;
		[SerializeField] AudioClip gravelClip;
		[SerializeField] AudioClip sandClip;
		[SerializeField] AudioClip waterClip;
		
		
		
		public void MuteBGM()
		{
			bgmSource.mute = true;
		}
		
		
		public void UnMuteBGM()
		{
			bgmSource.mute = false;
		}
		
		
		public void MuteSFX()
		{
			sfxOnceSource.mute = true;
			sfxSource.mute = true;
		}
		
		
		public void UnMuteSFX()
		{
			sfxOnceSource.mute = false;
			sfxSource.mute = false;
		}
		
		
		public void PlayClickSFX()
		{
			sfxOnceSource.PlayOneShot(clickClip);
		}
		
		
		public void PlayWinSFX()
		{
			sfxOnceSource.PlayOneShot(winClip);
		}
		
		
		public void PlayLoseSFX()
		{
			sfxOnceSource.PlayOneShot(loseClip);
		}
		
		
		public void PlayGravelSFX()
		{
			sfxSource.loop = true;
			sfxSource.clip = gravelClip;
			sfxSource.Play();
		}
		
		
		public void PlaySandSFX()
		{
			sfxSource.loop = true;
			sfxSource.clip = sandClip;
			sfxSource.Play();
		}
		
		
		public void PlayWaterSFX()
		{
			sfxSource.loop = true;
			sfxSource.clip = waterClip;
			sfxSource.Play();
		}
		
		
		public void StopLiquidSFX()
		{
			sfxSource.loop = false;
			sfxSource.Stop();
		}
	}
}