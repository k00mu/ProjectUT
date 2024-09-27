// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Komutils.Extensions;
using System;

namespace WaterUT
{
	public class Pipe : Container
	{
		public PipeType pipeType = PipeType.Plus;
		public PipeDirection initialDirection = PipeDirection.Up;

		public PipeDirection currentDirection;

		
		private void Start()
		{
			Init();
			Rotate(initialDirection);
		}

		
		private void Init()
		{
			containerType = ContainerType.Pipe;
			
			switch (pipeType)
			{
				case PipeType.I:
					edgeDetectorsL[1].gameObject.SetActive(false);
					edgeDetectorsL[3].gameObject.SetActive(false);
					break;
				case PipeType.L:
					edgeDetectorsL[2].gameObject.SetActive(false);
					edgeDetectorsL[3].gameObject.SetActive(false);
					break;
				case PipeType.T:
					edgeDetectorsL[2].gameObject.SetActive(false);
					break;
				case PipeType.Plus:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
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
			hasFill = false;
			currentSource = SourceType.None;
		}


		private void OnMouseDown()
		{
			RotateNext();
			
			// Check Redistribute
			GameManager.Instance.Redistribute();
		}
	}
}