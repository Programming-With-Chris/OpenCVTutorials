using System;
using Emgu.CV; 


namespace myNamespace 
{
  class Video1 
  {
    static void Main(string[] args)
    {
        Mat pic = new Mat(); 

        pic = CvInvoke.Imread("./img/starrynight.jpg"); 

        Mat gaussianBlur = new Mat(); 

        CvInvoke.GaussianBlur(pic, gaussianBlur, new System.Drawing.Size(pic.Rows, pic.Cols), 7.0); 

        CvInvoke.Imshow("starry night", pic); 
        CvInvoke.Imshow("blurry night", gaussianBlur); 


        CvInvoke.WaitKey(); 
    }
  }
}
