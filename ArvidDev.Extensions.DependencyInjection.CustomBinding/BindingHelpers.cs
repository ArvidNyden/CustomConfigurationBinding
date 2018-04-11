using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ArvidDev.Extensions.DependencyInjection.CustomBinding
{
    public class BindingHelpers
    {
        public static T Bind<T>(IEnumerable<KeyValuePair<string, string>> valuesToSet) where T : class
        {
            var myobj = Activator.CreateInstance(typeof(T)) as T;

            foreach (var value in valuesToSet)
            {
                TrySetProperty(myobj, value.Key, value.Value);
            }

            return myobj;
        }

        private static void TrySetProperty<T>(T newObject, string property, object value) where T : class
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propName = prop.Name;

                // Only use last if multiple
                var propCustomBindName = prop.GetCustomAttributes<BindToConfigurationAttribute>().ToList();

                if (!propCustomBindName.Any())
                    return;

                var customBindingName = propCustomBindName.Last().BindingName;

                // If custom binding is null use name of property
                var bindingName = propCustomBindName == null ? propName : customBindingName;

                // Only set if binding is correct and property have a set
                if (bindingName == property && prop.CanWrite)
                    typeof(T).GetProperty(prop.Name).SetValue(newObject, value);
            }
        }
    }
}

    

