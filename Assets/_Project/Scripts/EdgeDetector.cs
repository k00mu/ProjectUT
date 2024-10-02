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
		[SerializeField] ParticleSystem liquidPS;
		[SerializeField] Sprite[] sprites; 
		
		public Container ToCon { get => toCon; }
		public bool IsConnect { get => isConnect; }
		
		Container toCon;
		
		bool isConnect;


		void OnEnable()
		{
			liquidPS.gameObject.SetActive(false);
			
			LevelManager.Instance.OnStop += UnConnect;
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

			UnConnect();
		}


		void UnConnect()
		{
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


		void ChangeLiquidSprite(SourceType type)
		{
			if (type == SourceType.Gravel)
			{
				liquidPS.textureSheetAnimation.SetSprite(0, sprites[0]);
			}
			else if (type == SourceType.Sand)
			{
				liquidPS.textureSheetAnimation.SetSprite(0, sprites[1]);
			}
			else if (type == SourceType.Water)
			{
				liquidPS.textureSheetAnimation.SetSprite(0, sprites[2]);
			}
		}

		
		public void EnableLiquidPS(SourceType type)
		{
			ChangeLiquidSprite(type);
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