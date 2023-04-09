using Mbill.Maui.Controls.Calendar.Model;
using System.Windows.Input;

namespace Mbill.Maui.Controls.Calendar;

public partial class DayView : ContentView
{

    public DateTime Date
    {
        get { return (DateTime)GetValue(DateProperty); }
        set { SetValue(DateProperty, value); }
    }
    public static readonly BindableProperty DateProperty =
        BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DayView), System.DateTime.Today, propertyChanged: OnDateTimePropertyChanged);
    
    public bool IsCurrentMonth
    {
        get { return (bool)GetValue(IsCurrentMonthProperty); }
        set { SetValue(IsCurrentMonthProperty, value); }
    }
    public static readonly BindableProperty IsCurrentMonthProperty =
        BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(DayView), true, propertyChanged: OnStatePropertyChanged);

    public bool IsToday
    {
        get { return (bool)GetValue(IsTodayProperty); }
        set { SetValue(IsTodayProperty, value); }
    }
    public static readonly BindableProperty IsTodayProperty =
        BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(DayView), propertyChanged: OnStatePropertyChanged);

    public bool IsSelected
    {
        get { return (bool)GetValue(IsSelectedProperty); }
        set { SetValue(IsSelectedProperty, value); }
    }
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(DayView), propertyChanged: OnStatePropertyChanged);
    
    public bool IsHasBill
    {
        get { return (bool)GetValue(IsHasBillProperty); }
        set { SetValue(IsHasBillProperty, value); }
    }
    public static readonly BindableProperty IsHasBillProperty =
        BindableProperty.Create(nameof(IsHasBill), typeof(bool), typeof(DayView), propertyChanged: OnStatePropertyChanged);


    public CalendarDayState DayState
    {
        get { return (CalendarDayState)GetValue(DayStateProperty); }
        set { SetValue(DayStateProperty, value); }
    }
    public static readonly BindableProperty DayStateProperty =
        BindableProperty.Create(nameof(DayState), typeof(CalendarDayState), typeof(DayView), propertyChanged: OnStatePropertyChanged);

    public Color CurrentMonthTextColor
    {
        get { return (Color)GetValue(CurrentMonthTextColorProperty); }
        set { SetValue(CurrentMonthTextColorProperty, value); }
    }
    public static readonly BindableProperty CurrentMonthTextColorProperty =
        BindableProperty.Create(nameof(CurrentMonthTextColor), typeof(Color), typeof(DayView), Colors.Black);

    public Color CurrentMonthBackgroundColor
    {
        get { return (Color)GetValue(CurrentMonthBackgroundColorProperty); }
        set { SetValue(CurrentMonthBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty CurrentMonthBackgroundColorProperty =
        BindableProperty.Create(nameof(CurrentMonthBackgroundColor), typeof(Color), typeof(DayView), Colors.Transparent);

    public Color OtherMonthTextColor
    {
        get { return (Color)GetValue(OtherMonthTextColorProperty); }
        set { SetValue(OtherMonthTextColorProperty, value); }
    }
    public static readonly BindableProperty OtherMonthTextColorProperty =
        BindableProperty.Create(nameof(OtherMonthTextColor), typeof(Color), typeof(DayView), Color.FromArgb("#FFA0A0A0"));

    public Color OtherMonthBackgroundColor
    {
        get { return (Color)GetValue(OtherMonthBackgroundColorProperty); }
        set { SetValue(OtherMonthBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty OtherMonthBackgroundColorProperty =
        BindableProperty.Create(nameof(OtherMonthBackgroundColor), typeof(Color), typeof(DayView), Colors.Transparent);

    public Color SelectedTextColor
    {
        get { return (Color)GetValue(SelectedTextColorProperty); }
        set { SetValue(SelectedTextColorProperty, value); }
    }
    public static readonly BindableProperty SelectedTextColorProperty =
        BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(DayView), Colors.White);

    public Color SelectedBackgroundColor
    {
        get { return (Color)GetValue(SelectedBackgroundColorProperty); }
        set { SetValue(SelectedBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(DayView), Color.FromArgb("#FFE00000"));

    public Color TodayTextColor
    {
        get { return (Color)GetValue(TodayTextColorProperty); }
        set { SetValue(TodayTextColorProperty, value); }
    }
    public static readonly BindableProperty TodayTextColorProperty =
        BindableProperty.Create(nameof(TodayTextColor), typeof(Color), typeof(DayView), Color.FromArgb("#A6B1E1"));
    
    public Color TodayBackgroundColor
    {
        get { return (Color)GetValue(TodayBackgroundColorProperty); }
        set { SetValue(TodayBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty TodayBackgroundColorProperty =
        BindableProperty.Create(nameof(TodayBackgroundColor), typeof(Color), typeof(DayView), Colors.Transparent);

    public Color InvalidTextColor
    {
        get { return (Color)GetValue(InvalidTextColorProperty); }
        set { SetValue(InvalidTextColorProperty, value); }
    }
    public static readonly BindableProperty InvalidTextColorProperty =
        BindableProperty.Create(nameof(InvalidTextColor), typeof(Color), typeof(DayView), Color.FromArgb("#FFFFA0A0"));

    public Color InvalidBackgroundColor
    {
        get { return (Color)GetValue(InvalidBackgroundColorProperty); }
        set { SetValue(InvalidBackgroundColorProperty, value); }
    }
    public static readonly BindableProperty InvalidBackgroundColorProperty =
        BindableProperty.Create(nameof(InvalidBackgroundColor), typeof(Color), typeof(DayView), Colors.Transparent);

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(DayView));

    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(DayView));

    public DayView()
	{
		InitializeComponent();
	}

    private static void OnDateTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        DayView control = bindable as DayView;
        control.DayState = control.EvaluateDayState();
    }

    private static void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        DayView control = (DayView)bindable;
        control.DayState = control.EvaluateDayState();
        control.UpdateView(control);
    }

    public virtual CalendarDayState EvaluateDayState()
    {
        bool isOtherMonth = !IsCurrentMonth;

        
        if (IsSelected && IsCurrentMonth)
        {
            return CalendarDayState.Selected;
        }
        else if (IsToday && IsCurrentMonth)
        {
            return CalendarDayState.Today;
        }
        else if (isOtherMonth)
        {
            return CalendarDayState.OtherMonth;
        }
        else if (IsCurrentMonth)
        {
            return CalendarDayState.CurrentMonth;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public virtual void UpdateView(DayView control)
    {
        switch (DayState)
        {
            case CalendarDayState.CurrentMonth:
                BackgroundColor = CurrentMonthBackgroundColor;
                control.CalendarDay.TextColor = CurrentMonthTextColor;
                break;

            case CalendarDayState.OtherMonth:
                BackgroundColor = OtherMonthBackgroundColor;
                control.CalendarDay.TextColor = OtherMonthTextColor;
                break;

            case CalendarDayState.Today:
                BackgroundColor = TodayBackgroundColor;
                control.CalendarDay.TextColor = TodayTextColor;
                break;

            case CalendarDayState.Selected:
                BackgroundColor = SelectedBackgroundColor;
                control.CalendarDay.TextColor = SelectedTextColor;
                break;

            default:
                throw new NotImplementedException($"{nameof(CalendarDayState)} '{DayState}' is not implemented.");
        }
    }
}