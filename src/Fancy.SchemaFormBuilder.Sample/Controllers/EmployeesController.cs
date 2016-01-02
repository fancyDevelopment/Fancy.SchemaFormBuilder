using System.Collections.Generic;
using System.Linq;

using Fancy.SchemaFormBuilder.Sample.ViewModels;
using Fancy.SchemaFormBuilder.Services;

using Microsoft.AspNet.Mvc;

namespace Fancy.SchemaFormBuilder.Sample.Controllers
{
    /// <summary>
    /// A controller to work with employee resources.
    /// </summary>
    public class EmployeesController : Controller
    {
        /// <summary>
        /// The schema form builder.
        /// </summary>
        private readonly ISchemaFormBuilder _schemaFormBuilder;

        /// <summary>
        /// A static list of employees. This simulates the database/persitance in this sample.
        /// </summary>
        private static readonly List<FullEmployeeVm> _employees = new List<FullEmployeeVm>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="schemaFormBuilder">The schema form builder.</param>
        public EmployeesController(ISchemaFormBuilder schemaFormBuilder)
        {
            _schemaFormBuilder = schemaFormBuilder;
        }

        /// <summary>
        /// Creates a new empty employee resource with metadata.
        /// </summary>
        /// <returns>An empty employee with metadata to render a form.</returns>
        [Route("[controller]/create")]
        public IActionResult Create()
        {
            // Create the metadata info for the type
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(FullEmployeeVm));

            // Create a response which contains the metadata and an empty resource
            return Json(new { schemaFormInfo.Form, schemaFormInfo.Schema, Data = new EditEmployeeVm() });
        }

        /// <summary>
        /// Loads the employee with specified identifier and adds metadata to it to edit it.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The employee for the specified id and the metadata to render a form to edit the employee.</returns>
        [Route("[controller]/{id}/edit")]
        [ResponseCache(NoStore = true)]
        public IActionResult Edit(int id)
        {
            // Find the employee to the specified id
            FullEmployeeVm employeeVm = _employees.SingleOrDefault(e => e.Id == id);

            if (employeeVm == null)
            {
                // The employee could not be found
                return HttpNotFound();
            }

            // Create the metadata info for the type
            SchemaFormInfo schemaFormInfo = _schemaFormBuilder.CreateSchemaForm(typeof(FullEmployeeVm));

            // Create a response which contains the metadata and the resource
            return Json(new { schemaFormInfo.Form, schemaFormInfo.Schema, Data = employeeVm.ToEditEmployeeVm() });
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>An array of all employees.</returns>
        [Route("[controller]")]
        [ResponseCache(NoStore = true)]
        public IActionResult GetAll()
        {
            return Json(_employees);
        }

        /// <summary>
        /// Gets an employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The employee with the specified identifier.</returns>
        [Route("[controller]/{id}")]
        public IActionResult GetById(int id)
        {
            FullEmployeeVm employee = _employees.SingleOrDefault(e => e.Id == id);

            if (employee != null)
            {
                return Json(employee);
            }
            
            // The employee could not be found
            return this.HttpNotFound();
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="editEmployeeVm">The edit employee vm.</param>
        /// <returns>The id of the created employee.</returns>
        [HttpPut]
        [Route("[controller]")]
        public IActionResult CreateNewEmployee([FromBody] EditEmployeeVm editEmployeeVm)
        {
            FullEmployeeVm newEmployee = new FullEmployeeVm();
            newEmployee.Id = _employees.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
            newEmployee.Update(editEmployeeVm);
            _employees.Add(newEmployee);
            return Json(newEmployee.Id);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The identifier of the employee to update.</param>
        /// <param name="editEmployeeVm">The edit employee vm.</param>
        /// <returns>The id of the updated employee.</returns>
        [HttpPost]
        [Route("[controller]/{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody] EditEmployeeVm editEmployeeVm)
        {
            FullEmployeeVm employee = _employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            employee.Update(editEmployeeVm);

            return Json(employee.Id);
        }
    }
}
