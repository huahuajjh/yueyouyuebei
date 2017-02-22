using System;

namespace TravelAgent.Model
{
    public class VOrder
    {
        public string Url { get; set; }
        public int OrderAmount { get; set; }
        public string ProductName { get; set; }
        public string OrderTime { get; set; }
        public string OrderNo { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }
        public int StatusNo { get; set; }
        public int UserId { get; set; }
    }
}
