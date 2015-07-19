using System;

using Microsoft.AspNet.Mvc;
using Fancy.SchemaFormBuilder.Studio.Dtos;
using Fancy.SchemaFormBuilder.Studio.Compiling;
using Fancy.SchemaFormBuilder.Services;

using Newtonsoft.Json.Linq;

namespace Fancy.SchemaFormBuilder.Studio.Controllers
{
    public class FormsController : Controller
    {
        [HttpGet]
        [Route("api/[controller]/hallo")]
        public string Get()
        {
            return "Hallo";
        }
        [HttpPut]
        [Route("api/[controller]/code")]
        public object PutCodeToCompile([FromBody]JToken input)
        {
            CompiledFormDto result = new CompiledFormDto();
            CompileResultContainer compileResult = null;

            if(input["csharpCode"] == null)
            {
                result.ErrorMessages.Add("No Code!");
                return result;
            }
            
            try
            {
                compileResult = CompileService.TryCompileAndSearchType(input["csharpCode"].ToString());
                
                result.CompilationSuccessfull = compileResult.CompilationSuccessfull;
                result.TypeName = compileResult.TypeName;
                result.ErrorMessages = compileResult.ErrorMessages;
                
                if(compileResult.CompilationSuccessfull)
                {
                    DefaultSchemaFormBuilder builder = new DefaultSchemaFormBuilder();
                    SchemaFormInfo schemaFormInfo = builder.CreateSchemaForm(compileResult.Type);
                    result.Form = schemaFormInfo.Form;
                    result.Schema = schemaFormInfo.Schema;
                }
            }
            catch(Exception e)
            {
                result.ErrorMessages.Add(e.ToString());
            }
            finally
            {
                if (compileResult != null)
                {
                    compileResult.ReleaseResources();
                }
            }
            
            return result;
        }
    }
}