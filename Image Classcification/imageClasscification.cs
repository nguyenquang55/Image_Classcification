using System;
using System.Collections.Generic;
using System.Linq;
using Image_Classcification;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using SkiaSharp;


namespace ImageClassification
{
    internal class imageClassification
    {
        private static List<string> _images = new List<string>();
        public static async void ClassifyImages(PictureBox pictureBox, TextBox textBox)
        {
            var session = new InferenceSession(@"D:\Source\C#winform\Image Classcification\Image Classcification\model_cifar10_v2.onnx");

            var classNames = new[]
            {
                "Airplane", "Automobile", "Bird", "Cat", "Deer",
                "Dog", "Frog", "Horse", "Ship", "Truck"
            };

            var inputMetadata = session.InputMetadata;
            string inputName = inputMetadata.Keys.First();

            var images = folderWorking.GetImages();
            if (images == null || images.Count == 0)
            {
                textBox.Text = "No images found!";
                return;
            }

            var resizedImages = images
                .Select(img => SKBitmap.FromImage(img)?.Resize(new SKImageInfo(32, 32), SKFilterQuality.High))
                .Where(resized => resized != null)
                .ToList();

            if (resizedImages.Count == 0)
            {
                textBox.Text = "Failed to resize images!";
                return;
            }

            var tensors = new List<DenseTensor<float>>();

            for (int i = 0; i < resizedImages.Count; i++)
            {
                var img = resizedImages[i];

                var inputTensor = new DenseTensor<float>(new[] { 1, 32, 32, 3 });
                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        var pixel = img.GetPixel(x, y);
                        inputTensor[0, y, x, 0] = pixel.Red / 255f;
                        inputTensor[0, y, x, 1] = pixel.Green / 255f;
                        inputTensor[0, y, x, 2] = pixel.Blue / 255f;
                    }
                }

                tensors.Add(inputTensor);
            }
            var inputs = new List<NamedOnnxValue>();

            for (int i = 0; i < tensors.Count; i++)
            {
                inputs.Add(NamedOnnxValue.CreateFromTensor(inputName, tensors[i]));
            }

            var resultsText = "";

            List<string> file = folderWorking.getImagePath();
            if (file == null)
            {
                file = new List<string>();
                file.Add(folderWorking.GetPath());
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                using (var results = session.Run(new[] { inputs[i] }))
                {
                    var resultTensor = results.FirstOrDefault()?.AsTensor<float>();
                    if (resultTensor == null)
                    {
                        resultsText += $"Image {i + 1}: Failed to get prediction!\n";
                        continue;
                    }

                    var values = resultTensor.ToArray();
                    var predictedClass = values
                        .Select((value, index) => new { value, index })
                        .OrderByDescending(x => x.value)
                        .First().index;

                    var conf = values.Max();
                    if (conf <= 0.6)
                    {
                        textBox.Text = "Image can be detected";
                        _images.Add("NULL");
                    }
                    else
                    {
                        textBox.Text = $"Image {i + 1}: {classNames[predictedClass]} {conf.ToString("P2")}";
                        _images.Add(classNames[predictedClass]);

                    }
                    pictureBox.Image = new Bitmap(file[i]);    
                    await Task.Delay(3000);
                }
            }
        }

        public static List<string> GetImages() { return _images; }
    }
}
