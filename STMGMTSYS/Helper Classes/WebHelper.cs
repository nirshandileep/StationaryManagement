using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.EnterpriseServices;

namespace STMGMTSYS.Helper_Classes
{
    public class WebHelper
    {
        public static SelectList GetSelectListByEnum<T>() where T : struct
        {
            T t = default(T);
            Dictionary<int, string> mydic = new Dictionary<int, string>();
            if (t.GetType().IsEnum)
            {
                var nameList = t.GetType().GetEnumNames();
                int counter = 1;

                if (nameList != null && nameList.Length > 0)
                {
                    foreach (var name in nameList)
                    {
                        T newEnum = (T)Enum.Parse(t.GetType(), name);
                        string description = getDescriptionFromEnumValue(newEnum as Enum);

                        mydic.Add(counter, description);
                        counter++;
                    }

                    counter = 0;
                }
            } 
            return new SelectList(mydic, "Key", "Value");
        }

        private static string getDescriptionFromEnumValue(Enum value)
        {
            DescriptionAttribute description = value.GetType().
                GetField(value.ToString()).
                GetCustomAttributes(typeof(DescriptionAttribute), false).
                SingleOrDefault() as DescriptionAttribute;

            return description == null ? value.ToString() : description.ToString();
        }
    }
}