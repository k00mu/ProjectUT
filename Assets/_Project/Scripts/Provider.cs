// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
namespace WaterUT

{
	public class Provider : Container
	{
		[SerializeField] SourceType provideSource;
		
		
		void OnEnable()
		{
			Init();
		}


		void Init()
		{
			Type = ContainerType.Provider;
			CurrentSource = provideSource;
		}
	}
}