using System;

namespace TimespanBug.Store
{
    public class Item
    {
        public TimeSpan TimeSpanField { get; set; }

        public int IntField { get; set; }
    }

    public class ItemStore
    {
        public Item CurrentItem { get; set; } = new Item
        {
            IntField = 1000,
            TimeSpanField = new TimeSpan(8, 30, 0)
        };
    }
}