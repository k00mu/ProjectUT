// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace WaterUT
{
public class Container : MonoBehaviour
	{
		public ContainerType containerType;
		public SourceType currentSource;
		
		public List<EdgeDetector> edgeDetectorsL = new List<EdgeDetector>();
		public bool hasFill;
		
		
		public void Redistribute()
		{
			foreach (var ed in edgeDetectorsL)
			{
				if (!ed.isConnect || !ed.toCon || ed.toCon.hasFill)
					continue;
				
				ed.toCon.hasFill = true;
				ed.toCon.currentSource = currentSource;
				ed.toCon.Redistribute();
			}
		}
	}
}