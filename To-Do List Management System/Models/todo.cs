using System.ComponentModel.DataAnnotations;

namespace To_Do_List_Management_System_.Models
{
    public class todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string title { get; set; }

        [Range(1,5,ErrorMessage="Criticality must be between 1 to 5 only !!")]
        public int importance { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
