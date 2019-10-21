using GraphQL.Types;
using TimespanBug.Store;

namespace TimespanBug.GraphQL
{

    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Name = "Item";

            Field(d => d.TimeSpanField, nullable: false)
                .Description("The timespan field.");

            Field(d => d.IntField, nullable: false)
                .Description("The int field.");
        }
    }
}