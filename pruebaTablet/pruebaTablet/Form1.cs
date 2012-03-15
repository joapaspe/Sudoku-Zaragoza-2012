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
            inkOverlay.Gesture += new InkCollectorGestureEventHandler(Event_OnApplicationGesture);
            inkOverlay.CollectionMode = CollectionMode.InkAndGesture;
            inkOverlay.SetGestureStatus(ApplicationGesture.Left, true);
            inkOverlay.SetGestureStatus(ApplicationGesture.Right, true);
            inkOverlay.SetGestureStatus(ApplicationGesture.Up, true);
            inkOverlay.SetGestureStatus(ApplicationGesture.Down, true);
            inkOverlay.SetGestureStatus(ApplicationGesture.Check,true);
            
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

        void Event_OnApplicationGesture(object sender, InkCollectorGestureEventArgs e)
        {
            Gesture G = e.Gestures[0];

            // we will use the gesture if it has confidence of strong or intermediate

            if (G.Confidence == RecognitionConfidence.Intermediate ||
                G.Confidence == RecognitionConfidence.Strong)
            {

                switch (G.Id)
                {
                    case ApplicationGesture.Left:
                        MessageBox.Show("Left");
                        break;
                    case ApplicationGesture.Right:
                        MessageBox.Show("Right");
                        break;
                    case ApplicationGesture.Up:
                        MessageBox.Show("Up");
                        break;
                    case ApplicationGesture.Down:
                        MessageBox.Show("Down");
                        break;
                    case ApplicationGesture.Check:
                        MessageBox.Show("Check");
                        break;
                }
            }

        }


 
    }
}
