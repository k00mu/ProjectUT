// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using System.Collections.Generic;

namespace WaterUT
{
	public class Container : MonoBehaviour
	{
		protected SourceType CurrentSource;
		public bool HasFill { get => hasFill; set => hasFill = value; }
		
		[SerializeField] List<EdgeDetector> edgeDetectorsL = new List<EdgeDetector>();
		bool hasFill;
		
		
		public void Redistribute()
		{
			foreach (var ed in edgeDetectorsL)
			{
				if (!ed.IsConnect || !ed.ToCon || ed.ToCon.hasFill)
					continue;
				
				ed.ToCon.hasFill = true;
				ed.ToCon.CurrentSource = CurrentSource;
				ed.ToCon.Redistribute();
			}
		}
	}
}