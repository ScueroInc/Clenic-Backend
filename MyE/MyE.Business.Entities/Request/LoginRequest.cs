﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyE.Business.Entities.Response
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "username")]
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "password")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}
