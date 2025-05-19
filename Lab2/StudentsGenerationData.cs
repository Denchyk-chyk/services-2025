using System.Xml.Serialization;

namespace Lab2;

[XmlRoot("studentGenerationData")]
public class StudentsGenerationData
{
	[XmlArray("firstNames")]
	[XmlArrayItem("firstName")]
	public List<string> FirstNames { get; set; }

	[XmlArray("lastNames")]
	[XmlArrayItem("lastName")]
	public List<string> LastNames { get; set; }

	[XmlElement("dateOfBirth")]
	public DatesRange DateOfBirth { get; set; }

	[XmlElement("heights")]
	public GenderHeights Heights { get; set; }

	[XmlElement("mark")]
	public IntegersRange Mark { get; set; }
}

public class IntegersRange
{
	[XmlAttribute("min")]
	public int Min { get; set; }

	[XmlAttribute("max")]
	public int Max { get; set; }
}

public class DatesRange
{
	[XmlAttribute("min")]
	public DateTime Min { get; set; }

	[XmlAttribute("max")]
	public DateTime Max { get; set; }
}

public class GenderHeights
{
	[XmlElement("male")]
	public IntegersRange Male { get; set; }

	[XmlElement("female")]
	public IntegersRange Female { get; set; }
}
