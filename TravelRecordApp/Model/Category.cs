using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public bool Primary { get; set; }
    }
}
