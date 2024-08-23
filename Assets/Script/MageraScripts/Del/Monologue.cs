using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot ("Monologue")]
public class Monologue
{
    [XmlElement("node")]
    public MainRootNode[] nodes;

    public static Monologue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Monologue));
        StringReader reader = new StringReader( _xml.text);
        Monologue mono = serializer.Deserialize(reader) as Monologue;
        return mono;
    }

    [System.Serializable]
    public class MainRootNode
    {
        [XmlElement("npctext")]
        public string Npctext;
    }
}
