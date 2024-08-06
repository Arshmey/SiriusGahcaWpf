using System.Xml.Serialization;

namespace SiriusGahca.PersonSerialize
{
	public class Person
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
		[XmlAttribute("img")]
		public string IconPerson { get; set; }
		[XmlAttribute("rate")]
		public int Rate { get; set; }
		[XmlAttribute("changeMin")]
		public int Min { get; set; }
		[XmlAttribute("changeMax")]
		public int Max { get; set; }
	}
}
