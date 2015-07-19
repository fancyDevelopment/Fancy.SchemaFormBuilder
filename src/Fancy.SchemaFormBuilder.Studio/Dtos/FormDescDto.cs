using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Studio.Dtos
{
    // Simple example dto representing a comment
    public class FormDescDto
    {
        public JContainer Form { get; set; }
        
        public JContainer Schema { get; set; }
        
        public JContainer Model { get; set; }
    }
}