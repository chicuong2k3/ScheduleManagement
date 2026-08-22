namespace ScheduleManagement.Ui.Presentation;

public partial record MainModel
{
    public MainModel(IStringLocalizer localizer, IOptions<AppConfig> appInfo)
    {
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<bool> IsSheetOpen => State<bool>.Value(this, () => false);

    public async Task ToggleSheet()
    {
        await IsSheetOpen.UpdateValue(current => !current.SomeOrDefault(false), CancellationToken.None);
    }

    public async Task SaveEvent()
    {
        // TODO: persist the new event and refresh the schedule list
        await IsSheetOpen.UpdateValue(_ => false, CancellationToken.None);
    }

    public async Task CancelEvent()
    {
        await IsSheetOpen.UpdateValue(_ => false, CancellationToken.None);
    }
}