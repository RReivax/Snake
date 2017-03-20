using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace Snake
{
    class ScoreEntry
    {
        public int score { get; set; }
        public String pseudo { get; set; }
    }
    class ScoreList
    {
        public List<ScoreEntry> scores = new List<ScoreEntry>();

        private void addScore()
        {
            Console.WriteLine("Enter a name :");
            String name = Console.ReadLine();
            var score = new ScoreEntry() { score = 100, pseudo = name };
            scores.Add(score);
        }

        private void Save()
        {
            var serializer = new XmlSerializer(scores.GetType(), "ScoreList.ScoreEntry");
            using (var writer = new StreamWriter("Scores.xml", false))
            {
                serializer.Serialize(writer.BaseStream, scores);
            }

        }

        private void Load()
        {
            var serializer = new XmlSerializer(scores.GetType(), "ScoreList.ScoreEntry");
            object obj;
            using (var reader = new StreamReader("Scores.xml", false))
            {
                obj = serializer.Deserialize(reader.BaseStream);
            }
            scores = (List<ScoreEntry>)obj;
        }

    }
}
