using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

namespace Fancy.SchemaFormBuilder.Studio.Controllers
{   
    public class ExamplesController : Controller
    {
        private const string ExamplesNamespace = "Fancy.SchemaFormBuilder.Studio.Resources.FormExamples";
        
        [HttpGet]
        [Route("api/[controller]")]
        public List<string> GetExampleNames()
        {
            // Find all resources
            List<string> examples = Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList();
            
            // Filter resources to form examples
            examples = examples.Where(e => e.StartsWith(ExamplesNamespace)).ToList();
            
            List<string> result = new List<string>();
            
            // Get title for each example
            foreach(string example in examples)
            {
                result.Add(example.Substring(ExamplesNamespace.Length + 1, example.Length - (ExamplesNamespace.Length + 4)));
            }
            
            return result;
        }
        
        [HttpGet]
        [Route("api/[controller]/{exampleName}")]
        public string GetExammple(string exampleName)
        {
            using(Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ExamplesNamespace + "." + exampleName + ".cs"))
            {
                StreamReader reader = new StreamReader(resourceStream);
                
                return reader.ReadToEnd();
            }
        }
    }
}