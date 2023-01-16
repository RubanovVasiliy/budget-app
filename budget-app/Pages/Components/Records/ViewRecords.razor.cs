using budget_app.Data;
using Microsoft.AspNetCore.Components;

namespace budget_app.Pages.Components.Records;

public partial class ViewRecords
{
    [Parameter] public List<Record>? Records { get; set; }
    [Parameter] public EventCallback<Record> OnRecordClick { get; set; }
    [Parameter] public EventCallback<Record> DeleteRecord { get; set; }
    [Parameter] public EventCallback<Record> UpdateRecord { get; set; }
}