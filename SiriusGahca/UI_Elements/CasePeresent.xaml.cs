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

namespace SiriusGahca
{
    /// <summary>
    /// Interaction logic for CasePeresent.xaml
    /// </summary>
    public partial class CasePeresent : UserControl
    {

		public static readonly DependencyProperty IconCaseImageProperty = DependencyProperty.Register
        (
            "IconCaseImage", 
            typeof(ImageSource),
            typeof(CasePeresent)
        );

        public static readonly DependencyProperty NameCaseProperty = DependencyProperty.Register
        (
            "NameCase",
            typeof(object),
            typeof(CasePeresent)
        );

		public CasePeresent()
        {
            InitializeComponent();
        }

		[Category("Common")]
		public ImageSource IconCaseImage
        {
            get { return iconCase.Source; }
            set { iconCase.Source = value; }
        }

		[Category("Common")]
		public object NameCase
        {
            get { return nameCase.Content; }
            set { nameCase.Content = value; }
        }
    }
}
