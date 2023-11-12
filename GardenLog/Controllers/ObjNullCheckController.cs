using System.Reflection;

namespace GardenLog.Controllers
{
    // summary:
    // created to check for null values in objects, currently not used

    public class ObjNullCheckController
    {
        public static bool HasNullValue { get; internal set; }

        public static bool HasNullValues(object obj)
        {
            if (obj == null)
            {
                return true;
            }

            // check main type
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var propertyInfo in type.GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(obj);

                if (propertyValue == null)
                {
                    return true; // At least one property is null
                }
            }

            return false; // No null properties found
        }
    }
}
