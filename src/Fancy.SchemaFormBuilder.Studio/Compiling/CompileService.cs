using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Studio.Compiling
{
	public static class CompileService
    {
        /// <summary>
        /// Determines the first class name in the snippet.
        /// </summary>
        /// <param name="code">The code to search.</param>
        /// <returns>The found class name</returns>
        private static string DetermineFirstClassName(string code)
        {
            Regex regex = new Regex("class[\\s\\r\\n]+(?<className>.*)[\\s\\r\\n]+");

            Match match = regex.Match(code);

            if (match.Groups.Count != 2)
            {
                return null;
            }

            string className = match.Groups[1].ToString().Trim();

            return className;
        }

        /// <summary>
        /// Tries to compile a snippet of code and search a type in it.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="type">The type.</param>
        /// <returns>A compile result.</returns>
        public static CompileResultContainer TryCompileAndSearchType(string code)
        {
            CompileResultContainer compileResult = new CompileResultContainer();

            string typeName = DetermineFirstClassName(code);

            if (string.IsNullOrEmpty(typeName))
            {
                compileResult.ErrorMessages.Add("Could not determine a class name from given snippet.");
            }

            // Create the syntax tree
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText("\n" + code);

            // Set up references to required assemblies, here we use mscorelib, System and of cource Fancy.SchemaFormBuilder
            MetadataReference[] references = {
                                                 MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                                                 MetadataReference.CreateFromFile(typeof(IEnumerable).Assembly.Location),
                                                 MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location),
                                                 MetadataReference.CreateFromFile(typeof(FormDisplayAttribute).Assembly.Location)
                                             };

            string assemblyName = Guid.NewGuid().ToString();

            // Create compilation object
            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName, new[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                // Emit code
                EmitResult emitResult = compilation.Emit(ms);

                if (!emitResult.Success)
                {
                    IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        compileResult.ErrorMessages.Add(string.Format("Error {0}: {1} - Line:{2}", diagnostic.Id, diagnostic.GetMessage(), diagnostic.Location.GetLineSpan().StartLinePosition));
                    }
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    byte[] assemblyBuffer = ms.ToArray();

                    compileResult.LoadAssemblyAndType(assemblyBuffer, typeName, assemblyName);
                }
            }

            return compileResult;
        }
    }
}