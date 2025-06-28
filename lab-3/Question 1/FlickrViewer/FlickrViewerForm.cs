using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlickrViewer
{
    public partial class FlickrViewerForm : Form
    {
        private const string KEY = "b3382d4426c734e236bb5020cd34e860"; // My API key
        private static HttpClient flickrClient = new HttpClient();
        private Task<string> flickrTask = null;

        public FlickrViewerForm()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (flickrTask?.IsCompleted == false)
            {
                var result = MessageBox.Show(
                    "Cancel the current Flickr search?",
                    "Are you sure?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    flickrClient.CancelPendingRequests(); 
                    flickrTask = null; 
                }
                else
                {
                    return; 
                }
            }

            imagesListBox.DataSource = null;
            imagesListBox.Items.Clear();
            imagesListBox.Items.Add("Loading...");
            pictureBox.Image = null;

            var flickrURL = "https://api.flickr.com/services/rest/?method=" +
                "flickr.photos.search&api_key=" + KEY + "&" +
                "tags=" + inputTextBox.Text.Replace(" ", ",") +
                "&tag_mode=all&per_page=500&privacy_filter=1";

            try
            {
                flickrTask = flickrClient.GetStringAsync(flickrURL); // Async API call
                var responseString = await flickrTask; 

                if (string.IsNullOrWhiteSpace(responseString))
                {
                    imagesListBox.Items.Add("Flickr returned an empty response.");
                    return;
                }

                XDocument flickrXML = XDocument.Parse(responseString); // Parse XML
                var flickrPhotos = from photo in flickrXML.Descendants("photo")
                                   let id = photo.Attribute("id").Value
                                   let title = photo.Attribute("title").Value
                                   let secret = photo.Attribute("secret").Value
                                   let server = photo.Attribute("server").Value
                                   let farm = photo.Attribute("farm").Value
                                   select new FlickrResult
                                   {
                                       Title = title,
                                       URL = $"https://farm{farm}.staticflickr.com/{server}/{id}_{secret}.jpg"
                                   };

                imagesListBox.Items.Clear(); 

                if (flickrPhotos.Any())
                {
                    imagesListBox.DataSource = flickrPhotos.ToList();
                    imagesListBox.DisplayMember = "Title";
                }
                else
                {
                    imagesListBox.Items.Add("No matches found."); 
                }
            }
            catch (HttpRequestException ex)
            {
                imagesListBox.Items.Clear();
                imagesListBox.Items.Add("Error: Unable to complete search.");
                MessageBox.Show($"HttpRequestException: {ex.Message}", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imagesListBox.SelectedItem != null)
            {
                FlickrResult selectedResult = (FlickrResult)imagesListBox.SelectedItem;
                string selectedURL = selectedResult.URL;

                Parallel.Invoke(
                    () => DisplayImageSync(selectedURL),
                    () => GenerateAndSaveThumbnailSync(selectedURL)
                );
            }
        }











        private void DisplayImageSync(string url)
        {
            byte[] imageBytes = flickrClient.GetByteArrayAsync(url).GetAwaiter().GetResult();
            using (var memoryStream = new MemoryStream(imageBytes))
            {
                if (pictureBox.InvokeRequired)
                {
                    pictureBox.Invoke(new MethodInvoker(delegate
                    {
                        pictureBox.Image = Image.FromStream(memoryStream);
                    }));
                }
                else
                {
                    pictureBox.Image = Image.FromStream(memoryStream);
                }
            }
        }

        private void GenerateAndSaveThumbnailSync(string url)
        {
            byte[] imageBytes = flickrClient.GetByteArrayAsync(url).GetAwaiter().GetResult();
            GenerateThumbnail(imageBytes, CreateUniqueThumbnailFileName(url));
        }

        private void GenerateThumbnail(byte[] imageBytes, string thumbnailFileName)
        {
            int imageHeight = 100;
            int imageWidth = 100;
            using (Image fullSizeImg = Image.FromStream(new MemoryStream(imageBytes)))
            {
                using (Image thumbnailImage = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
                {
                    // Ensure the Thumbnails directory exists in the Downloads folder
                    string thumbnailsPath = Path.Combine(@"C:\Users\volta\Downloads", "Thumbnails");
                    Directory.CreateDirectory(thumbnailsPath);

                    string fullPath = Path.Combine(thumbnailsPath, thumbnailFileName);
                    thumbnailImage.Save(fullPath, ImageFormat.Jpeg);
                }
            }
        }

        private string CreateUniqueThumbnailFileName(string imageUrl)
        {
            Uri uri = new Uri(imageUrl);
            string filename = Path.GetFileName(uri.LocalPath);
            string thumbnailFileName = $"thumbnail_{filename}";
            return thumbnailFileName;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void FlickrViewerForm_Load(object sender, EventArgs e)
        {
            
        }

     
    }
}
