using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Services.DateTimeManagement
{
    public class DataTimeManagement
    {
        private Nullable<DateTime> _dateTime { get; set; }
        private StringBuilder _stringDateTime { get; set; }

        public DataTimeManagement()
        {
            this._stringDateTime = new StringBuilder(null);
        }

        public DataTimeManagement SetDateTime(DateTime? dateTime)
        {
            this._dateTime = dateTime;
            this._stringDateTime.Clear();
            return this;
        }

        public static string DateToString(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString("dd/MM/yyyy");
            else
                return null;
        }

        public static string TimeToString(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString("hh:mm tt");
            else
                return null;
        }

        public string getString()
        {
            if (this._dateTime.HasValue)
                return string.Copy(this._stringDateTime.ToString());
            else
                return null;
        }

        public DataTimeManagement ToStringDate()
        {
            string date = null;

            if (this._dateTime.HasValue)
            {
                date = this._dateTime.Value.ToString("dd/MM/yyyy ");
                if (HasDate())
                {
                    DeleteDateInString();
                }

                this._stringDateTime.Insert(0, date).Replace(this._stringDateTime.ToString(), this._stringDateTime.ToString().Trim());
            }

            return this;
        }

        public DataTimeManagement ToStringTime()
        {
            string value;

            if (this._dateTime.HasValue)
            {
                this._stringDateTime.Clear();

                if (HasDate())
                    value = this._dateTime.Value.ToString("dd/MM/yyyy hh:mm tt");
                else
                    value = this._dateTime.Value.ToString("hh:mm tt");

                this._stringDateTime.Append(value);
            }
            return this;
        }

        public Nullable<DateTime> StringToDateTime(string dateTime)
        {
            Nullable<DateTime> dateTimeResult = null;

            if (HasDate(dateTime) && HasTime(dateTime))
                dateTimeResult = DateTime.ParseExact(dateTime.Trim(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            else if (HasDate(dateTime))
                dateTimeResult = DateTime.ParseExact(dateTime.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (dateTimeResult.HasValue)
            {
                this._stringDateTime.Clear().Append(dateTimeResult.Value.ToString("dd/MM/yyyy hh:mm tt"));
                this._dateTime = dateTimeResult;
            }

            this._stringDateTime.Clear();

            return dateTimeResult;
        }

        private bool HasDate(string dateTime = null)
        {
            if (!string.IsNullOrWhiteSpace(dateTime))
                return dateTime.ToString().Contains("/");
            else
                return this._stringDateTime.ToString().Contains("/");
        }

        private bool HasTime(string dateTime = null)
        {
            if (!string.IsNullOrWhiteSpace(dateTime))
                return dateTime.Trim().Contains(":") || dateTime.Trim().Contains("m");
            else
                return this._stringDateTime.ToString().Trim().Contains(":") || this._stringDateTime.ToString().Trim().Contains("m");
        }

        private StringBuilder DeleteDateInString()
        {
            if (HasDate())
            {
                this._stringDateTime.Replace(this._stringDateTime.ToString(), this._stringDateTime.ToString().Trim());
                this._stringDateTime.Remove(0, 10);
            }

            return this._stringDateTime;
        }
    }
}
