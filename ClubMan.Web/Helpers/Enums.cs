namespace ClubMan.Web.Helpers;

public enum ExportFormat
{
    Excel,
    PDF,
    CSV
}

public enum ReviewForm
{
    Approve,
    Reject,
    Postpone,
}

public enum FilterMode
{
    NoFilter,
    Full,
    DateRange,
    JustCheckBox,
    AsOfDate,
    AsOfDatePlusCheckBox
}