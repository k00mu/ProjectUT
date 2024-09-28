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
		
		
		private void Start()
		{
			Init();
		}


		private void Init()
		{
			CurrentSource = provideSource;
		}
	}
}