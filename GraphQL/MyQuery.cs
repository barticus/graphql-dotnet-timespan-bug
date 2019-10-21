using GraphQL.Types;
using TimespanBug.Store;

namespace TimespanBug.GraphQL
{
    public class MyQuery : ObjectGraphType<object>
    {
        public MyQuery(ItemStore store)
        {
            Name = "Query";

            Field<ItemType>(
                "getItem",
                resolve: context => store.CurrentItem);
        }
    }
}