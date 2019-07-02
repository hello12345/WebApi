using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;


namespace WebApiHelper
{
    public class CommonFunctions
    {
        #region UserFunctions
        public static string GetIPAddress()
        {
            string IPAddress = string.Empty;
            if (System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).Length > 1)
            {
                IPAddress = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[1].ToString();
            }

            return IPAddress;
        }

        /// <summary>
        /// Get UTC date time.
        /// </summary>
        /// <returns></returns>
        public static DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }

        public static void FillObject(object LogicObject, DataRow Row)
        {
            Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                props.Add(p.Name, p);
            foreach (DataColumn col in Row.Table.Columns)
            {
                string name = col.ColumnName;
                if (Row[name] != DBNull.Value && props.ContainsKey(name))
                {
                    object item = Row[name];
                    PropertyInfo p = props[name];
                    if (p.PropertyType != col.DataType)
                        item = Convert.ChangeType(item, p.PropertyType);
                    p.SetValue(LogicObject, item, null);
                }
            }

        }

        public static DataTable ClassToDataTable<T>() where T : class
        {
            Type classType = typeof(T);

            List<PropertyInfo> propertyList = classType.GetProperties().ToList();
            if (propertyList.Count < 1)
            {
                return new DataTable();
            }

            string className = classType.UnderlyingSystemType.Name;
            DataTable result = new DataTable(className);

            foreach (PropertyInfo property in propertyList)
            {
                DataColumn col = new DataColumn
                {
                    ColumnName = property.Name
                };

                Type dataType = property.PropertyType;

                if (IsNullable(dataType))
                {
                    if (dataType.IsGenericType)
                    {
                        dataType = dataType.GenericTypeArguments.FirstOrDefault();
                    }
                }
                else
                {   // True by default
                    col.AllowDBNull = false;
                }

                col.DataType = dataType;

                result.Columns.Add(col);
            }

            return result;
        }

        public static DataTable ClassListToDataTable<T>(List<T> ClassList) where T : class
        {
            DataTable result = ClassToDataTable<T>();

            if (result.Columns.Count < 1)
            {
                return new DataTable();
            }
            if (ClassList.Count < 1)
            {
                return result;
            }

            foreach (T item in ClassList)
            {
                ClassToDataRow(ref result, item);
            }

            return result;
        }

        public static void ClassToDataRow<T>(ref DataTable Table, T Data) where T : class
        {
            Type classType = typeof(T);
            string className = classType.UnderlyingSystemType.Name;

            // Checks that the table name matches the name of the class. 
            // There is not required, and it may be desirable to disable this check.
            // Comment this out or add a boolean to the parameters to disable this check.
            if (!Table.TableName.Equals(className))
            {
                return;
            }

            DataRow row = Table.NewRow();
            List<PropertyInfo> propertyList = classType.GetProperties().ToList();

            foreach (PropertyInfo prop in propertyList)
            {
                if (Table.Columns.Contains(prop.Name))
                {
                    if (Table.Columns[prop.Name] != null)
                    {
                        row[prop.Name] = prop.GetValue(Data, null);
                    }
                }
            }
            Table.Rows.Add(row);
        }

        /// <summary>
        /// Fills the public properties of a class from the first row of a DataTable
        ///  where the name of the property matches the column name from that DataTable.
        /// </summary>
        /// <param name="Table">A DataTable that contains the data.</param>
        /// <returns>A class of type T with its public properties matching column names
        ///      set to the values from the first row in the DataTable.</returns>
        public static T ToClass<T>(DataTable Table) where T : class, new()
        {
            T result = new T();
            if (Validate(Table))
            {  // Because reflection is slow, we will only pass the first row of the DataTable
                result = FillProperties<T>(Table.Rows[0]);
            }
            return result;
        }

        /// <summary>
        /// Fills the public properties of a class from each row of a DataTable where the name of
        /// the property matches the column name in the DataTable, returning a List of T.
        /// </summary>
        /// <param name="Table">A DataTable that contains the data.</param>
        /// <returns>A List class T with each class's public properties matching column names
        ///      set to the values of a diffrent row in the DataTable.</returns>
        public static List<T> ToClassList<T>(DataTable Table) where T : class, new()
        {
            List<T> result = new List<T>();

            if (Validate(Table))
            {
                foreach (DataRow row in Table.Rows)
                {
                    result.Add(FillProperties<T>(row));
                }
            }
            return result;
        }

        /// <summary>
        /// Fills the public properties of a class from a DataRow where the name
        /// of the property matches a column name from that DataRow.
        /// </summary>
        /// <param name="Row">A DataRow that contains the data.</param>
        /// <returns>A class of type T with its public properties set to the
        ///      data from the matching columns in the DataRow.</returns>
        public static T FillProperties<T>(DataRow Row) where T : class, new()
        {
            T result = new T();
            Type classType = typeof(T);

            // Defensive programming, make sure there are properties to set,
            //   and columns to set from and values to set from.
            if (Row.Table.Columns.Count < 1
                || classType.GetProperties().Length < 1
                || Row.ItemArray.Length < 1)
            {
                return result;
            }

            foreach (PropertyInfo property in classType.GetProperties())
            {
                foreach (DataColumn column in Row.Table.Columns)
                {
                    // Skip if Property name and ColumnName do not match
                    if (property.Name != column.ColumnName)
                        continue;
                    // This would throw if we tried to convert it below
                    if (Row[column] == DBNull.Value)
                        continue;

                    object newValue;

                    // If type is of type System.Nullable, do not attempt to convert the value
                    if (IsNullable(property.PropertyType))
                    {
                        newValue = Row[property.Name];
                    }
                    else
                    {   // Convert row object to type of property
                        newValue = Convert.ChangeType(Row[column], property.PropertyType);
                    }

                    // This is what sets the class properties of the class
                    property.SetValue(result, newValue, null);
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Checks a DataTable for empty rows, columns or null.
        /// </summary>
        /// <param name="DataTable">The DataTable to check.</param>
        /// <returns>True if DataTable has data, false if empty or null.</returns>
        public static bool Validate(DataTable DataTable)
        {
            if (DataTable == null) return false;
            if (DataTable.Rows.Count == 0) return false;
            if (DataTable.Columns.Count == 0) return false;
            return true;
        }

        /// <summary>
        /// Checks if type is nullable, Nullable<T> or its reference is nullable.
        /// </summary>
        /// <param name="type">Type to check for nullable.</param>
        /// <returns>True if type is nullable, false if it is not.</returns>
        public static bool IsNullable(Type type)
        {
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }


        public static void SendEmail(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("noreply@satva.solutions")
            };
            // The important part -- configuring the SMTP client
            SmtpClient smtp = new SmtpClient
            {
                Port = 587,   // [1] You can try with 465 also, I always used 587 and got success
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network, // [2] Added this
                UseDefaultCredentials = false, // [3] Changed this
                Credentials = new NetworkCredential("AKIAJH65TQ6RIMRMK22A", "AtnB7eMin4KadguShAz8rcohe1jWxwJw45cV7H1VM6s0"),  // [4] Added this. Note, first parameter is NOT string.
                Host = "email-smtp.us-west-2.amazonaws.com"
            };
            //recipient address
            mail.To.Add(new MailAddress(email));
            //Formatted mail body
            mail.IsBodyHtml = true;

            mail.Subject = subject;
            mail.Body = message;
            smtp.Send(mail);
        }
        public static string ResetPasswordTemplate(string username, string password)
        {
            var temp = "<div><Strong>User Name:</Strong></div>" + username + "<div><Strong>Password :</Strong></div>" + password;
            return temp;
        }
        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static async void WriteTextLogger(string Message)
        {
            var logPath = "logs/" + DateTime.Today.ToShortDateString().Replace(@"/", "_") + ".txt";
            FileStream logFile;
            if (!System.IO.File.Exists(logPath))
                logFile = System.IO.File.Create(logPath);
            else
                logFile = System.IO.File.Open(logPath, FileMode.Append);
            var logWriter = new System.IO.StreamWriter(logFile);
            await logWriter.WriteLineAsync("=============================Start========================================");
            await logWriter.WriteLineAsync(string.Format("Date : {0}", DateTime.Now.ToString()));
            await logWriter.WriteLineAsync(Message);
            await logWriter.WriteLineAsync("=============================End========================================");
            logWriter.Dispose();
        }
        #endregion


    }

}
