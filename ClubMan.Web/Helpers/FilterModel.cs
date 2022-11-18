namespace ClubMan.Web.Helpers;


public class FilterModel
{
    private FilterModel()
    {
        
    }
    public static FilterModel Empty()
    {
        return new FilterModel() {FilterMode = FilterMode.NoFilter};
    }
    public static FilterModel FullFilterModel(DateTime fromDate, DateTime toDate, bool isChecked = false, string checkBoxText = "Sólo Activos")
    {
        return new FilterModel()
        {
            FilterMode = FilterMode.Full,
            FromDate = fromDate,
            ToDate = toDate,
            Checked = isChecked,
            CheckedText = checkBoxText
        };
    }
    public static FilterModel DateRangeFilterModel(DateTime fromDate, DateTime toDate)
    {
        return new FilterModel()
        {
            FilterMode = FilterMode.DateRange,
            FromDate = fromDate,
            ToDate = toDate,
        };
    }
    public static FilterModel JustCheckBox(bool isChecked = false, string checkBoxText = "Sólo Activos")
    {
        return new FilterModel()
        {
            FilterMode = FilterMode.JustCheckBox,
            Checked = isChecked,
            CheckedText = checkBoxText
        };
    }
    public static FilterModel AsOfDate(DateTime dateTo)
    {
        return new FilterModel()
        {
            FilterMode = FilterMode.AsOfDate,
            ToDate = dateTo
        };
    }
    public static FilterModel AsOfDatePlusCheckBox(DateTime dateTo, bool isChecked = false, string checkBoxText = "Sólo Activos")
    {
        return new FilterModel()
        {
            FilterMode = FilterMode.AsOfDatePlusCheckBox,
            ToDate = dateTo,
            Checked = isChecked,
            CheckedText = checkBoxText
        };
    }
    public FilterMode FilterMode { get; set; }
    public string CheckedText { get; set; }
    public bool Checked  { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public bool ShowRangeSelector => (FilterMode == FilterMode.Full || FilterMode == FilterMode.DateRange);
    public bool ShowDateFrom => (FilterMode == FilterMode.Full || FilterMode == FilterMode.DateRange);
    public bool ShowDateTo => (FilterMode == FilterMode.Full || FilterMode == FilterMode.DateRange || FilterMode == FilterMode.AsOfDate || FilterMode == FilterMode.AsOfDatePlusCheckBox);
    public bool ShowCheckBox => (FilterMode == FilterMode.Full || FilterMode == FilterMode.AsOfDatePlusCheckBox);
}