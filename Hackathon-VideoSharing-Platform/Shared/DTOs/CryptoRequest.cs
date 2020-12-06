using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.VideoSharing.Platform.Shared.DTOs
{
    public class CryptoRequest
    {
        public string Password { get; set; }
        public string Data64 { get; set; }
    }
}
