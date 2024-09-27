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
		[SerializeField] private SourceType provideSource;
		
		
		private void Start()
		{
			Init();
		}


		private void Init()
		{
			containerType = ContainerType.Provider;
			currentSource = provideSource;
		}
		
		
	}
}