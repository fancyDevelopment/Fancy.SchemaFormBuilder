using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Fancy.SchemaFormBuilder.Annotations;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Builds up sections for the form.
    /// </summary>
    public class SectionFormModule : IFormBuilderModule
    {
        /// <summary>
        /// The hierarchy path property name, used to navigate through the form hierarchies
        /// </summary>
        private const string HierarchyPathPropertyName = "hierarchyPath";

        /// <summary>
        /// Processes the specified context.
        /// </summary>
        /// <param name="context">The context to process.</param>
        public void Process(FormBuilderContext context)
        {
            // Get all form hierarchy attributes
            List<FormSectionAttribute> formHierarchies = context.Property.GetCustomAttributes<FormSectionAttribute>().ToList();

            // If the current property has no form hierarchy elements this module has nothing to to
            if (!formHierarchies.Any())
            {
                return;
            }

            JObject hierachyObject = null;

            foreach (FormSectionAttribute formHierarchy in formHierarchies)
            {
                // Is the hierarchy already in the form?
                hierachyObject = FindFormHierarchyObject(context.CompleteForm, formHierarchy.HierarchyPath, true);

                UpdateFormHierarchyObject(hierachyObject, formHierarchy);
            }

            // ReSharper disable once PossibleNullReferenceException because we make sure to have at least one object in the hierarcy
            JArray hierarcyItems = (JArray)hierachyObject["items"];

            if (context.CurrentFormElement != null)
            {
                // Move the current element into the form hierarcy
                hierarcyItems.Add(context.CurrentFormElement);
                context.CurrentFormElementParent.Remove(context.CurrentFormElement);
            }

            // Set the new parent element to the current hierarchy
            context.CurrentFormElementParent = hierarcyItems;
        }

        /// <summary>
        /// Updates a form hierarchy object.
        /// </summary>
        /// <param name="hierarchyObject">The hierarchy object.</param>
        /// <param name="formSection">The form section.</param>
        public void UpdateFormHierarchyObject(JObject hierarchyObject, FormSectionAttribute formSection)
        {
            hierarchyObject["type"] = ConvertSectionType(formSection.SectionType);

            if (!string.IsNullOrEmpty(formSection.Title))
            {
                hierarchyObject["title"] = formSection.Title;
            }
        }

        /// <summary>
        /// Finds the form hierarchy object.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="hierarchyPath">The hierarchy path.</param>
        /// <param name="createIfNotExists">if set to <c>true</c> [create if not exists].</param>
        /// <returns>The JSON token representing the hierarchy object or null if not found and shall not be created.</returns>
        public JObject FindFormHierarchyObject(JArray form, string hierarchyPath, bool createIfNotExists)
        {
            if (string.IsNullOrEmpty(hierarchyPath))
            {
                throw new ArgumentException("Hierarchy path may not be null or empty");
            }

            string[] hierarchyLayers = hierarchyPath.Split('.');

            JArray currentLayerItems = form;
            JObject currentLayer = null;

            foreach (string hierarchyLayer in hierarchyLayers)
            {
                // Try to find an object matching the current hierarchy layer
                JObject searchedLayer = (JObject)currentLayerItems.SingleOrDefault(e => e.Value<string>(HierarchyPathPropertyName) == hierarchyLayer);

                if (searchedLayer == null && createIfNotExists)
                {
                    // Create a new layer object for this hierarchy and add it to the form
                    searchedLayer = this.CreateDefaultHierarchyLayerObject(hierarchyLayer);
                    currentLayerItems.Add(searchedLayer);
                }
                else if (searchedLayer == null)
                {
                    // The searched hierarchy layer was not found
                    currentLayer = null;
                    break;
                }

                currentLayer = searchedLayer;
                currentLayerItems = (JArray)searchedLayer["items"];
            }

            return currentLayer;
        }

        /// <summary>
        /// Creates a new hierarchy layer object with default settings.
        /// </summary>
        /// <param name="hierarchyPath">The hierarchy path.</param>
        /// <returns>
        /// A form hierarchy object.
        /// </returns>
        public JObject CreateDefaultHierarchyLayerObject(string hierarchyPath)
        {
            JObject newFormHierarchyLayer = new JObject();

            newFormHierarchyLayer["type"] = "section";
            newFormHierarchyLayer[HierarchyPathPropertyName] = hierarchyPath;
            newFormHierarchyLayer["items"] = new JArray();

            return newFormHierarchyLayer;
        }

        /// <summary>
        /// Converts the type of the section to a string.
        /// </summary>
        /// <param name="sectionType">Type of the section.</param>
        /// <returns>The section type as string.</returns>
        private string ConvertSectionType(SectionType sectionType)
        {
            switch (sectionType)
            {
                case SectionType.Fieldset:
                    return "fieldset";
                default:
                    return "section";
            }
        }
    }
}
