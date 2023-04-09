using Mbill.Maui.Controls.Calendar.Model;
using Mbill.Maui.Models;

namespace Mbill.Maui.Controls.Calendar;

public partial class CalendarView : ContentView
{
    public IEnumerable<string> DaysOfWeek
    {
        get => new List<string> { "一", "二", "三", "四", "五", "六", "日" };
    }

    public IEnumerable<CalendarDay> FirstDays { get; set; }

    public IEnumerable<BillTagModel> BillTags
    {
        get { return (IEnumerable<BillTagModel>)GetValue(BillTagsProperty); }
        set { SetValue(BillTagsProperty, value); }
    }
    public static readonly BindableProperty BillTagsProperty =
        BindableProperty.Create(nameof(BillTagsProperty), typeof(IEnumerable<BillTagModel>), typeof(DaysView), propertyChanged: OnBillTagsPropertyChanged);

    public CalendarView()
    {
        FirstDays = BuildDate(DateTime.Now);

        InitializeComponent();
        // DaysView.Days = BuildDate(DateTime.Now);
    }

    private List<CalendarDay> BuildDate(DateTime date)
    {
        var days = new List<CalendarDay>();
        var currentDate = new DateTime(date.Year, date.Month, 1);

        // 获取本月第一天所在周的 上周日的日期
        while (currentDate.DayOfWeek != DayOfWeek.Sunday)
        {
            currentDate = currentDate.AddDays(-1);
        }

        // 一共获取42天（6w * 7d）
        while (days.Count < 42)
        {
            currentDate = currentDate.AddDays(1);
            days.Add(BuildCalendarDay(date, currentDate));
        }

        return days;
    }

    private CalendarDay BuildCalendarDay(DateTime date, DateTime currentDate)
    {
        var isToday = currentDate.Date == DateTime.Today;
        return new CalendarDay
        {
            Date = currentDate,
            IsCurrentMonth = currentDate.Month == date.Month && currentDate.Year == date.Year,
            IsToday = isToday,
            IsSelected = isToday
        };
    }

    private static void OnBillTagsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        CalendarView control = bindable as CalendarView;
        IEnumerable<BillTagModel> billTags = newValue as IEnumerable<BillTagModel>;

        foreach (var tag in billTags)
        {
            var day = control.FirstDays.FirstOrDefault(d => tag.Year == d.Date.Year && tag.Month == d.Date.Month && tag.Day == d.Date.Day);
            if (day != null) day.IsHasBill = true;
        }
    }
}