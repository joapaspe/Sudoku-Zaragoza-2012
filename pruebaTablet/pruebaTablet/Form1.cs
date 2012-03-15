using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;
namespace pruebaTablet
{
    public partial class Form1 : Form
    {
        InkOverlay inkOverlay;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inkOverlay = new InkOverlay();
            inkOverlay.Handle = this.Handle;
            inkOverlay.Enabled = true;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Recognizers recs = new Recognizers();
            Recognizer reco = recs.GetDefaultRecognizer();
            RecognizerContext context = reco.CreateRecognizerContext();
            context.Strokes = inkOverlay.Ink.Strokes;

            RecognitionStatus status = RecognitionStatus.NoError;
            RecognitionResult res = context.Recognize(out status);

            if (status == RecognitionStatus.NoError)
            {
                MessageBox.Show(res.TopAlternate.ToString());

            }

        }
    }
}
