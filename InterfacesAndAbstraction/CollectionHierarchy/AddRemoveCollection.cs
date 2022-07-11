using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> strings;

        public AddRemoveCollection()
        {
            this.strings = new List<string>();
        }

        public int Add(string element)
        {
            this.strings.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            if (this.strings.Count > 0)
            {
                string item = this.strings[strings.Count - 1];
                this.strings.RemoveAt(strings.Count - 1);
                return item;
            }

            return null;
        }
    }
}
