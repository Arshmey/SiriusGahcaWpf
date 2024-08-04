using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SiriusGahca
{
	public class Case
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
		[XmlAttribute("img")]
		public string IconPerson { get; set; }
		[XmlAttribute("tag")]
		public string Tag { get; set; }
	}
}
