using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Auth
{
    public class JwtBeaererAuthSetting
    {
        public bool IsEnabled { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
