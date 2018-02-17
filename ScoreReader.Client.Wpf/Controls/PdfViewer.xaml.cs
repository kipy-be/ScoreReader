using System.Windows.Controls;

namespace ScoreReader.Client.Wpf.Controls
{
    public partial class PdfViewer : UserControl
    {
        private string _pdfPath;
        private bool _showToolBar;
        private readonly WinFormsPdfViewer _winFormPdfViewer;

        public PdfViewer()
        {
            InitializeComponent();
            _winFormPdfViewer = wfhPdfViewer.Child as WinFormsPdfViewer;
        }


        public string PdfPath
        {
            get { return _pdfPath; }
            set
            {
                _pdfPath = value;
                LoadFile(_pdfPath);
            }
        }

        public void Next()
        {
            _winFormPdfViewer.Next();
        }

        public void Previous()
        {
            _winFormPdfViewer.Previous();
        }

        public void First()
        {
            _winFormPdfViewer.First();
        }

        public void LoadFile(string path)
        {
            _pdfPath = path;
            _winFormPdfViewer.LoadFile(path);
        }
    }
}
