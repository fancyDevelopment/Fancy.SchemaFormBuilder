using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Studio.Dtos
{
    // Simple example dto representing a comment
    public class CommentWithHierarchyDto
    {
        public int Id { get; set; }

        [FormSection("Name", SectionType = SectionType.Fieldset, Title = "Contact Data")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        [FormTitle("FirstName")]
        public string FirstName { get; set; }
        
        [FormSection("Name")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        [FormTitle("LastName")]
        public string LastName { get; set; }
        
        [FormSection("Name")]
        [FormTitle("E-Mail")]
        public string EMail { get; set; }
        
        [FormSection("Comment", SectionType = SectionType.Fieldset, Title = "Comment")]
        [FormTitle("Send comment also to my E-Mail address")]
        public bool SendCommentToMyEMail { get; set; }
        
        [FormSection("Comment")]
        [FormTitle("Comment")]
        public string Comment { get; set; }
    }
}