using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Studio.Dtos
{
    // Simple example dto representing a comment
    public class CompiledFormDto
    {
        public CompiledFormDto()
        {
            ErrorMessages = new List<string>();
        }
        
        public string TypeName { get; set; }

        public bool CompilationSuccessfull { get; set; }

        public List<string> ErrorMessages { get; set; }
        
        public JContainer Form { get; set; }
        
        public JContainer Schema { get; set; }
    }
}