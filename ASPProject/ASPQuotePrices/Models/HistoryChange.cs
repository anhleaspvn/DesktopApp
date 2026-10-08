using System;

namespace WinFormApp.Models
{
    public class HistoryChange
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string InternalPN { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
