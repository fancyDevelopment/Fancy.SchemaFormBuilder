using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fancy.SchemaFormBuilder.Studio.Compiling
{
	public class CompileResultContainer
    {
        public CompileResultContainer()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; set; }

        public bool CompilationSuccessfull { get; private set; }

        public string TypeName { get; private set; }

        public byte[] AssemblyBuffer { get; private set; }

        public Type Type { get; private set; }

        public string AssemblyName { get; private set; }

        public Assembly Assembly { get; private set; }

        public AppDomain AppDomain { get; private set; }

        public void LoadAssemblyAndType(byte[] assemblyBuffer, string typeName, string assemblyName)
        {
            AssemblyBuffer = assemblyBuffer;
            TypeName = typeName;
            AssemblyName = assemblyName;

            // Create a new app domain for the assembly
            AppDomainSetup appDomainSetup = new AppDomainSetup();

            appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            appDomainSetup.PrivateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;

            AppDomain domain = AppDomain.CreateDomain("TempAssembly", null, appDomainSetup);

            // Set up a delegate to load the assembly reference into the current app domain
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;

            AppDomain = domain;
            Assembly = domain.Load(AssemblyBuffer);
            Type = Assembly.GetType(typeName);

            CompilationSuccessfull = true;
        }

        /// <summary>
        /// Releases the resources.
        /// </summary>
        public void ReleaseResources()
        {
            if(CompilationSuccessfull)
            {
                // Remove event handler
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomainOnAssemblyResolve;
                AppDomain.Unload(AppDomain);
                GC.Collect(1, GCCollectionMode.Optimized);
            }
        }

        private Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Extract filename from assembly name
            if (args.Name.Split(',')[0] == AssemblyName)
            {
                return Assembly.Load(AssemblyBuffer);
            }

            return null;
        }
    }
}