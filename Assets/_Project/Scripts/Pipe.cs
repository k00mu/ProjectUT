// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using UnityEngine;

namespace WaterUT
{
	public class Pipe : Container
	{
		[SerializeField] PipeType pipeType = PipeType.Plus;
		[SerializeField] PipeDirection initialDirection = PipeDirection.Up;

		PipeDirection currentDirection;

		
		void Awake()
		{
			Init();
		}

		
		void Init()
		{
			Type = ContainerType.Provider;
			Rotate(initialDirection);
		}


		void Rotate(PipeDirection direction)
		{
			if (pipeType == PipeType.Plus) return;
			
			currentDirection = direction;
			transform.localEulerAngles = transform.localEulerAngles.With(z: (float)direction);
		}


		void RotateNext()
		{
			Rotate((PipeDirection)(((int)currentDirection - 90) % 360));
		}


		void OnMouseDown()
		{
			RotateNext();
			
			LevelManager.Instance.Redistribute();
		}
	}
}