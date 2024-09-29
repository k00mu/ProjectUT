// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace WaterUT
{
	public class Gallon : Container
	{
		void Awake()
		{
			Init();
		}


		void Init()
		{
			Type = ContainerType.Gallon;
		}
	}
}