using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;

public class FaceRecognitionForm : Form
{
    private Capture capture;
    private CascadeClassifier faceCascade;
    private Mat mat = new Mat();
    private Image<Bgr, byte> frame;
    private PictureBox pictureBox;
    private LBPHFaceRecognizer recognizer;
    private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
    private List<int> labels = new List<int>();

    public FaceRecognitionForm()
    {
        this.Text = "Face Recognition with Emgu CV";
        this.Size = new Size(800, 600);

        pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        this.Controls.Add(pictureBox);

        InitializeFaceRecognition();
    }

    private void InitializeFaceRecognition()
    {
        // Load Haar Cascade for face detection
        faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

        // Initialize face recognizer
        recognizer = new LBPHFaceRecognizer();

        // Initialize video capture
        capture = new Capture();
        capture.ImageGrabbed += ProcessFrame;
        capture.Start();
    }

    private void ProcessFrame(object sender, EventArgs e)
    {

        capture.Retrieve((IOutputArray)(object)mat, 0);
        var image = mat.ToImage<Bgr, byte>();

        var grayImage = image.Convert<Gray, byte>();

        var faces = faceCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);

        foreach (var face in faces)
        {
            image.Draw(face, new Bgr(Color.Red), 2);

            // Recognize face (this is just a placeholder, actual recognition requires training data)
            // get images from image from images folder

            // training data from image folder
            int label = 0;
            var images = Directory.GetFiles("C:\\Users\\Admin\\source\\repos\\attendance-management\\WindowFormUI\\bin\\Debug\\Image", "*");
            foreach (var img in images)
            {
                trainingImages.Add(new Image<Gray, byte>(img));
                labels.Add(label++);
            }

            recognizer.Train(trainingImages.ToArray(), labels.ToArray());


            var result = recognizer.Predict(grayImage.Copy(face).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear));
            if (result.Label <= 0 && result.Distance > 100)
            {
                image.Draw("Unknown", new Point(face.X, face.Y - 10), FontFace.HersheyComplex, 1, new Bgr(Color.Yellow), 2);
            }
            else
            {
                image.Draw("Person " + result.Label, new Point(face.X, face.Y - 10), FontFace.HersheyComplex, 1, new Bgr(Color.Yellow), 2);
            }
        }

        pictureBox.Image = image.ToBitmap();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        capture.Stop();
        capture.Dispose();
        base.OnFormClosed(e);
    }

}
