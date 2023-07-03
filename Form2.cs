using PokusMultiFormAmonV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PokusMultiFormAmonV
{
    public partial class Form2 : Form
    {
        private Data notes;
        private String selectedNote;
        public Form2(Data notes, String selectedNote)
        {
            InitializeComponent();
            this.selectedNote = selectedNote;
            this.notes = notes;

            this.richTextBox1.Text = selectedNote;
        }

        private void save()
        {
            if (this.selectedNote.Length == 0)
            {
                this.notes.addNote(this.richTextBox1.Text);
            }
            else
            {
                this.notes.searchAndReplace(this.selectedNote, this.richTextBox1.Text);
            }
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.notes.searchAndDeleteNote(this.selectedNote);
            this.Close();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save();
            }
        }
    }
}
