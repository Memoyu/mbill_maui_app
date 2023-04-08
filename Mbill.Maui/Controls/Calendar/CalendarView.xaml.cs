using Mbill.Maui.Controls.Calendar.Model;

namespace Mbill.Maui.Controls.Calendar;

public partial class CalendarView : ContentView
{
    public IEnumerable<string> DaysOfWeek
    {
        get => new List<string> { "һ", "��", "��", "��", "��", "��", "��" };
    }

    public IEnumerable<CalendarDay> FirstDays
    {
        get => new List<CalendarDay> { new CalendarDay { Date = DateTime.Now } };
    }

    public CalendarView()
    {
        InitializeComponent();
        DaysView.Days = BuildDate(DateTime.Now);
    }

    private List<CalendarDay> BuildDate(DateTime date)
    {
        var days = new List<CalendarDay>();
        var currentDate = new DateTime(date.Year, date.Month, 1);

        // ��ȡ���µ�һ�������ܵ� �����յ�����
        while (currentDate.DayOfWeek != DayOfWeek.Sunday)
        {
            currentDate = currentDate.AddDays(-1);
        }

        // һ����ȡ42�죨6w * 7d��
        while (days.Count < 42)
        {
            currentDate = currentDate.AddDays(1);
            days.Add(BuildCalendarDay(date, currentDate));
        }

        return days;
    }

    private CalendarDay BuildCalendarDay(DateTime date, DateTime currentDate)
    {
        return new CalendarDay
        {
            Date = currentDate,
            IsCurrentMonth = currentDate.Month == date.Month && currentDate.Year == date.Year,
            IsToday = currentDate.Date == DateTime.Today,
        };
    }
}