using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Attribute to identify required properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormRequiredAttribute : FormAttribute
    {
    }
}
