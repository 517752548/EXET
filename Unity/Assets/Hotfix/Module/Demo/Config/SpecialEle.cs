using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH))]
	public partial class SpecialEleCategory : ACategory<SpecialEle>
	{
	}

	public class SpecialEle: IConfig
	{
		public long Id { get; set; }
		public int Layer;
		public int needCube;
		public int canDispel;
		public float dispelAnimTime;
		public int dispelType;
		public int dispeldown;
	}
}
