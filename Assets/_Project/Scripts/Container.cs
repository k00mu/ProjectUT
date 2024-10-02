// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace WaterUT
{
	public class Container : MonoBehaviour
	{
		protected ContainerType Type;
		protected SourceType CurrentSource;
		public bool HasFill { set => hasFill = value; }
		
		[SerializeField] List<EdgeDetector> edgeDetectorsL = new List<EdgeDetector>();
		bool hasFill;


		void OnEnable()
		{
			LevelManager.Instance.OnStop += Empty;
		}


		public void Redistribute()
		{
			var unconnectedEdges = GetUnconnectedEdges();
			RedistributeToConnectedContainers();

			if (unconnectedEdges is { HasSideFacing: false, HasDownFacing: false })
				return;

			// EnableLiquidPSForUnconnectedEdges(unconnectedEdges);
		}

		(bool HasSideFacing, bool HasDownFacing) GetUnconnectedEdges()
		{
			bool hasSideFacing = false;
			bool hasDownFacing = false;

			foreach (var ed in edgeDetectorsL.Where(ed => !ed.IsConnect))
			{
				hasSideFacing |= ed.IsFacingSide();
				hasDownFacing |= ed.IsFacingDown();
			}

			return (hasSideFacing, hasDownFacing);
		}

		void RedistributeToConnectedContainers()
		{
			foreach (var ed in edgeDetectorsL.Where(ed => ed.IsConnect && ed.ToCon && !ed.ToCon.hasFill))
			{
				if (ed.ToCon.Type == ContainerType.Gallon)
				{
					ed.EnableLiquidPS(CurrentSource);
					(ed.ToCon as Gallon)?.AddSource(CurrentSource);
					continue;
				}
				
				ed.ToCon.hasFill = true;
				ed.ToCon.CurrentSource = CurrentSource;
				ed.ToCon.Redistribute();
				
				
			}
		}

		void EnableLiquidPSForUnconnectedEdges((bool HasSideFacing, bool HasDownFacing) unconnectedEdges)
		{
			foreach (var ed in edgeDetectorsL.Where(ed => !ed.IsConnect))
			{
				if ((unconnectedEdges.HasDownFacing && ed.IsFacingDown()) ||
				    (unconnectedEdges is { HasSideFacing: true, HasDownFacing: false } && ed.IsFacingSide()))
				{
					// ed.EnableLiquidPS(CurrentSource);
				}
			}
		}
		
		
		public void Empty()
		{
			HasFill = false;
			CurrentSource = SourceType.None;
			
			DisableLiquidPS();
		}

		
		void DisableLiquidPS()
		{
			foreach (var ed in edgeDetectorsL)
			{
				ed.DisableLiquidPS();
			}
		}
	}
}