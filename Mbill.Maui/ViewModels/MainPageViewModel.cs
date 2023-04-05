using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Mbill.Maui.Controls.Calendar.Model;
using Mbill.Maui.Models;
using Mbill.Maui.Services;

namespace Mbill.Maui.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string title = "Text";

        [ObservableProperty] private List<Planet> planets;

        [ObservableProperty] private  List<CalendarDay> calendarDays;

        private  readonly PlanetsService _planetsService;

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
            await Task.CompletedTask;

            var items = new List<CalendarDay>();
            for (int i = 1; i < 32; i++)
            {
                items.Add(new CalendarDay { Day = i.ToString() });
            }

            CalendarDays = items;
        }
    }
}
