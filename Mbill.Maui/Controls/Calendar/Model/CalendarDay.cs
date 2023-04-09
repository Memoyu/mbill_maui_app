namespace Mbill.Maui.Controls.Calendar.Model
{
    public class CalendarDay : ObservableObject
    {
        private DateTime date;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

        private bool isSelected;
        public bool IsSelected { get => isSelected; set => SetProperty(ref isSelected, value); }

        public bool IsCurrentMonth { get; set; }
        public bool IsToday { get; set; }

        private bool isHasBill;
        public bool IsHasBill { get => isHasBill; set => SetProperty(ref isHasBill, value); }
    }
}
