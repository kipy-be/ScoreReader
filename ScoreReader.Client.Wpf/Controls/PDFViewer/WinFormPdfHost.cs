using System.Windows.Forms;

namespace WPFPdfViewer
{
    public partial class WinFormPdfHost : UserControl
    {
        public WinFormPdfHost()
        {
            InitializeComponent();
            if(!DesignMode)
            pdfViewer.setShowToolbar(false);
        }

        public void LoadFile(string path)
        {
            pdfViewer.LoadFile(path);
            pdfViewer.src = path;
            pdfViewer.setViewScroll("FitH", 0);
        }

        public void SetShowToolBar(bool on)
        {
            pdfViewer.setShowToolbar(on);
        }
    }
}
