using System.Collections.Generic;
using System.Linq;
using ScoreReader.Client.Wpf.Common;
using ScoreReader.Client.Wpf.ViewModels;

namespace ScoreReader.Client.Wpf
{
    public class ApplicationContext
    {
        private static List<IViewModel> _viewModels;

        public ApplicationContext()
        {
            _viewModels = new List<IViewModel>();
        }

        public T GetViewModel<T>() where T : IViewModel, new()
        {
            var vm = (T)_viewModels.SingleOrDefault(s => s is T);

            if(vm == null)
            {
                vm = new T();
                _viewModels.Add(vm);
            }

            return vm;
        }

        public MainViewModel MainViewModel => GetViewModel<MainViewModel>();
    }
}
