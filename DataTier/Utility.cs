using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace DataTier
{
    public class Utility
    {
          public static List<T> DataTableToCollection<T>(DataTable dt)
            {
                List<T> lst = new System.Collections.Generic.List<T>();
                Type tClass = typeof(T);
                PropertyInfo[] pClass = tClass.GetProperties();
                List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
                T cn;
                foreach (DataRow item in dt.Rows)
                {
                    cn = (T)Activator.CreateInstance(tClass);
                    foreach (PropertyInfo pc in pClass)
                    {
                        //// Can comment try catch block. 
                        //try
                        //{
                            DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                            if (d != null && item[pc.Name] != DBNull.Value)
                                pc.SetValue(cn, item[pc.Name], null);
                        //}
                        //catch
                        //{
                        //}
                    }
                    lst.Add(cn);
                }
                return lst;
            }

          public static List<T> ConvetrToList<T, src>(List<src> srcList)
          {
              List<T> lst = new System.Collections.Generic.List<T>();

              if (srcList != null)
              {
                  foreach (var item in srcList)
                  {
                      T tmp = convertSrcToTarget<src, T>(item);

                      if (tmp != null)
                          lst.Add(tmp);
                  }
              }

              return lst;
          }

          public static T convertSrcToTarget<src,T>(src srcObject)
          {
              T rslt;

              Type tType = typeof(T);
              PropertyInfo[] tarProp = tType.GetProperties();

              Type srcType = typeof(src);
              PropertyInfo[] srcProp = srcType.GetProperties();

              rslt = (T)Activator.CreateInstance(tType);

              foreach (PropertyInfo pc in srcProp)
              {
                  var pi = tarProp.Select(x => x.Name == pc.Name).FirstOrDefault();
                  if (pi != null)
                  {
                      var val = srcType.GetProperty(pc.Name).GetValue(srcObject, null);
                      tType.GetProperty(pc.Name).SetValue(rslt, val, null);
                  }
              }

              return rslt;
          }

          //public static T ConvertTo<T>(object value) 
          //{
          //    Type t = typeof(T);


          //    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
          //    {
          //        // Nullable type.

          //        if (value == null)
          //        {
          //            // you may want to do something different here.
          //            return default(T);
          //        }
          //        else
          //        {
          //            // Get the type that was made nullable.
          //            Type valueType = t.GetGenericArguments()[0];

          //            // Convert to the value type.
          //            object result = Convert.ChangeType(value, valueType);

          //            // Cast the value type to the nullable type.
          //            return (T)result;
          //        }
          //    }
          //    else
          //    {
          //        // Not nullable.
          //        //IConvertible convertible = value as IConvertible;

          //        Type convertToType = typeof(T);

          //        TypeConverter tc = TypeDescriptor.GetConverter(convertToType);

          //        T blah = tc.ConvertTo(value, T);


          //        return (T)Convert.ChangeType(convertible, typeof(T));
          //    }
          //} 


    }
}
