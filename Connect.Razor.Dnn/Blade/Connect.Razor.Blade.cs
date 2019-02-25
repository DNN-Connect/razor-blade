using Connect.Razor.Dnn;
using Connect.Razor.Interfaces;

namespace Connect.Razor.Blade
{
	public static class Current
	{
		public static  IPage Page => new DnnPage();
	}
}