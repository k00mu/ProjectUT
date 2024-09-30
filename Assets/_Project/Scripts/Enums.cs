// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================
namespace WaterUT
{
	public enum ContainerType
	{
		Provider,
		Pipe,
		Gallon
	}
	
	public enum SourceType
	{
		None,
		Water,
		Gravel,
		Sand
	}
	
	public enum PipeDirection
	{
		Up = 0,
		Right = -90,
		Down = -180,
		Left = -270
	}

	public enum PipeType
	{
		I,
		L,
		Plus,
		T
	}


	public enum LevelStatus
	{
		Locked,
		Ready,
		Done,
		ComingSoon
	}
}