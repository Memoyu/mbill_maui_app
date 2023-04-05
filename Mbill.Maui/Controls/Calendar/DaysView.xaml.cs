using System.Windows.Input;
using Mbill.Maui.Controls.Calendar.Model;

namespace Mbill.Maui.Controls.Calendar;

public partial class DaysView : ContentView
{
    public IList<string> DaysOfWeek
    {
        get => (IList<string>)GetValue(DaysOfWeekProperty);
        set => SetValue(DaysOfWeekProperty, value);
    }
    public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<string>), typeof(DaysView), new List<string> { "一", "二", "三", "四", "五", "六", "日" });

    public IEnumerable<CalendarDay> Days
    {
        get => (IEnumerable<CalendarDay>)GetValue(DaysProperty);
        set => SetValue(DaysProperty, value);
    }
    public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<DaysView>), typeof(DaysView), propertyChanged: DaysPropertyChanged);

    public ICommand SelectedCommand
    {
        get => (ICommand)GetValue(SelectedCommandProperty);
        set => SetValue(SelectedCommandProperty, value);
    }
    public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(DaysView), propertyChanged: StateAppearanceChanged);

    public DaysView()
    {
        InitializeComponent();
        //var items = new List<CalendarDay>();
        //for (int i = 1; i < 32; i++)
        //{
        //    items.Add(new CalendarDay { Day = i.ToString() });
        //}

        //Days = items;
        //DaysColloction.ItemsSource = items;
    }

    private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        DaysView control = (DaysView)bindable;
        IEnumerable<CalendarDay> newDays = (IEnumerable<CalendarDay>)newValue;
        control.MainCollectionView.ItemsSource = newDays;
    }

    private static void StateAppearanceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        DaysView control = (DaysView)bindable;
        // control.UpdateView();
    }
}