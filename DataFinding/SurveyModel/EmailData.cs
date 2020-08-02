using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFinding.SurveyModel
{
    public partial class EmailData
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string EmailAddress { get; set; }
        public bool EmailSent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SentDate { get; set; }
        public bool IsViewed { get; set; }
    }
}
