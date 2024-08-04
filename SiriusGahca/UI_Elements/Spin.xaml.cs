using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
	/// Interaction logic for Spin.xaml
	/// </summary>
	public partial class Spin : UserControl
	{

		public readonly object objectLock = new object();
		public static readonly DependencyProperty ImagePersonProperty = DependencyProperty.Register
		(
			"ImagePerson",
			typeof(ImageSource),
			typeof(Spin)
		);
		public static readonly DependencyProperty NamePersonProperty = DependencyProperty.Register
		(
			"NamePerson",
			typeof(object),
			typeof(Spin)
		);

		public Spin()
		{
			InitializeComponent();
		}

		[Category("Common")]
		public ImageSource ImagePerson
		{
			get { return imagePerson.Source; }
			set { imagePerson.Source = value; }
		}

		[Category("Common")]
		public object NamePerson
		{
			get { return namePerson.Content; }
			set { namePerson.Content = value; }
		}

		public event RoutedEventHandler ButtonClick
		{
			add { lock (objectLock) { spinButton.Click += value; } }
			remove { lock (objectLock) { spinButton.Click -= value; } }
		}
	}
}
