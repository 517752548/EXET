using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH))]
	public partial class CellConfigCategory : ACategory<CellConfig>
	{
	}

	public class CellConfig: IConfig
	{
		public long Id { get; set; }
		public string Name;
		public int space_Y;
		public int space_X;
		public int sizeX;
		public int sizeY;
	}
}
