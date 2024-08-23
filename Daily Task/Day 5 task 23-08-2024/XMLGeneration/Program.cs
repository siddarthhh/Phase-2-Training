using System.Xml;
using XMLGeneration;

internal class Program
{
    private static void Main(string[] args)
    {
        Course[] courses = new Course[3];
        courses[0] = new Course(11, "VW", 3);
        courses[1] = new Course(12, "AUDI", 1);
        courses[2] = new Course(13, "BMW", 2);
        using (XmlWriter writer = XmlWriter.Create("Carr.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Cars");
            foreach (Course course in courses)
            {
                writer.WriteStartElement("Car");
                writer.WriteElementString("CarID", course.Cid.ToString());
                writer.WriteElementString("CarName", course.Cname.ToString());
                writer.WriteElementString("WaitingPeriodInmonths", course.Cduration.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}