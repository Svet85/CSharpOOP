using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> strings;

        public MyList()
        {
            this.strings = new List<string>();
        }
        
        public int Used => this.strings.Count;

        public int Add(string element)
        {
            this.strings.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            if (this.strings.Count > 0)
            {
                string item = this.strings[0];
                this.strings.RemoveAt(0);
                return item;
            }

            return null;
        }
    }
}
