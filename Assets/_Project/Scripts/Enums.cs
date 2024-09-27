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
		Pipe
	}
	
	public enum SourceType
	{
		None,
		Water
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
}