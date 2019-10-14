using System.Collections.Generic;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    // 2019-10-12 as of now, forms not implemented or supported
    // will take a few hours to implement and really test all variations, so lower priority
    internal class TagsForms : TagsBase
    {
        internal override string GroupName => "Forms";

        /// <inheritdoc />
        public override List<TagCodeGenerator> List => SpecialConfigs;

        // ReSharper disable StringLiteralTypo
        public static List<TagCodeGenerator> SpecialConfigs = new List<TagCodeGenerator>
        {
            // https://www.w3schools.com/tags/tag_form.asp
            new TagCodeGenerator("form")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("accept-charset",
                        help: "Specifies the character encodings that are to be used for the form submission"),
                    new AttributeCodeGen("action",
                        help: "Specifies where to send the form-data when a form is submitted"),
                    new AttributeCodeGen("autocomplete",
                        help: "Specifies whether a form should have autocomplete on or off"),

                    new AttributeCodeGen("enctype",
                        help:
                        "Specifies how the form-data should be encoded when submitting it to the server (only for method=\"post\")"),

                    new AttributeCodeGen("method", help: "Specifies the HTTP method to use when sending form-data"),

                    new AttributeCodeGen("name", help: "Specifies the name of a form"),
                    new AttributeCodeGen("novalidate",
                        help: "Specifies that the form should not be validated when submitted"),
                    new AttributeCodeGen("target",
                        help: "Specifies where to display the response that is received after submitting the form"),

                },
            },


            // https://www.w3schools.com/tags/tag_input.asp

            new TagCodeGenerator("input")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("accept",
                        help:
                        "Specifies a filter for what file types the user can pick from the file input dialog box (only for type=\"file\")"),

                    new AttributeCodeGen("alt",
                        help: "Specifies an alternate text for images (only for type=\"image\")"),
                    new AttributeCodeGen("autocomplete",
                        help: "Specifies whether an <input> element should have autocomplete enabled"),

                    new AttributeCodeGen("autofocus",
                        help: "Specifies that an <input> element should automatically get focus when the page loads"),
                    new AttributeCodeGen("checked",
                        help:
                        "Specifies that an <input> element should be pre-selected when the page loads (for type=\"checkbox\" or type=\"radio\")"),
                    new AttributeCodeGen("dirname", help: "Specifies that the text direction will be submitted"),
                    new AttributeCodeGen("disabled", help: "Specifies that an <input> element should be disabled"),
                    new AttributeCodeGen("form", help: "Specifies the form the <input> element belongs to"),
                    new AttributeCodeGen("formaction",
                        help:
                        "Specifies the URL of the file that will process the input control when the form is submitted (for type=\"submit\" and type=\"image\")"),
                    new AttributeCodeGen("formenctype",
                        help:
                        "Specifies how the form-data should be encoded when submitting it to the server (for type=\"submit\" and type=\"image\")"),


                    new AttributeCodeGen("formmethod",
                        help:
                        "Defines the HTTP method for sending data to the action URL (for type=\"submit\" and type=\"image\")"),

                    new AttributeCodeGen("formnovalidate",
                        help: "Defines that form elements should not be validated when submitted"),
                    new AttributeCodeGen("formtarget",
                        help:
                        "Specifies where to display the response that is received after submitting the form (for type=\"submit\" and type=\"image\")"),




                    new AttributeCodeGen("height",
                        help: "Specifies the height of an <input> element (only for type=\"image\")"),
                    new AttributeCodeGen("list",
                        help:
                        "Refers to a <datalist> element that contains pre-defined options for an <input> element"),
                    new AttributeCodeGen("max", help: "Specifies the maximum value for an <input> element"),

                    new AttributeCodeGen("maxlength",
                        help: "Specifies the maximum number of characters allowed in an <input> element"),
                    new AttributeCodeGen("min", help: "Specifies a minimum value for an <input> element"),

                    new AttributeCodeGen("multiple",
                        help: "Specifies that a user can enter more than one value in an <input> element"),
                    new AttributeCodeGen("name", help: "Specifies the name of an <input> element"),
                    new AttributeCodeGen("pattern",
                        help: "Specifies a regular expression that an <input> element's value is checked against"),
                    new AttributeCodeGen("placeholder",
                        help: "Specifies a short hint that describes the expected value of an <input> element"),
                    new AttributeCodeGen("readonly", help: "Specifies that an input field is read-only"),
                    new AttributeCodeGen("required",
                        help: "Specifies that an input field must be filled out before submitting the form"),
                    new AttributeCodeGen("size", help: "Specifies the width, in characters, of an <input> element"),
                    new AttributeCodeGen("src",
                        help: "Specifies the URL of the image to use as a submit button (only for type=\"image\")"),
                    new AttributeCodeGen("step",
                        help: "Specifies the interval between legal numbers in an input field"),

                    new AttributeCodeGen("type", help: "Specifies the type <input> element to display"),





















                    new AttributeCodeGen("value", help: "Specifies the value of an <input> element"),

                    new AttributeCodeGen("width",
                        help: "Specifies the width of an <input> element (only for type=\"image\")"),


                    new AttributeCodeGen("Textarea", help: ""),
                    new AttributeCodeGen("Attribute", help: "Description"),
                    new AttributeCodeGen("autofocus",
                        help: "Specifies that a text area should automatically get focus when the page loads"),
                    new AttributeCodeGen("cols", help: "Specifies the visible width of a text area"),
                    new AttributeCodeGen("dirname",
                        help: "Specifies that the text direction of the textarea will be submitted"),
                    new AttributeCodeGen("disabled", help: "Specifies that a text area should be disabled"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the text area belongs to"),
                    new AttributeCodeGen("maxlength",
                        help: "Specifies the maximum number of characters allowed in the text area"),
                    new AttributeCodeGen("name", help: "Specifies a name for a text area"),
                    new AttributeCodeGen("placeholder",
                        help: "Specifies a short hint that describes the expected value of a text area"),
                    new AttributeCodeGen("readonly", help: "Specifies that a text area should be read-only"),
                    new AttributeCodeGen("required", help: "Specifies that a text area is required/must be filled out"),
                    new AttributeCodeGen("rows", help: "Specifies the visible number of lines in a text area"),
                    new AttributeCodeGen("wrap",
                        help: "Specifies how the text in a text area is to be wrapped when submitted in a form"),

                },
                Standalone = true
            },



            // https://www.w3schools.com/tags/tag_textarea.asp
            new TagCodeGenerator("textarea")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("autofocus",
                        help: "Specifies that a text area should automatically get focus when the page loads"),
                    new AttributeCodeGen("cols", help: "Specifies the visible width of a text area"),
                    new AttributeCodeGen("dirname",
                        help: "Specifies that the text direction of the textarea will be submitted"),
                    new AttributeCodeGen("disabled", help: "Specifies that a text area should be disabled"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the text area belongs to"),
                    new AttributeCodeGen("maxlength",
                        help: "Specifies the maximum number of characters allowed in the text area"),
                    new AttributeCodeGen("name", help: "Specifies a name for a text area"),
                    new AttributeCodeGen("placeholder",
                        help: "Specifies a short hint that describes the expected value of a text area"),
                    new AttributeCodeGen("readonly", help: "Specifies that a text area should be read-only"),
                    new AttributeCodeGen("required", help: "Specifies that a text area is required/must be filled out"),
                    new AttributeCodeGen("rows", help: "Specifies the visible number of lines in a text area"),
                    new AttributeCodeGen("wrap",
                        help: "Specifies how the text in a text area is to be wrapped when submitted in a form"),
                },
            },


            // https://www.w3schools.com/tags/tag_button.asp
            new TagCodeGenerator("button")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("autofocus",
                        help: "Specifies that a button should automatically get focus when the page loads"),
                    new AttributeCodeGen("disabled", help: "Specifies that a button should be disabled"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the button belongs to"),
                    new AttributeCodeGen("formaction",
                        help:
                        "Specifies where to send the form-data when a form is submitted. Only for type=\"submit\""),
                    new AttributeCodeGen("formenctype",
                        help:
                        "Specifies how form-data should be encoded before sending it to a server. Only for type=\"submit\""),
                    new AttributeCodeGen("formmethod",
                        help:
                        "Specifies how to send the form-data (which HTTP method to use). Only for type=\"submit\""),
                    new AttributeCodeGen("formnovalidate",
                        help:
                        "Specifies that the form-data should not be validated on submission. Only for type=\"submit\""),
                    new AttributeCodeGen("formtarget",
                        help:
                        "Specifies where to display the response after submitting the form. Only for type=\"submit\""),
                    new AttributeCodeGen("name", help: "Specifies a name for the button"),
                    new AttributeCodeGen("type", help: "Specifies the type of button"),
                    new AttributeCodeGen("value", help: "Specifies an initial value for the button"),
                },
            },

            // https://www.w3schools.com/tags/tag_select.asp
            new TagCodeGenerator("select")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("autofocus",
                        help: "Specifies that the drop-down list should automatically get focus when the page loads"),
                    new AttributeCodeGen("disabled", help: "Specifies that a drop-down list should be disabled"),
                    new AttributeCodeGen("form", help: "Defines one or more forms the select field belongs to"),
                    new AttributeCodeGen("multiple", help: "Specifies that multiple options can be selected at once"),
                    new AttributeCodeGen("name", help: "Defines a name for the drop-down list"),
                    new AttributeCodeGen("required",
                        help: "Specifies that the user is required to select a value before submitting the form"),
                    new AttributeCodeGen("size", help: "Defines the number of visible options in a drop-down list"),
                },
            },


            // https://www.w3schools.com/tags/tag_optgroup.asp
            new TagCodeGenerator("optgroup")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("disabled", help: "Specifies that an option-group should be disabled"),
                    new AttributeCodeGen("label", help: "Specifies a label for an option-group"),
                },
            },





            new TagCodeGenerator("option")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("disabled", help: "Specifies that an option should be disabled"),
                    new AttributeCodeGen("label", help: "Specifies a shorter label for an option"),
                    new AttributeCodeGen("selected",
                        help: "Specifies that an option should be pre-selected when the page loads"),
                    new AttributeCodeGen("value", help: "Specifies the value to be sent to a server"),

                },
            },

            new TagCodeGenerator("label")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("for", help: "Specifies which form element a label is bound to"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the label belongs to"),

                },
            },

            new TagCodeGenerator("fieldset")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("disabled",
                        help: "Specifies that a group of related form elements should be disabled"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the fieldset belongs to"),
                    new AttributeCodeGen("name", help: "Specifies a name for the fieldset"),
                },
            },


            new TagCodeGenerator("legend"),

            new TagCodeGenerator("datalist"),

            new TagCodeGenerator("output")
            {
                Properties = new List<AttributeCodeGen>
                {
                    new AttributeCodeGen("for",
                        help:
                        "Specifies the relationship between the result of the calculation, and the elements used in the calculation"),
                    new AttributeCodeGen("form", help: "Specifies one or more forms the output element belongs to"),
                    new AttributeCodeGen("name", help: "Specifies a name for the output element"),
                },
            },


        };
    }
}
