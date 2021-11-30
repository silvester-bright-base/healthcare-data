using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Data.Projections.Expressions;
using HotChocolate.Data.Sorting.Expressions;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Silvester.BrightBase.Healthcare.Database;
using Silvester.BrightBase.Healthcare.Database.Models;
using Silvester.BrightBase.Healthcare.Database.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Silvester.BrightBase.Healthcare.Api.Graphql
{
    public class DateOnlyType : ScalarType<DateOnly, StringValueNode>
    {
        public DateOnlyType() 
            : base(new NameString("DateOnly"), BindingBehavior.Explicit)
        {
            Description = "A date without a time component.";
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return resultValue switch
            {
                null => NullValueNode.Default,
                string s => new StringValueNode(s),
                DateTimeOffset d => ParseValue(d),
                DateTime d => ParseValue(d),
                DateOnly d => ParseValue(d),
                _ => throw new InvalidOperationException()
            };
        }

        protected override DateOnly ParseLiteral(StringValueNode valueSyntax)
        {
            return DateOnly.Parse(valueSyntax.Value);
        }

        protected override StringValueNode ParseValue(DateOnly runtimeValue)
        {
            return new StringValueNode(runtimeValue.ToString());
        }

        public override bool TryDeserialize(object? resultValue, out object? runtimeValue)
        {
            runtimeValue = null;

            if (resultValue is string s)
            {
                runtimeValue = DateOnly.Parse(s);
                return true;
            }

            return false;
        }

        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            resultValue = null;

            if (runtimeValue is DateOnly date)
            {
                resultValue = date.ToString();
                return true;
            }

            return false;
        }
    }

    public partial class Query
    {
       
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            foreach (PropertyInfo property in typeof(HealthcareContext).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.IsAssignableTo(typeof(DbSet<>)) || property.PropertyType.IsGenericType == false)
                {
                    continue;
                }

                Type genericType = property.PropertyType.GetGenericArguments().First();
                if (genericType.IsAssignableTo(typeof(BaseEntity)) == false)
                {
                    continue;
                }

                string fieldName = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);

                IObjectFieldDescriptor field = descriptor
                   .Field(fieldName)
                   .Type(genericType)
                   .UseDbContext<HealthcareContext>()
                   .UseOffsetPaging(typeof(ObjectType<>).MakeGenericType(genericType))
                   .UseProjection(genericType)
                   .UseFiltering(genericType)
                   .UseSorting(genericType)
                   .Resolve((context) =>
                   {
                       HealthcareContext database = context.Resolver<HealthcareContext>();
                       return property.GetValue(database);
                   });
            }
        }
    }
}
