using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Models
{
    public class ReadFile : IReadFile
    {

        private List<Reciepe> ReciepeEntries;

        public ReadFile()
        {
            ReciepeEntries = new List<Reciepe>();

        }

        public List<Reciepe> LoadEntries(string path)
        {        
           var files = GetContentFiles(path);

            if(files == null)
            {
                return null;
            }

            foreach(var file in files)
            {
                var entry = ReadContent(file);
                ReciepeEntries.Add(entry);
            }

            return ReciepeEntries;
        }

        private string[] GetContentFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
            }catch (Exception e)
            {
                Console.WriteLine($"Exception caught: {e.Message}");
                return null;
            }
        }

        private Reciepe ReadContent(string file)
        {
            var lines = File.ReadAllLines(file);
            Reciepe reciepe = new Reciepe();

            if (ValidationCheck(lines)) {

                bool tasteCheck = Int32.TryParse(lines[4], out int tastyLevel);

                bool difficultyCheck = Int32.TryParse(lines[5], out int difficultyLevel);

                bool timeCheck = Int32.TryParse(lines[6], out int time);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 6; i < lines.Length; i++)
                {
                    stringBuilder.AppendLine(lines[i]);
                }

                reciepe.Title = lines[0];
                reciepe.SubTitle = lines[1];
                reciepe.Description = lines[2];
                reciepe.ImagePath = lines[3];
                reciepe.Tasty = (Tasty)tastyLevel;
                reciepe.Difficulty = (Difficulty)difficultyLevel;
                reciepe.TimeinMin = time;
                reciepe.Instructions = stringBuilder.ToString();

            }

            return reciepe;

        }

        public void GetImagePath()
        {

        }

        private bool ValidationCheck(string[] lines)
        {
            bool tasteCheck = Int32.TryParse(lines[4],out int tastyLevel);

            bool difficultyCheck = Int32.TryParse(lines[5], out int difficultyLevel);

            bool timeCheck = Int32.TryParse(lines[6], out int time);

            if(tasteCheck == false || difficultyCheck == false || timeCheck == false)
            {
                return false;
            }

            return true; 
        }
    }
}
