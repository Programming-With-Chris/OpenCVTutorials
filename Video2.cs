using System;
using Emgu.CV; 
using Emgu.CV.CvEnum;
using Emgu.CV.Structure; 


namespace MyNamespace 
{
  class Program 
  {
    /*static void Main(string[] args)
    {
        Mat pic = CvInvoke.Imread("./img/starrynight.jpg"); 
        Mat resizedPic = new Mat(); 

        int height = pic.Rows;
        int width = pic.Cols; 

        Console.WriteLine($"starry night is : {height} x {width}"); 

        CvInvoke.Resize(pic, resizedPic, new System.Drawing.Size(400, 500)); 

        CvInvoke.Imshow("starry night", pic); 
        CvInvoke.Imshow("resized night", resizedPic); 

        CvInvoke.WaitKey(); 


        double angleFourtyFive = 45d; 

        System.Drawing.PointF center = new System.Drawing.PointF((width - 1) / 2.0f, (height - 1) / 2.0f); 
        Mat rotationMatrix = new Mat(); 

        CvInvoke.GetRotationMatrix2D(center, angleFourtyFive, 1.0, rotationMatrix); 
        Mat rotatedPic = new Mat(); 

        CvInvoke.WarpAffine(pic, rotatedPic, rotationMatrix, new System.Drawing.Size(width, height)); 

        CvInvoke.Imshow("rotated night", rotatedPic); 

        CvInvoke.WaitKey(); 


        Image<Bgr, byte> convertPic = pic.ToImage<Bgr, byte>(); 

        var image = convertPic.InRange(new Bgr(75, 0, 0), new Bgr(255, 125, 125));

        for (int i = 0; i < image.Rows; i++) 
        {
            for (int j = 0; j < image.Cols; j++) 
            {
                var num = image[i, j]; 

                if (num.Intensity > 0) 
                {
                    convertPic[i, j] = new Bgr(convertPic[i,j].MCvScalar.V0 - 50, convertPic[i,j].MCvScalar.V1 - 50, convertPic[i,j].MCvScalar.V2 + 100); 
                }
            }

        } 

        Mat changedPic = convertPic.Mat; 

        CvInvoke.Imshow("starry night", pic); 
        CvInvoke.Imshow("color-shifted night", changedPic); 

        CvInvoke.WaitKey(); 


        float[,] kernelArray = new float[3, 3] {
            {  -1, -1,  -1},
            { -1,  8, -1},
            {  -1, -1,  -1}
        };

        ConvolutionKernelF kernel = new ConvolutionKernelF(kernelArray); 

        Mat filteredPic = new Mat(); 

        pic.CopyTo(filteredPic);

        CvInvoke.Filter2D(pic, filteredPic, kernel, new System.Drawing.Point(0, 0)); 

        CvInvoke.Imshow("convoluted night", filteredPic); 
        CvInvoke.WaitKey(); 

    }*/
  }
}
