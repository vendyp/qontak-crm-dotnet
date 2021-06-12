using System;
using System.Collections.Generic;
using System.Linq;

namespace Qontak.Crm
{
    public class PropertyValidatorManager
    {
        public PropertyValidatorManager()
        {
            _validators = new Dictionary<string, IPropertyFieldValidator>();

            Initialize();
        }

        private void Initialize()
        {
            _validators.Add(key: PropertyFieldTypeConstant.SingleLineText, value: new SingleLineTextValidator());
            _validators.Add(key: PropertyFieldTypeConstant.DropdownSelect, value: new DropdownSelectValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Number, value: new NumberValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Date, value: new DateValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Upload, value: new UploadValidator());
            _validators.Add(key: PropertyFieldTypeConstant.MultipleSelect, value: new MultipleSelectValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Percentage, value: new PercentageValidator());
            _validators.Add(key: PropertyFieldTypeConstant.TextArea, value: new TextAreaValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Checklist, value: new ChecklistValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Photo, value: new PhotoValidator());
            _validators.Add(key: PropertyFieldTypeConstant.URL, value: new UrlValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Signature, value: new SignatureValidator());
            _validators.Add(key: PropertyFieldTypeConstant.Gps, value: new GpsValidator());
        }

        private Dictionary<string, IPropertyFieldValidator> _validators { get; }

        public IPropertyFieldValidator GetPropertyFieldValidator(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            return _validators.Where(x => x.Key == type).Select(x => x.Value).FirstOrDefault();
        }
    }
}
