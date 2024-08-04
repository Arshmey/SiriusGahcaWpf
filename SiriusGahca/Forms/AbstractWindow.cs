using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace SiriusGahca.Forms
{
	abstract class AbstractWindow
	{

		public abstract void Create();

		private protected void SizeSet(FrameworkElement element, double width, double height)
		{
			element.Width = width;
			element.Height = height;
		}

		private protected void AlignmentSet(FrameworkElement element)
		{
			element.VerticalAlignment = VerticalAlignment.Top;
			element.HorizontalAlignment = HorizontalAlignment.Left;
		}

		private protected void MarginSet(FrameworkElement element, double left, double top) 
		{
			element.Margin = new Thickness(left, top, 0, 0);
		}
	}
}
