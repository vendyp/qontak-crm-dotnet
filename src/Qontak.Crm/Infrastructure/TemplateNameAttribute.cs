using System;

namespace Qontak.Crm
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public  class TemplateNameAttribute : Attribute
    {
        public TemplateNameAttribute(TemplateConstant @enum)
        {
            Name = @enum.ToValueString();
        }

        public string Name { get; }
    }
}
