using System.ComponentModel.DataAnnotations;
using budget_app.Data;
using Microsoft.AspNetCore.Components;

namespace budget_app.Pages.Components.Records
{
    public partial class AddAndUpdateRecord
    {
        [Inject] MyDbContext Context { get; set; }
        public Guid UserId { get; set; } = new();
        public string Description { get; set; } = "";
        public RecordCategory Category { get; set; } = RecordCategory.Food;
        public int Cost { get; set; }
        public DateTime Date { get; set; } = DateTime.Today.ToUniversalTime();

        [Parameter] public Record? ActiveRecord { get; set; }

        private void Clear()
        {
            Description = "";
            Category = RecordCategory.Food;
            Cost = 0;
            Date = DateTime.Today.ToUniversalTime();
        }

        private async void AddRecord()
        {
            if (Description == "") return;

            if (Category != RecordCategory.Salary)
            {
                Cost *= -1;
            }

            var project = new Record()
            {
                Description = Description,
                Category = Category,
                Cost = Cost,
                Date = Date.ToUniversalTime(),
                UserId = UserId
            };
            await Context.CreateRecord(project);
            Clear();
        }

        private async void UpdateRecord(Record record)
        {
            if (Description == "") return;
            record.Description = Description;
            record.Category = Category;
            record.Cost = Cost;
            record.Date = Date;
            await Context.UpdateRecord(record);
            Clear();
        }
    }
}