using System.IO;
using UnityEngine;

namespace AddressablesTool
{
    public class CSVLoader
    {
        public string[,] csvData;
        public TextAsset textAsset;
        private string path;
        
        public CSVLoader(string path)
        {
            this.path = path;
        }
        
        public void Load()
        {
            if (!File.Exists(path))
            {
                Debug.Log("ファイルが存在しません: " + path);
                return;
            }

            string text = File.ReadAllText(path);
            textAsset = new TextAsset(text);
            
            string[] lines = textAsset.text.Trim().Split('\n');
            int height = lines.Length;
            int width = 7;

            csvData = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] row = lines[i].Trim().Split(',');

                for (int j = 0; j < width; j++)
                {
                    csvData[i, j] = row[j];
                }
            }

            Debug.Log($"CSV読み込み完了: {height}行 {width}列");
        }
    }
}