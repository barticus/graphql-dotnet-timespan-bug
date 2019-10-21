using GraphQL.Types;
using TimespanBug.Store;

namespace TimespanBug.GraphQL
{
    public class MyMutation : ObjectGraphType<object>
    {

        public MyMutation(ItemStore store)
        {
            Name = "Mutation";

            Field<ItemType>(
                "setItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<ItemInput>("input");

                    store.CurrentItem = new Item {
                        IntField = input.IntField,
                        TimeSpanField = input.TimeSpanField
                    };

                    return store.CurrentItem;
                });
        }
    }
}