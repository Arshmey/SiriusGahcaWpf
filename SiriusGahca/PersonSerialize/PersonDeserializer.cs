using System.IO;
using System.Xml.Serialization;

namespace SiriusGahca.PersonSerialize
{
	internal class PersonDeserializer
	{
		public List<Person> Person { get; set; }
		private XmlSerializer deserialize = new XmlSerializer(typeof(List<Person>));

		public void Deserialize(string path)
		{
			using (FileStream reader = new FileStream(path, FileMode.OpenOrCreate))
			{
				Person = deserialize.Deserialize(reader) as List<Person>;
			}
		}
	}
}
