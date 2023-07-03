using PokusMultiFormAmonV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokusMultiFormAmonV
{
    public partial class Form1 : Form
    {
        private Data notes;

        public Form1()
        {
            InitializeComponent();
            this.notes = Data.loadFromFile();
            this.renderNoteList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 noteForm = new Form2(this.notes, "");
            noteForm.FormClosed += NoteForm_FormClosed;
            noteForm.Show();
        }

        private void NoteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.renderNoteList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.notes.saveToFile();
        }

        private void renderNoteList()
        {
            this.listBox.Items.Clear();

            foreach (var note in this.notes.notes)
            {
                this.listBox.Items.Add(note);
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            Form2 noteForm = new Form2(this.notes, this.listBox.SelectedItem.ToString());
            noteForm.FormClosed += NoteForm_FormClosed;
            noteForm.Show();
        }
    }
}
