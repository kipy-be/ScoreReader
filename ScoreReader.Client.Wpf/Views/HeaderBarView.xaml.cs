using System.Windows;
using System.Windows.Controls;

namespace ScoreReader.Client.Wpf.Views
{
    public partial class HeaderBarView : UserControl
    {
        private bool _busyMode;

        public HeaderBarView()
        {
            InitializeComponent();
            IsBusy = false;
        }

        public bool IsBusy
        {
            get { return _busyMode; }
            set
            {
                _busyMode = value;
                imgBusy.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}
