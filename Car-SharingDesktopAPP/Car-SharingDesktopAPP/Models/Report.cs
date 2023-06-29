using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tytuł raportu jest wymagany!")]
        [MaxLength(50, ErrorMessage = "Tytuł raportu nie może być dłuższy niż 50 znaków!")]
        public string ReportTitle { get; set; }
        [Required(ErrorMessage = "Opis raportu jest wymagany!")]
        [MaxLength(1000, ErrorMessage = "Opis raportu nie może być dłuższy niż 1000 znaków!")]
        public string ReportDescription { get; set; }
        [Required(ErrorMessage = "Data raportu jest wymagana!")]
        public DateTime ReportDate { get; set; }
        [Required(ErrorMessage = "Status raportu jest wymagany!")]
        public ReportStatus ReportStatus { get; set; }
    }

}

public enum ReportStatus
{
    New = 0,
    InProgress = 1,
    Completed = 2
}
