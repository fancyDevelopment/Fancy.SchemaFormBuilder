using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.SchemaFormBuilder.Sample.ViewModels
{
    /// <summary>
    /// A view model for employees with properties which can be edited by the user.
    /// </summary>
    public class EditEmployeeVm
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [FormTitle("First Name")]
        [FormRequired]
        [FormSection("Name")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [FormTitle("Last Name")]
        [FormRequired]
        [FormSection("Name")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        /// <value>
        /// The e mail.
        /// </value>
        [FormTitle("E-Mail")]
        [FormSection("ContactData", SectionType = SectionType.Fieldset, Title = "Contact Data")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [FormTitle("Phone")]
        [FormSection("ContactData")]
        [FormDisplay(DisplayWidth = DisplayWidth.Quarter)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        [FormTitle("Mobile")]
        [FormSection("ContactData")]
        [FormDisplay(DisplayWidth = DisplayWidth.Quarter)]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [FormTitle("Street")]
        [FormSection("Address", SectionType = SectionType.Fieldset, Title = "Address")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street nr.
        /// </summary>
        /// <value>
        /// The street nr.
        /// </value>
        [FormTitle("Street Number")]
        [FormSection("Address")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string StreetNr { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [FormTitle("Zip Code")]
        [FormSection("Address")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [FormTitle("City")]
        [FormSection("Address")]
        [FormDisplay(DisplayWidth = DisplayWidth.Half)]
        public string City { get; set; }
    }
}
