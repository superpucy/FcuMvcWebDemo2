using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcWebDemo.Models.ViewModel
{
    public class StudentViewModel
    {

        public Guid guid { get; set; }

        [DisplayName("學號")]
        public string ID { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string NAME { get; set; }

        [DisplayName("通訊地址")]
        public string ADDRESS { get; set; }

        [DisplayName("電子信箱")]
        [EmailAddress]
        public string EMAIL { get; set; }

        [DisplayName("連絡電話")]
        [RegularExpression(@"^[0-9]*$")]
        public string TEL { get; set; }

        [DisplayName("訊息")]
        public string MESSAGE { get; set; }
    }
}