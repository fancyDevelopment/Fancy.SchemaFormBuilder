using System;

using AutoMapper;

namespace Fancy.SchemaFormBuilder.Sample.ViewModels
{
    /// <summary>
    /// A view model with properties which contains all properties (also properties which can not be modified by the user) of an employee.
    /// </summary>
    public class FullEmployeeVm : EditEmployeeVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullEmployeeVm"/> class.
        /// </summary>
        public FullEmployeeVm()
        {
            Created = DateTimeOffset.Now;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>
        /// The last modified.
        /// </value>
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// Updates this instance with the properties from an <see cref="EditEmployeeVm"/>.
        /// </summary>
        /// <param name="editEmployee">The edit employee view model to read from.</param>
        public void Update(EditEmployeeVm editEmployee)
        {
            Mapper.Map(editEmployee, this);
            LastModified = DateTimeOffset.Now;
        }

        /// <summary>
        /// Converts this instance to an <see cref="EditEmployeeVm"/>.
        /// </summary>
        /// <returns>An edit employee view model.</returns>
        public EditEmployeeVm ToEditEmployeeVm()
        {
            return Mapper.Map<EditEmployeeVm>(this);
        }
    }
}
