using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XamrinEfCoreApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string UserPassword { get; set; }
    }
}
