using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Models
{
    public enum OrderStatuses
    {
        New,
        Accepted,
        InService,
        AfterService,
        Ready,
        Sent,
        Received
    }
}
