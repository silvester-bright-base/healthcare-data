using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using NpgsqlTypes;
using Silvester.BrightBase.Healthcare.Database.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Silvester.BrightBase.Healthcare.Api.Graphql.Interceptors
{
    public class DateOnlyInterceptor : TypeInterceptor
    {
        public override void OnBeforeCompleteType(ITypeCompletionContext context, DefinitionBase? definitionBase, IDictionary<string, object?> contextData)
        {
            if (definitionBase is not ObjectTypeDefinition definition)
            {
                return;
            }

            //TODO: Add support for navigation properties on 
            if (definition.RuntimeType.IsSubclassOf(typeof(BaseEntity)))
            {
                foreach (PropertyInfo property in definition.RuntimeType.GetProperties())
                {
                    if (property.PropertyType == typeof(DateOnly))
                    {
                        ObjectFieldDefinition fieldDefinition = definition.Fields.First(e => e.Name == context.DescriptorContext.Naming.GetMemberName(property, MemberKind.ObjectField));
                        ObjectFieldDescriptor fieldDescriptor = ObjectFieldDescriptor.From(context.DescriptorContext, fieldDefinition);

                        fieldDescriptor.Type(typeof(DateTime));

                        int index = definition.Fields.IndexOf(fieldDefinition);
                        definition.Fields.RemoveAt(index);
                        definition.Fields.Insert(index, fieldDescriptor.CreateDefinition());
                    }
                }
            }
        }
    }
}
