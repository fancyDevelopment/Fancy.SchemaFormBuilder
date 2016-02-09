# Fancy.SchemaFormBuilder
Create HTML forms from you .NET DTOs the easy way!

## What is it
Fancy.SchemaFormBuilder is a library to generate a JSON schema and a declarative form description (also in JSON) from your data transfer objects written
in .NET. You can then feed this two items into the very popular open source JavaScript library Angular Schema Form. This library then renders a form in 
HTML into the browser. The combination of Angular Schema Form and Fancy.SchemaFormBuilder makes it super easy for .NET developers to create very rich web 
forms without having to write any html form specific code (apart from the single line in your HTML markup you need to call the Angular Schema Form library).

## Walkthrough
For a base introduction on how to use the library have a look at [this blog post](http://www.fancy-development.net/how-to-create-nice-interactive-html-5-forms-the-easy-way)

For a better understanding you should have a base knowledge of the [angular-schema-form](https://github.com/Textalk/angular-schema-form) project.

Also have a look at the [Sample Application](https://github.com/fancyDevelopment/Fancy.SchemaFormBuilder/tree/master/src/Fancy.SchemaFormBuilder.Sample) which shows you a complete end to end example on how to use the library based on ASP.NET Core.

## Live Editor
Try out [Schema Form Builder Studio](http://fancydevelopment-schemaformbuilderstudio.azurewebsites.net "Schema Form Builder Studio") for live examples and use it to 
design your DTOs.
