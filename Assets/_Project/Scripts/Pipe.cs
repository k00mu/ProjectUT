// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using System;
using UnityEngine;

namespace WaterUT
{
	public class Pipe : Container
	{
		[SerializeField] PipeType pipeType = PipeType.Plus;
		[SerializeField] PipeDirection initialDirection = PipeDirection.Up;

		PipeDirection currentDirection;

		
		private void Start()
		{
			Init();
		}

		
		private void Init()
		{
			Rotate(initialDirection);
		}


		private void Rotate(PipeDirection direction)
		{
			if (pipeType == PipeType.Plus) return;
			
			currentDirection = direction;
			transform.localEulerAngles = transform.localEulerAngles.With(z: (float)direction);
		}


		public void RotateNext()
		{
			Rotate((PipeDirection)(((int)currentDirection - 90) % 360));
		}


		public void Empty()
		{
			HasFill = false;
			CurrentSource = SourceType.None;
		}


		private void OnMouseDown()
		{
			RotateNext();
			
			LevelManager.Instance.Redistribute();
		}
	}
}