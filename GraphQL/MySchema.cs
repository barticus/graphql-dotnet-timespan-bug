using GraphQL;
using GraphQL.Types;

namespace TimespanBug.GraphQL
{
    public class MySchema : Schema
    {
        public MySchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<MyQuery>();
            Mutation = resolver.Resolve<MyMutation>();
        }
    }
}