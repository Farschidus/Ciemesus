using System;

namespace BLL.Hardcodes
{
    [Serializable]
    public class Item
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_Title = "Title";

        public Item(object id, string title)
        {
            this.ID = id;
            this.Title = title;
        }
        
        private object _ID;
        public object ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title= value;
            }
        }
    }  
}
