using GraphQL.Types;
using System;

namespace TimespanBug.GraphQL
{
    public class ItemInput
    {
        public TimeSpan TimeSpanField { get; set; }

        public int IntField { get; set; }
    }

    public class ItemInputType : InputObjectGraphType<ItemInput>
    {
        public ItemInputType()
        {
            Name = "ItemInputType";

            Field(d => d.TimeSpanField, nullable: false)
                .Description("The timespan field.");

            Field(d => d.IntField, nullable: false)
                .Description("The int field.");
        }
    }
}