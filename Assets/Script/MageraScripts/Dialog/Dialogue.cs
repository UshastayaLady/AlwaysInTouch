using UnityEngine;
using System.Xml.Serialization;     //������ � ������ xml �����
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

    [XmlArray("quests")]
    [XmlArrayItem("quest")]
    public Quests[] quests;

    [XmlElement("after")]
    public string after; 

}

public class Quests
{
    [XmlElement("textQuest")] // ����� ��� �������� ������
    public string textQuest;    
    [XmlElement("questDone")] // ����� ������ ��� ��������, ��� �� �������� (����� ������ "��������")
    public string questDone;
    [XmlElement("questEndAndDelete")] // ����� ������, ������� ������� �� ����� �������
    public string questEndAndDelete;
    [XmlElement("questChangeStatus")] // ����� ������, ��� �������� �������� ������
    public string questChangeStatus;
    [XmlElement("textNewStatus")] // ��� ����� �������
    public string textNewStatus;
    [XmlElement("motion")] // ����
    public string motion;
}