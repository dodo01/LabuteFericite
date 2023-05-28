using System;
namespace LabuteCalatoare.DataBase.BaseModel
{
    public abstract class BaseDbModel
    {
        public object this[string columnName]
        {
            get { return GetType().GetProperty(columnName).GetValue(this); }
            set { GetType().GetProperty(columnName).SetValue(this, value); }
        }
    }
}
