using System; 
using Emgu.CV;
using Emgu.CV.Structure; 

namespace ourNamespace 
{
  class Program 
  {
    static void Main(string[] args)
    {
        Mat answeredPic = CvInvoke.Imread("./img/GraderPage-Answered.jpg");
        Mat aWasAnswered = CvInvoke.Imread("./img/A_abcd.jpg"); 

        CvInvoke.Resize(answeredPic, answeredPic, new System.Drawing.Size(0,0), .7d, .7d); 
        CvInvoke.Resize(aWasAnswered, aWasAnswered, new System.Drawing.Size(0,0), .7d, .7d); 

        Mat templateOutput = new Mat(); 

        CvInvoke.MatchTemplate(answeredPic, aWasAnswered, templateOutput, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed); 

        double minVal = 0.0d; 
        double maxVal = 0.0d; 
        System.Drawing.Point minLoc = new System.Drawing.Point(); 
        System.Drawing.Point maxLoc = new System.Drawing.Point(); 

        CvInvoke.MinMaxLoc(templateOutput, ref minVal, ref maxVal, ref minLoc, ref maxLoc); 

        CvInvoke.Threshold(templateOutput, templateOutput, 0.85, 1, Emgu.CV.CvEnum.ThresholdType.ToZero); 

        var matches = templateOutput.ToImage<Gray, byte>(); 

        for (int i = 0; i < matches.Rows; i++) 
        {
            for (int j = 0; j < matches.Cols; j++) 
            {
              if (matches[i, j].Intensity > .8) 
              {
                System.Drawing.Point loc = new System.Drawing.Point(j, i); 
                System.Drawing.Rectangle box = new System.Drawing.Rectangle(loc, aWasAnswered.Size); 

                CvInvoke.Rectangle(answeredPic, box, new Emgu.CV.Structure.MCvScalar(0, 255, 0), 2); 
              }
            }
        }

        CvInvoke.Imshow("templates detected", answeredPic); 
        CvInvoke.Imshow("templateOutput", templateOutput); 

        CvInvoke.WaitKey(); 

    }
  }
}
