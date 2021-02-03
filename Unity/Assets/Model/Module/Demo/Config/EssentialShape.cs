namespace ETModel
{
	[Config((int)(AppType.ClientH))]
	public partial class EssentialShapeCategory : ACategory<EssentialShape>
	{
	}

	public class EssentialShape: IConfig
	{
		public long Id { get; set; }
		public string Shape;
		public int Translate;
	}
}
