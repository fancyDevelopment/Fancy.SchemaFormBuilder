using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fancy.SchemaFormBuilder.Annotations;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Adds an array to the schema.
    /// </summary>
    public class ArraySchemaModule : SchmeaModuleBase
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public override void Process(SchemaBuilderContext context)
        {
            FormArrayAttribute arrayAttribute = context.Property.GetCustomAttribute<FormArrayAttribute>();

            if (arrayAttribute != null)
            {
                JObject currentSchemaObject = context.Element.GetOrCreateSchemaObject();

                if (context.Property.PropertyType.GetInterfaces()
                    .Where(i => i.GetTypeInfo().IsGenericType)
                    .Select(i => i.GetGenericTypeDefinition()).Any(i => i == typeof (IEnumerable<>)))
                {
                    // The property is an generic enumerable type
                    Type underlyingType = context.Property.PropertyType.GetGenericArguments()[0];

                    // Build the schema for a complext type
                    JObject complexSchema = context.SchemaBuilder.BuildSchema(underlyingType, context.OriginDtoType, context.TargetCulture);

                    currentSchemaObject["title"] = new JValue(context.Property.Name);
                    currentSchemaObject["type"] = new JValue("array");
                    currentSchemaObject["items"] = complexSchema;

                    // Add minItems constraint if available
                    if (arrayAttribute.MinItems > 0)
                    {
                        currentSchemaObject["minItems"] = new JValue(arrayAttribute.MinItems);
                    }

                    // Add maxItems constraint if available
                    if (arrayAttribute.MaxItems > 0)
                    {
                        currentSchemaObject["maxItems"] = new JValue(arrayAttribute.MaxItems);
                    }
                }
                else
                {
                    throw new InvalidOperationException("The FormArray attibute may be used only on properties using types implementing IEnumerable<>.");
                }
            }

        }
    }
}