// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace WaterUT
{
	public class EdgeDetector : MonoBehaviour
	{
		public Container ToCon { get => toCon; }
		public bool IsConnect { get => isConnect; }
		
		Container toCon;
		bool isFacingDown;
		bool isConnect;
		

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