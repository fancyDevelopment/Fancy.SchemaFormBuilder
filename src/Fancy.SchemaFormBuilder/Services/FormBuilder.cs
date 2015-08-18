using System;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Fancy.SchemaFormBuilder.Services
{
    /// <summary>
    /// Implements the <see cref="IFormBuilder"/> interface.
    /// </summary>
    public class FormBuilder : IFormBuilder
    {
        /// <summary>
        /// The pipeline modules.
        /// </summary>
        private readonly List<IFormBuilderModule> _pipelineModules;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormBuilder"/> class.
        /// </summary>
        public FormBuilder()
        {
            _pipelineModules = new List<IFormBuilderModule>();
        }

        /// <summary>
        /// Builds the form.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// A description of the form in JSON.
        /// </returns>
        public JContainer BuildForm(Type type, CultureInfo cultureInfo)
        {
            return BuildForm(type, cultureInfo, string.Empty);
        }

        /// <summary>
        /// Builds a form starting from a specified property path.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="sourcePropertyPath">The source property path to use as start.</param>
        /// <returns>
        /// A description of the form in JSON
        /// </returns>
        public JContainer BuildForm(Type type, CultureInfo cultureInfo, string sourcePropertyPath)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();

            JArray formElements = new JArray();

            // Run through each property of the type
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                formElements = ProcessProperty(type, propertyInfo, formElements, sourcePropertyPath, cultureInfo);
            }

            return formElements;
        }

        /// <summary>
        /// Adds a module to the pipeline.
        /// </summary>
        /// <param name="module">The module.</param>
        public void AddPipelineModule(IFormBuilderModule module)
        {
            _pipelineModules.Add(module);
        }

        /// <summary>
        /// Processes a property through the pipeline modules.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="formElements">The form elements.</param>
        /// <param name="sourcePropertyPath">The source property path to use as start.</param>
        /// <returns>
        /// The form element.
        /// </returns>
        private JArray ProcessProperty(Type objectType, PropertyInfo propertyInfo, JArray formElements, string sourcePropertyPath, CultureInfo cultureInfo)
        {
            // Create the context for this property
            FormBuilderContext context = new FormBuilderContext();
            context.DtoType = objectType;
            context.Property = propertyInfo;
            context.CompleteForm = formElements;
            context.CurrentFormElementParent = formElements;
            context.FormBuilder = this;
            context.TargetCulture = cultureInfo;

            // Set up the full property path to this property
            context.FullPropertyPath = string.IsNullOrEmpty(sourcePropertyPath)
                                           ? propertyInfo.Name
                                           : sourcePropertyPath + "." + propertyInfo.Name;

            // Run the property through each pipeline module
            foreach (IFormBuilderModule builderModule in this._pipelineModules)
            {
                builderModule.Process(context);

                if (context.FinishProcessing)
                {
                    // Stop the pipeline to run the next module
                    break;
                }
            }

            return context.CompleteForm;
        }
    }
}