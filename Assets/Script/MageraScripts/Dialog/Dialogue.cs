using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;     //запись и чтение xml файла
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue
{

    //[XmlElement("text")]
    public string name;

    [XmlElement("node")]
    public Node[] nodes;

    public static Dialogue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dial = serializer.Deserialize(reader) as Dialogue;
        Debug.Log("hello there");
        return dial;
    }

    public void Remove()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = 0; j < nodes[i].answers.Length; j++)
            {
                nodes[i].answers[j].text = "";
            }
            nodes[i].Npctext = "";
        }
    }
}

[System.Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string Npctext;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;

}

public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("dialend")]
    public string end;
    [XmlElement("quest")]
    public string quest;
    [XmlElement("questDone")]
    public string questDone;
    [XmlElement("after")]
    public string after;
    [XmlElement("motion")]
    public string motion;

}