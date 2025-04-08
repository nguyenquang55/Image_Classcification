using ImageClassification;
using System.Net.Http.Headers;

namespace Image_Classcification
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            string Path = folderWorking.OpenFileOrFolder();
        }

        private void btnClasscify_Click(object sender, EventArgs e)
        {
            imageClassification.ClassifyImages(pbOriginal, tbClass);

        }

        private void pbOriginal_Click(object sender, EventArgs e)
        {

        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
