// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace WaterUT
{
	public class EdgeDetector : MonoBehaviour
	{
		[SerializeField] private ParticleSystem liquidPS;
		
		public Container ToCon { get => toCon; }
		public bool IsConnect { get => isConnect; }
		
		Container toCon;
		
		bool isConnect;


		void Awake()
		{
			liquidPS.gameObject.SetActive(false);
		}


		void Update()
		{
			Ray ray = new Ray(transform.position, transform.up);
			Debug.DrawRay(ray.origin, ray.direction * .2f, Color.blue);
		}


		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Connector") == false)
				return;

			toCon = other.gameObject.GetComponentInParent<Container>();
			isConnect = true;
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Connector") == false)
				return;

			isConnect = false;
			toCon = null;
		}
		

		void OnDrawGizmos()
		{
			if (isConnect)
			{
				Gizmos.DrawSphere(transform.position, 0.1f);
			}
		}


		// public void ChangeLiquidSprite(Sprite sprite)
		// {
		// 	liquidPS.textureSheetAnimation.SetSprite(0, sprite);
		// }

		
		public void EnableLiquidPS(SourceType type)
		{
			liquidPS.gameObject.SetActive(true);
		}

		
		public void DisableLiquidPS()
		{
			liquidPS.gameObject.SetActive(false);
		}


		public bool IsFacingDown()
		{
			return Mathf.Approximately(transform.rotation.eulerAngles.z, 180f);
		}
		
		
		public bool IsFacingSide()
		{
			return Mathf.Approximately(transform.rotation.eulerAngles.z, 90f) || Mathf.Approximately(transform.rotation.eulerAngles.z, 270f);
		}
	}
}