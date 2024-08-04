using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SiriusGahca.UI_Elements
{
	/// <summary>
	/// Interaction logic for SideBar.xaml
	/// </summary>
	public partial class SideBar : UserControl
	{

		public static readonly DependencyProperty SizeContainerProperty = DependencyProperty.Register
		(
			"SizeContainer",
			typeof(double),
			typeof(SideBar)
		);

		public static readonly DependencyProperty ScrollValueProperty = DependencyProperty.Register
		(
			"ScrollValue",
			typeof(double),
			typeof(SideBar)
		);

		public static readonly DependencyProperty ScrollMaximumProperty = DependencyProperty.Register
		(
			"ScrollMaximum",
			typeof(double),
			typeof(SideBar)
		);

		public static readonly DependencyProperty ScrollMinimumProperty = DependencyProperty.Register
		(
			"ScrollMinimum",
			typeof(double),
			typeof(SideBar)
		);

		public static readonly DependencyProperty ScrollLargeChangeProperty = DependencyProperty.Register
		(
			"ScrollLargeChange",
			typeof(double),
			typeof(SideBar)
		);

		public static readonly DependencyProperty ScrollSmallChangeProperty = DependencyProperty.Register
		(
			"ScrollSmallChange",
			typeof(double),
			typeof(SideBar)
		);

		public SideBar()
		{
			InitializeComponent();
		}

		[Category("Options user control")]
		public double SizeContainer
		{
			get { return container.Height; }
			set { container.Height = value; }
		}

		[Category("Options user control")]
		public double ScrollValue
		{
			get { return scrollBar.Value; }
			set { scrollBar.Value = value; }
		}

		[Category("Options user control")]
		public double ScrollMaximum
		{
			get { return scrollBar.Maximum; }
			set { scrollBar.Maximum = value; }
		}

		[Category("Options user control")]
		public double ScrollMinimum
		{
			get { return scrollBar.Minimum; }
			set { scrollBar.Minimum = value; }
		}

		[Category("Options user control")]
		public double ScrollLargeChange
		{
			get { return scrollBar.LargeChange; }
			set { scrollBar.LargeChange = value; }
		}

		[Category("Options user control")]
		public double ScrollSmallChange
		{
			get { return scrollBar.SmallChange; }
			set { scrollBar.SmallChange = value; }
		}

		public void AddElement(UIElement element)
		{
			container.Children.Add(element);
		}

		private void ScrollWheel(object sender, MouseWheelEventArgs e)
		{
			scrollBar.Value -= e.Delta / 10;
		}

		private void ChangeValue(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			container.Margin = new Thickness(0, e.NewValue * -1, 16, 0);
		}
	}
}
