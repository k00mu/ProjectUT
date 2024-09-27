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
		public Container frCon;
		public Container toCon;
		public bool isFacingDown;
		public bool isConnect;


		private void Awake()
		{
			frCon = GetComponentInParent<Container>();
		}


		private void Update()
		{
			if (!gameObject.activeSelf) return;
			// Ray ray = new Ray(transform.position, transform.up);
			// Debug.DrawRay(ray.origin, ray.direction * .2f, Color.blue);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Connector") == false)
				return;

			toCon = other.gameObject.GetComponentInParent<Container>();
			isConnect = true;
		}


		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Connector") == false)
				return;

			isConnect = false;
			toCon = null;
		}
		

		private void OnDrawGizmos()
		{
			if (isConnect)
			{
				Gizmos.DrawSphere(transform.position, 0.1f);
			}
		}
	}
}