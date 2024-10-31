using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using ZedGraph;
using static Emgu.CV.Face.FaceRecognizer;

namespace WindowFormUI
{

    public class FaceRec : Form
    {
        private double distance = 1E+19;

        private CascadeClassifier CascadeClassifier = new CascadeClassifier(Environment.CurrentDirectory + "/Haarcascade/haarcascade_frontalface_alt.xml");

        private Emgu.CV.Image<Bgr, byte> Frame = null;

        private Capture camera;

        private Mat mat = new Mat();

        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();

        private List<int> PersonLabs = new List<int>();

        private bool isEnable_SaveImage = false;

        private string ImageName;

        private PictureBox PictureBox_Frame;

        private PictureBox PictureBox_smallFrame;

        private string setPersonName;

        public bool isTrained = false;

        private List<string> Names = new List<string>();

        private EigenFaceRecognizer eigenFaceRecognizer;

        private IContainer components = null;
        private HashSet<string> studentNames;

        public FaceRec()
        {
            //IL_001f: Unknown result type (might be due to invalid IL or missing references)
            //IL_0029: Expected O, but got Unknown
            //IL_0031: Unknown result type (might be due to invalid IL or missing references)
            //IL_003b: Expected O, but got Unknown
            InitializeComponent();
            studentNames = new HashSet<string>();
            if (!Directory.Exists(Environment.CurrentDirectory + "\\Image"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Image");
            }
        }

        public HashSet<string> getStudentNames()
        {
            return studentNames;
        }

        public void getPersonName(Control control)
        {
            Timer timer = new Timer();
            timer.Tick += timer_getPersonName_Tick;
            timer.Interval = 100;
            timer.Start();
            void timer_getPersonName_Tick(object sender, EventArgs e)
            {
                control.Text = setPersonName;
            }
        }

        public void openCamera(PictureBox pictureBox_Camera, PictureBox pictureBox_Trained)
        {
            //IL_0010: Unknown result type (might be due to invalid IL or missing references)
            //IL_001a: Expected O, but got Unknown
            PictureBox_Frame = pictureBox_Camera;
            PictureBox_smallFrame = pictureBox_Trained;
            camera = new Capture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            camera.Start();
        }

        public void stopCamera()
        {
            camera.Dispose();
        }

        public void Save_IMAGE(string imageName)
        {
            ImageName = imageName;
            isEnable_SaveImage = true;
        }

        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            camera.Retrieve((IOutputArray)(object)mat, 0);
            Frame = mat.ToImage<Bgr, byte>(false).Resize(PictureBox_Frame.Width, PictureBox_Frame.Height, (Inter)2);
            detectFace();
            PictureBox_Frame.Image = Frame.Bitmap;
        }

        private void detectFace()
        {
            //IL_000d: Unknown result type (might be due to invalid IL or missing references)
            //IL_0013: Expected O, but got Unknown
            //IL_0081: Unknown result type (might be due to invalid IL or missing references)
            //IL_0086: Unknown result type (might be due to invalid IL or missing references)
            //IL_008a: Unknown result type (might be due to invalid IL or missing references)
            Image<Bgr, byte> val = Frame.Convert<Bgr, byte>();
            Mat val2 = new Mat();
            CvInvoke.CvtColor((IInputArray)(object)Frame, (IOutputArray)(object)val2, (ColorConversion)6, 0);
            CvInvoke.EqualizeHist((IInputArray)(object)val2, (IOutputArray)(object)val2);
            Rectangle[] array = CascadeClassifier.DetectMultiScale((IInputArray)(object)val2, 1.1, 4, default(Size), default(Size));
            if (array.Length != 0)
            {
                Rectangle[] array2 = array;
                foreach (Rectangle rectangle in array2)
                {
                    Image<Bgr, byte> frame = Frame;
                    Bgr val3 = new Bgr(Color.LimeGreen);
                    CvInvoke.Rectangle((IInputOutputArray)(object)frame, rectangle, ((Bgr)(val3)).MCvScalar, 2, (Emgu.CV.CvEnum.LineType)8, 0);
                    SaveImage(rectangle);
                    val.ROI = rectangle;
                    trainedIamge();
                    checkName(val, rectangle);
                }
            }
            else
            {
                setPersonName = "";
            }
        }

        private void SaveImage(Rectangle face)
        {
            if (isEnable_SaveImage)
            {
                Image<Bgr, byte> val = Frame.Convert<Bgr, byte>();
                val.ROI = face;
                ((CvArray<byte>)(object)val.Resize(100, 100, (Inter)2)).Save(Environment.CurrentDirectory + "\\Image\\" + ImageName + ".jpg");
                isEnable_SaveImage = false;
                trainedIamge();
            }
        }

        private void trainedIamge()
        {
            //IL_0099: Unknown result type (might be due to invalid IL or missing references)
            //IL_00a3: Expected O, but got Unknown
            try
            {
                int num = 0;
                trainedFaces.Clear();
                PersonLabs.Clear();
                Names.Clear();
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Image", "*.jpg", SearchOption.AllDirectories);
                string[] array = files;
                foreach (string text in array)
                {
                    Image<Gray, byte> item = new Image<Gray, byte>(text);
                    trainedFaces.Add(item);
                    PersonLabs.Add(num);
                    Names.Add(text);
                    num++;
                }

                eigenFaceRecognizer = new EigenFaceRecognizer(num, distance);
                ((FaceRecognizer)eigenFaceRecognizer).Train<Gray, byte>(trainedFaces.ToArray(), PersonLabs.ToArray());
            }
            catch
            {
            }
        }

        private void checkName(Image<Bgr, byte> resultImage, Rectangle face)
        {
            try
            {
                if (isTrained)
                {
                    Image<Gray, byte> val = resultImage.Convert<Gray, byte>().Resize(100, 100, (Inter)2);
                    CvInvoke.EqualizeHist((IInputArray)(object)val, (IOutputArray)(object)val);
                    PredictionResult val2 = ((FaceRecognizer)eigenFaceRecognizer).Predict((IInputArray)(object)val);
                    Bgr val3;
                    if (val2.Label != -1 && val2.Distance < distance)
                    {
                        PictureBox_smallFrame.Image = trainedFaces[val2.Label].Bitmap;
                        setPersonName = Names[val2.Label].Replace(Environment.CurrentDirectory + "\\Image\\", "").Replace(".jpg", "");
                        Image<Bgr, byte> frame = Frame;
                        string text = setPersonName;
                        if (text.Length > 0) {
                            studentNames.Add(text);
                        }
                        Point point = new Point(face.X - 2, face.Y - 2);
                        val3 = new Bgr(Color.LimeGreen);
                        CvInvoke.PutText((IInputOutputArray)(object)frame, text, point, (FontFace)1, 1.0, ((Bgr)(val3)).MCvScalar, 1, (Emgu.CV.CvEnum.LineType)8, false);
                    }
                    else
                    {
                        Image<Bgr, byte> frame2 = Frame;
                        Point point2 = new Point(face.X - 2, face.Y - 2);
                        val3 = new Bgr(Color.OrangeRed);
                        CvInvoke.PutText((IInputOutputArray)(object)frame2, "Unknown", point2, (FontFace)1, 1.0, ((Bgr)(val3)).MCvScalar, 1, (Emgu.CV.CvEnum.LineType)8, false);
                    }
                }
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(800, 450);
            base.Name = "FaceRec";
            this.Text = "FaceRec";
            base.ResumeLayout(false);
        }
    }
}
