using System;

namespace TaskListApi.Models
{
    public class TaskItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Group { get; set; } // Nhóm CV
        public required bool Status { get; set; }
        public required int Priority { get; set; } // Độ ưu tiên
        public required DateTime DueDate { get; set; } // deadline
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
    }
}
