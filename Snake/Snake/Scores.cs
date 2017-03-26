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
    public class ScoreEntry {
        public int score { get; set; }
        public String pseudo { get; set; }

        public ScoreEntry() { }

        public ScoreEntry(String p, int s) {
            score = s;
            pseudo = p;
        }
    }

    public class ScoreList {
        
        public List<ScoreEntry> scores { get; private set; }
        private XmlSerializer serial;

        public ScoreList() {
            scores = new List<ScoreEntry>();
            serial = new XmlSerializer(scores.GetType());
            if(File.Exists("Scores.xml")) load();
        }

        public void addScore(String pseudo, int s) {
            scores.Add(new ScoreEntry(pseudo, s));
            save();
        }

        public void save()
        {
            using (StreamWriter writer = new StreamWriter(File.OpenWrite("Scores.xml")))
            {
                serial.Serialize(writer, scores);
            }
        }

        public void load()
        {
            object obj;
            using (StreamReader reader = new StreamReader(File.OpenRead("Scores.xml")))
            {
                obj = serial.Deserialize(reader.BaseStream);
            }
            scores = (List<ScoreEntry>)obj;
        }

    }
}
