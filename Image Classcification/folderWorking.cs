using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SkiaSharp;

namespace Image_Classcification
{
    internal class folderWorking
    {
        private static string Path;
        private static List<string> imageFiles;
        public static string OpenFileOrFolder()
        {
            DialogResult result = MessageBox.Show("Do you want to open a file or a folder ? Click 'Yes' for File, 'No' for Folder.",
                                                  "Open File or Folder",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select a file";
                    openFileDialog.InitialDirectory = @"C:\";
                    openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All Files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Path = openFileDialog.FileName.ToString();
                        return Path;
                    }
                }
            }
            else if (result == DialogResult.No) 
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select a folder";
                    folderDialog.ShowNewFolderButton = true;
                    folderDialog.RootFolder = Environment.SpecialFolder.Desktop;

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        return Path =folderDialog.SelectedPath.ToString(); 
                    }
                }
            }

            return null;
        }

        public static string GetPath()
        {
            return Path;
        }

        

        public static List<SKImage> GetImages()
        {
            List<SKImage> result = new List<SKImage>();

            if (File.Exists(GetPath())) // Nếu là file
            {
                try
                {
                    using (var stream = File.OpenRead(GetPath()))
                    {
                        var image = SKImage.FromEncodedData(stream);
                        result.Add(image);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image {GetPath()}: {ex.Message}");
                }
            }

            else if (Directory.Exists(GetPath())) 
            {
                imageFiles = Directory.GetFiles(GetPath(), "*.*")
                 .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                     file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                     file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                     file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                     file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                .ToList();

                foreach (string imageFile in imageFiles)
                {
                    try
                    {
                        using (var stream = File.OpenRead(imageFile))
                        {
                            var image = SKImage.FromEncodedData(stream);
                            result.Add(image);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading image {imageFile}: {ex.Message}");
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid path. Please provide a valid file or folder path.");
            }

            return result;
        }

        public static List<string> getImagePath()
        {
            return imageFiles;  
        }
    }
}
