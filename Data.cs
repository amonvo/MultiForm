using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PokusMultiFormAmonV
{
    public class Data
    {
        const String DATA_PATH = @"C:\data\data.notes";

        public List<String> notes { get; }

        public Data()
        {
            this.notes = new List<String>();
        }

        public void addNote(String note)
        {
            this.notes.Add(note);
        }

        public void deleteNoteByIndex(int index)
        {
            this.notes.RemoveAt(index);
        }

        public void searchAndDeleteNote(String note)
        {
            this.notes.Remove(note);
        }

        public void replace(int index, String newNote)
        {
            this.notes[index] = newNote;
        }

        public void searchAndReplace(String oldNote, string newNote)
        {
            this.replace(this.notes.IndexOf(oldNote), newNote);
        }

        public void saveToFile()
        {
            this.saveToFile(DATA_PATH);
        }

        public void saveToFile(String path)
        {
            using (FileStream fs = File.OpenWrite(path))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (String note in this.notes)
                    {
                        tw.WriteLine(note);
                    }
                }
            }
        }

        public static Data loadFromFile()
        {
            return loadFromFile(DATA_PATH);
        }

        public static Data loadFromFile(String path)
        {
            if (!File.Exists(path))
            {
                return new Data();
            }

            Data notes = new Data();
            using (FileStream fs = File.OpenRead(path))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    String line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        notes.addNote(line.Trim());
                    }
                }
            }

            return notes;
        }
    }
}
