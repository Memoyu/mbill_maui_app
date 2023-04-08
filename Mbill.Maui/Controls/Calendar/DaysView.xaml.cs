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
    public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<string>), typeof(DaysView));

    public IEnumerable<CalendarDay> Days
    {
        get => (IEnumerable<CalendarDay>)GetValue(DaysProperty);
        set => SetValue(DaysProperty, value);
    }
    public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<CalendarDay>), typeof(DaysView), propertyChanged: OnDaysPropertyChanged);

    public ICommand SelectedCommand
    {
        get => (ICommand)GetValue(SelectedCommandProperty);
        set => SetValue(SelectedCommandProperty, value);
    }
    public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(DaysView), propertyChanged: StateAppearanceChanged);

    public DaysView()
    {
        InitializeComponent();
    }

    private static void OnDaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
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