using ScoreReader.Core;
using System;
using System.Windows;

namespace ScoreReader.Client.Wpf.Views
{
    public partial class MainWindow : Window
    {
        private PedalManager _pedalManager = new PedalManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pdfViewer.LoadFile(@"D:\piano\ToDo\Final Fantasy 9 - Terra (reborn).pdf");

            _pedalManager.SoftPedal_Push += SoftPedal_Push;
            _pedalManager.Init();
        }

        private void SoftPedal_Push(object sender, SoftPedalPushEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                switch (e.Type)
                {
                    case PushType.Short:
                        pdfViewer.Next();
                        break;
                    case PushType.Long:
                        pdfViewer.First();
                        break;
                }
            });
        }

        private void WindowUnloaded(object sender, RoutedEventArgs e)
        {
            _pedalManager.Dispose();
        }
    }
}
