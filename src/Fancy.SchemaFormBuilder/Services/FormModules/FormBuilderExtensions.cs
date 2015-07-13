namespace Fancy.SchemaFormBuilder.Services.FormModules
{
    /// <summary>
    /// Extension methods to conveniently configure the form builder pipeline.
    /// </summary>
    public static class FormBuilderExtensions
    {
        /// <summary>
        /// Adds the title key module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseTitleKeyModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new TitleKeyFormModule());
        }

        /// <summary>
        /// Adds the section module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseSectionModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new SectionFormModule());
        }

        /// <summary>
        /// Adds the help module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseHelpModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new HelpFormModule());
        }

        /// <summary>
        /// Adds the text form module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseTextFormModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new TextFormModule());
        }

        /// <summary>
        /// Adds the sub object module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseSubObjectModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new SubObjectFormModule());
        }

        /// <summary>
        /// Adds the enumeration title map module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseEnumTitleMapModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new EnumTitleMapFormModule());
        }

        /// <summary>
        /// Adds the display module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseDisplayModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new DisplayFormModule());
        }

        /// <summary>
        /// Adds the simple choice module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseSimpleChoiceModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new SimpleChoiceTitleMapFormModule());
        }

        /// <summary>
        /// Adds the bool as title map module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseBoolAsTitleMapModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new BoolAsRadiosFormModule());
        }

        /// <summary>
        /// Uses the array module.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseArrayModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new ArrayFormModule());
        }

        /// <summary>
        /// Adds the condition module to the pipeline.
        /// </summary>
        /// <param name="formBuilder">The form builder.</param>
        public static void UseConditionModule(this FormBuilder formBuilder)
        {
            formBuilder.AddPipelineModule(new ConditionFormModule());
        }
    }
}
