﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.Common.Entities
{
    public class SignalRMessage

    {
        public string Message { get; set; }
        public string FromUser { get; set; }
        public string ConnectionId { get; set; }

    }
}
