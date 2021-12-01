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
