using System;
using Emgu.CV; 
using Emgu.CV.Structure; 
using Emgu.CV.Util; 

namespace myNamespace 
{
  class Program 
  {
    static void Main(string[] args)
    {
       Mat pic = CvInvoke.Imread("./img/dog.jpg"); 

       Mat gaussianBlur = new Mat(); 
       Mat sobelX = new Mat(); 
       Mat sobelY = new Mat(); 
       Mat sobelXY = new Mat(); 

       pic.CopyTo(sobelX); 
       pic.CopyTo(sobelY); 
       pic.CopyTo(sobelXY);

       CvInvoke.GaussianBlur(pic, gaussianBlur, new System.Drawing.Size(3,3), 5.0); 

      CvInvoke.Sobel(gaussianBlur, sobelX, Emgu.CV.CvEnum.DepthType.Default, 1, 0, 5); 
      CvInvoke.Sobel(gaussianBlur, sobelY, Emgu.CV.CvEnum.DepthType.Default, 0, 1, 5); 
      CvInvoke.Sobel(gaussianBlur, sobelXY, Emgu.CV.CvEnum.DepthType.Default, 1, 1, 5); 

      //CvInvoke.Imshow("sobelX", sobelX); 
      //CvInvoke.Imshow("sobelY", sobelY); 
      //CvInvoke.Imshow("sobelXY", sobelXY);

      //CvInvoke.WaitKey();  


      Mat cannyPic = new Mat(); 
      
      var average = pic.ToImage<Gray, byte>().GetAverage(); 

      var lowerthreshold = Math.Max(0, (1.0 - 0.33) * average.Intensity); 
      var upperthreshold = Math.Max(255, (1.0 + 0.33) * average.Intensity); 



      CvInvoke.Canny(gaussianBlur, cannyPic, lowerthreshold, upperthreshold, 3); 

      //CvInvoke.Imshow("canny", cannyPic); 

      //CvInvoke.WaitKey(); 


      Mat iphone = CvInvoke.Imread("./img/iphone.jpg"); 

      VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint(); 

      Mat thresholdPic = new Mat(); 
      Mat hierarchy = new Mat(); 

      Image<Gray, byte> grayPhone = iphone.ToImage<Gray, byte>(); 

      CvInvoke.Threshold(grayPhone, thresholdPic, 210, 255, Emgu.CV.CvEnum.ThresholdType.Binary); 

      CvInvoke.Imshow("threshold", thresholdPic); 

      CvInvoke.FindContours(thresholdPic, contours, hierarchy, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone); 
      //CvInvoke.DrawContours(iphone, contours, -1, new MCvScalar(0,255,0), 2); 

      CvInvoke.FillPoly(iphone, contours, new MCvScalar(255, 100, 100)); 

      CvInvoke.Imshow("iphone", iphone); 

      CvInvoke.WaitKey(); 

    }
  }
}
