using System;

namespace ArvidDev.Extensions.DependencyInjection.CustomBinding
{
    public class BindToConfigurationAttribute : Attribute
    {
        public string BindingName { get; }

        public BindToConfigurationAttribute(string bindingName)
        {
            BindingName = bindingName;
        }
    }
}