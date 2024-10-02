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
		
		
		void OnEnable()
		{
			sr = GetComponentInChildren<SpriteRenderer>();
			Init();
			
			LevelManager.Instance.OnStop += sourcesL.Clear;
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
				CheckWinCondition();
			}
			else if (
				(sourcesL.Count == 1 && sourcesL.Last() == SourceType.Gravel) ||
				(sourcesL.Count == 2 && sourcesL.Last() == SourceType.Sand) ||
				(sourcesL.Count == 3 && sourcesL.Last() == SourceType.Water))
			{
				return;
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
			       (sourcesL.Count == 2 && type == SourceType.Water);
		}

		void UpdateSprite()
		{
			if (sr != null && sprites != null && sourcesL.Count > 0 && sourcesL.Count <= sprites.Length - 1)
			{
				sr.sprite = sprites[sourcesL.Count];
			}
		}

		
		void CheckWinCondition()
		{
			if (sourcesL.Count == 3 && sourcesL[2] == SourceType.Water)
			{
				PlaySpaceManager.Instance.Win();
			}
		}

		void HandleGameOver()
		{
			PlaySpaceManager.Instance.Lose();
		}
	}
}