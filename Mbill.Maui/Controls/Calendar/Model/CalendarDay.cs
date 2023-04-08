namespace Mbill.Maui.Controls.Calendar.Model
{
    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public bool IsSelected { get; set; }
        public bool IsCurrentMonth { get; set; }
        public bool IsToday { get; set; }
        public bool IsInvalid { get; set; }
    }
}
