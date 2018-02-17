using System.Windows.Forms;

namespace ScoreReader.Client.Wpf.Controls
{
    public partial class WinFormsPdfViewer : UserControl
    {
        public WinFormsPdfViewer()
        {
            InitializeComponent();
            if(!DesignMode)
                axAcrobat.setShowToolbar(false);
        }

        public void LoadFile(string path)
        {
            axAcrobat.LoadFile(path);
            axAcrobat.src = path;
            axAcrobat.gotoFirstPage();
        }

        public void Next()
        {
            axAcrobat.gotoNextPage();
            axAcrobat.gotoNextPage();
        }

        public void Previous()
        {
            axAcrobat.gotoPreviousPage();
            axAcrobat.gotoPreviousPage();
        }

        public void First()
        {
            axAcrobat.gotoFirstPage();
        }
    }
}
