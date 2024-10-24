
//Multiple face detection and recognition in real time
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net
//Writed by Sergio Andrés Guitérrez Rojas
//"Serg3ant" for the delveloper comunity
// Sergiogut1805@hotmail.com
//Regards from Bucaramanga-Colombia ;)
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;
using System.Linq;
using static WindowFormUI.QLDIEMDANHDataSet;
using Emgu.CV.UI;




namespace WindowFormUI
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        private int schoolId;
        private int classId;
        private string schoolName;
        private string className;
        private string attendanceDate;
        private HashSet<string> studentNames;
        private readonly ClassTableAdapter classTableAdapter = new ClassTableAdapter();


        public FrmPrincipal()
        {
            InitializeComponent();
            this.schoolId = 0;
            this.classId = 0;
            this.schoolName = "";
            this.className = "";
            this.attendanceDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.classTableAdapter = new ClassTableAdapter();
            this.studentNames = new HashSet<string>();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add face.", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public int ClassId
        {
            get => classId;
            set => classId = value;
        }

        public string AttendanceDate
        {
            get => attendanceDate;
            set => attendanceDate = value;
        }

        public int SchoolId { get => schoolId; set => schoolId = value; }

        public string SchoolName { get => schoolName; set => schoolName = value; }

        public string ClassName { get => className; set => className = value; }

        private void StopChecking(object sender, EventArgs e)
        {

            var classRow = classTableAdapter.GetClassById(this.classId).ToList()[0];

            string path = classRow.excel_path;
            if (path != null)
            {
                // create sheet to dest excel file
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);
                Excel.Worksheet worksheet = workbook.Worksheets[1];
                Excel.Range usedRange = worksheet.UsedRange;
                // add new sheet the latest
                Excel.Worksheet newSheet = workbook.Worksheets.Add(After: worksheet);
                newSheet.Name = attendanceDate;
                newSheet.Cells[1, 1] = "MSSV";
                newSheet.Cells[1, 2] = "Time";

                try
                {
                    int rowCount = worksheet.UsedRange.Rows.Count;
                    int columnCount = worksheet.UsedRange.Columns.Count;

                    // get the range of the data
                    Excel.Range range = worksheet.Range["A1", worksheet.Cells[rowCount, columnCount]];

                    // get values
                    object[,] values = (object[,])range.Value;

                    // check if student is in the class

                    for (int i = 2; i <= rowCount; i++)
                    {
                        foreach (string studentName in studentNames)
                        {
                            if (studentName == values[i, 1].ToString())
                            {
                                newSheet.Cells[i, 1] = values[i, 1];
                                newSheet.Cells[i, 2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                    }

                    worksheet.Cells[1, worksheet.UsedRange.Columns.Count + 1] = attendanceDate;
                    for (int i = 2; i <= rowCount; i++)
                    {
                        for (int j = 2; j <= newSheet.UsedRange.Rows.Count; j++)
                        {
                            if (double.Parse(values[i, 1].ToString()) != newSheet.Cells[j, 1].Value)
                            {
                                worksheet.Cells[i, worksheet.UsedRange.Columns.Count] = "X";
                            }
                            else
                            {
                                worksheet.Cells[i, worksheet.UsedRange.Columns.Count] = " ";
                            }
                        }
                    }
                    workbook.SaveAs(path);

                    // Realse excel object
                    application.Quit();

                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("That name is already taken"))
                    {
                        MessageBox.Show("Ngày này đã được điểm danh, vui lòng xoá sheet điểm danh này để điểm danh lại!");
                    }
                    application.Quit();
                }
            }
            else
            {
                MessageBox.Show("No class file found");
            }

            ClassView classView = new ClassView
            {
                ClassId = this.classId,
                SchoolId = this.schoolId,
                SchoolName = this.schoolName,
                ClassName = this.className
            };
            classView.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please input your name to add face");
                }
                else
                {
                    //Trained face counter
                    ContTrain = ContTrain + 1;

                    //Get a gray frame from capture device
                    gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face,
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                        break;
                    }

                    //resize face detected image for force to compare the same size with the 
                    //test image with cubic interpolation type method
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    trainingImages.Add(TrainedFace);
                    labels.Add(textBox1.Text);

                    //Show face added in gray scale
                    imageBox1.Image = TrainedFace;

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }

                    MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("No face detected. Please check your camera or stand closer.", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Green), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                label3.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 */

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
                studentNames.Add(NamePersons[nnn]);
            }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
        }
    }
}
