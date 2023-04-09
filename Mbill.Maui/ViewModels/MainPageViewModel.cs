using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Mbill.Maui.Controls.Calendar.Model;
using Mbill.Maui.Models;
using Mbill.Maui.Services;

namespace Mbill.Maui.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        [ObservableProperty] string title = "Text";

        [ObservableProperty] List<Planet> planets;

        [ObservableProperty] List<BillTagModel> billTasgs;

        private readonly PlanetsService _planetsService;

        public MainPageViewModel(PlanetsService planetsService)
        {
            _planetsService = planetsService;
        }

        public async Task InitializeAsync()
        {
            Trace.WriteLine("msg");
            Planets = _planetsService.GetAllPlanets();
            await Task.CompletedTask;
        }

        /// <summary>
        /// 通用的执行命令方法
        /// </summary>
        /// <param name="arg">命名指向类型</param>
        [RelayCommand]
        async Task Execute(string arg)
        {
            Title = arg;

            var items = new List<BillTagModel>();
            items.Add(new BillTagModel { Year = 2023, Month = 4, Day = 1 });
            items.Add(new BillTagModel { Year = 2023, Month = 4, Day = 9 });
            items.Add(new BillTagModel { Year = 2023, Month = 4, Day = 20 });
            BillTasgs = items;

            await Task.CompletedTask;
        }
    }
}
