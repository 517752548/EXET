namespace ETModel
{
	[Config((int)(AppType.ClientH))]
	public partial class EssentialShapePoolCategory : ACategory<EssentialShapePool>
	{
	}

	public class EssentialShapePool: IConfig
	{
		public long Id { get; set; }
		public string Translate;
	}
}
