// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WaterUT
{
	public class Gallon : Container
	{
		[SerializeField] Sprite[] sprites;
		
		SpriteRenderer sr;
		
		List<SourceType> sourcesL = new List<SourceType>(); 
		
		
		void Awake()
		{
			sr = GetComponentInChildren<SpriteRenderer>();
			Init();
		}


		void Init()
		{
			Type = ContainerType.Gallon;
			sr.sprite = sprites[0];
		}


		public void AddSource(SourceType type)
		{
			if (IsValidAddition(type))
			{
				sourcesL.Add(type);
				UpdateSprite();
				PlaySound();
				CheckWinCondition();
			}
			else
			{
				HandleGameOver();
			}
		}

		bool IsValidAddition(SourceType type)
		{
			return (sourcesL.Count == 0 && type == SourceType.Gravel) ||
			       (sourcesL.Count == 1 && type == SourceType.Sand) ||
			       (sourcesL.Count == 2 && type == SourceType.Water) ||
			       (sourcesL.Count > 0 && sourcesL.Last() == type);
		}

		void UpdateSprite()
		{
			if (sr != null && sprites != null && sourcesL.Count > 0 && sourcesL.Count <= sprites.Length - 1)
			{
				sr.sprite = sprites[sourcesL.Count];
			}
		}

		void PlaySound()
		{
			// Implement sound playing logic here
		}

		void CheckWinCondition()
		{
			if (sourcesL.Count == 3 && sourcesL[2] == SourceType.Water)
			{
				// Implement win logic here
			}
		}

		void HandleGameOver()
		{
			Debug.Log("GameOver");
			// Implement lose logic here
		}
	}
}