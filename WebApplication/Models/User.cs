﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
        
       
        public int Id { get; set; }
        public string Name { get; set; }

        public string MatricNo { get; set; }

        public virtual Grade Grade { get; set; }

    }
}