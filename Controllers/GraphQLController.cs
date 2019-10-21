using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GraphQL.Validation;
using System.Linq;
using TimespanBug.Models;

namespace TimespanBug.Controllers
{

    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private IDocumentExecuter DocumentExecuter { get; }
        private ISchema Schema { get; }
        private List<IValidationRule> ValidationRules { get; }

        public GraphQLController(
            ISchema schema,
            IDocumentExecuter documentExecuter,
            IEnumerable<IValidationRule> validationRules)
        {
            Schema = schema;
            DocumentExecuter = documentExecuter;
            ValidationRules = validationRules.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions
            {
                Schema = Schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs(),
                ExposeExceptions = true,
                ValidationRules = DocumentValidator.CoreRules().Concat(ValidationRules)
            };

            var result = await DocumentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            return Ok(result);
        }
    }
}