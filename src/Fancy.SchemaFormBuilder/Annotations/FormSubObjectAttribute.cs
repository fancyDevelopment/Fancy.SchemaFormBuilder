using System;

namespace Fancy.SchemaFormBuilder.Annotations
{
    /// <summary>
    /// Specifies that the current property contains a object which shall also be included in the form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormSubObjectAttribute : FormAttribute
    {
    }
}
