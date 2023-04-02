using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows.Input;

namespace Mbill.Maui.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string title = "Text";


        public MainPageViewModel()
        {
        }

        public async Task InitializeAsync()
        {
            Trace.WriteLine("msg");
        }

        /// <summary>
        /// 通用的执行命令方法
        /// </summary>
        /// <param name="arg">命名指向类型</param>
        [RelayCommand]
        async Task ExecuteCommand(string arg)
        {
            switch (arg)
            {
                case "Bill":
                    title = "Bill";
                    break;
                case "ProfileTab":
                    title = "Profile";
                    break;
            }
        }
    }
}
