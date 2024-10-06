// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WaterUT
{
	public class Pipe : Container
	{
		[SerializeField] PipeType pipeType = PipeType.Plus;
		[SerializeField] PipeDirection initialDirection = PipeDirection.Up;

		PipeDirection currentDirection;

		
		void OnEnable()
		{
			Init();
		}

		
		void Init()
		{
			Type = ContainerType.Pipe;
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


		public void Input()
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				AudioManager.Instance.PlayClickSFX();
				
				RotateNext();
			
				PlaySpaceManager.Instance.Redistribute();
			}
		}
	}
}