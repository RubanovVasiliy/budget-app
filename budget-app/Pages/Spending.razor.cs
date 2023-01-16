using budget_app.Data;
using Microsoft.AspNetCore.Components;

namespace budget_app.Pages;

public partial class Spending : IDisposable
{
    [Inject] MyDbContext Context { get; set; }
    private IEnumerable<Record>? Records { get; set; }
    private Record? ActiveRecord { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Records = await Context.GetAllRecords();
        Context.SavedChanges += Context_SavedChanges;
    }

    private void SelectRecord(Guid id) => ActiveRecord = Records?.FirstOrDefault(x => x.Id == id)!;

    private async void Context_SavedChanges(object? sender, Microsoft.EntityFrameworkCore.SavedChangesEventArgs e)
    {
        Records = await Context.GetAllRecords();
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose() => Context.SavedChanges -= Context_SavedChanges;
}