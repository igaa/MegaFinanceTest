﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web.Mega.Finance.Models
{
    public partial class ms_user
    {
        [Key]
        public long user_id { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string user_name { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string password { get; set; }
        public bool? is_active { get; set; }
    }
}