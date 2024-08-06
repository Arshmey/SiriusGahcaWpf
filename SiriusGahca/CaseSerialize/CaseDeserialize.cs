using System.IO;
using System.Xml.Serialization;

namespace SiriusGahca.CaseSerialize
{
	internal class CaseDeserialize
	{

		public List<Case> Case { get; set; }
		private XmlSerializer deserialize = new XmlSerializer(typeof(List<Case>));

		public void Deserialize(string path)
		{
			using (FileStream reader = new FileStream(path, FileMode.OpenOrCreate))
			{
				Case = deserialize.Deserialize(reader) as List<Case>;
			}
		}
	}
}
