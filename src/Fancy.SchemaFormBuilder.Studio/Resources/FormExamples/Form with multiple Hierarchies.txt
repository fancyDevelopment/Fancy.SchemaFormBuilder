using Fancy.SchemaFormBuilder.Annotations;

public class CustomerDto
{
    public int Id { get; set; }

    [FormSection("Name")]
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("FirstName")]
    public string FirstName { get; set; }
    
    [FormSection("Name")]
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("LastName")]
    public string LastName { get; set; }
    
    [FormSection("ContactData", SectionType = SectionType.Fieldset, Title = "Contact Data")]
    [FormTitle("E-Mail")]
    public string EMail { get; set; }
    
    [FormSection("ContactData.Address", SectionType = SectionType.Fieldset, Title = "Address")]
    [FormSubObject]
    public AddressDto Address { get; set; }
}

public class AddressDto
{
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("Street")]
    public string Street { get; set; }
    
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("Street Number")]
    public string StreetNumber { get; set; }
    
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("Zip Code")]
    public string ZipCode { get; set; }
    
    [FormDisplay(DisplayWidth = DisplayWidth.Half)]
    [FormTitle("City")]
    public string City { get; set; }
}