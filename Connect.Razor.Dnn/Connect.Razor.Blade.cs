using Connect.Razor.Dnn;
using Connect.Razor.Interfaces;

// ReSharper disable once CheckNamespace
namespace Connect.Razor.Blade
{
	public static class Current
	{
		public static  IPage Page => new DnnPage();
	}
}