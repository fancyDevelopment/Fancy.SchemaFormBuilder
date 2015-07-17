using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.SchemaModules
{
    /// <summary>
    /// Adds the type to the schema element.
    /// </summary>
    public class TypeSchemaModule : ISchemaBuilderModule
    {
        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(SchemaBuilderContext context)
        {
            Type propertyType = DeterminePropertyType(context);

            string schemaType = DetermineSimpleSchemaType(propertyType);

            if (schemaType != null)
            {
                JObject currentSchemaObject = context.Element.GetOrCreateSchemaObject();

                // If the schema was found create the type element to the context
                currentSchemaObject["type"] = schemaType;

                if (propertyType.GetTypeInfo().IsEnum)
                {
                    // If the property type is an enumeration then additionally to the type we have to set the enum property
                    FieldInfo[] enumMembers = propertyType.GetFields(BindingFlags.Public | BindingFlags.Static);

                    JArray enumItemsArray = new JArray();

                    foreach (FieldInfo enumMember in enumMembers)
                    {
                        enumItemsArray.Add(Convert.ChangeType(enumMember.GetValue(null), typeof(int)));
                    }

                    currentSchemaObject["enum"] = enumItemsArray;
                }
            }
        }

        /// <summary>
        /// Determines the type of the property.
        /// </summary>
        /// <param name="context">The context to determine the type from.</param>
        /// <returns>The type of the property.</returns>
        private static Type DeterminePropertyType(SchemaBuilderContext context)
        {
            // Get the type of the property to build a schema for
            Type propertyType = context.Property.PropertyType;

            if (propertyType.GetTypeInfo().IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // If the property type is a nullable type get the underlying type
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }

            return propertyType;
        }

        /// <summary>
        /// Determines the type of the schema if the type is a simple type.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns>The schema type name of the property.</returns>
        private static string DetermineSimpleSchemaType(Type propertyType)
        {
            string schemaType = null;

            if (propertyType.GetTypeInfo().IsPrimitive)
            {
                // If the current property is a primitive type then add the "type" there are three cases
                if (propertyType == typeof(bool))
                {
                    // Boolenas are boolean
                    schemaType = "boolean";
                }
                else if (propertyType == typeof(float) || propertyType == typeof(double))
                {
                    // Doubles and singles are number
                    schemaType = "number";
                }
                else
                {
                    // Everything else like Byte, SByte, Int16, UInt16, etc. are numbers.
                    schemaType = "integer";
                }
            }
            else if (propertyType.GetTypeInfo().IsEnum)
            {
                // For enums we use the number of the enumeration element
                schemaType = "number";
            }
            else if (propertyType == typeof(string))
            {
                // Strings are strings
                schemaType = "string";
            }

            return schemaType;
        }
    }
}
