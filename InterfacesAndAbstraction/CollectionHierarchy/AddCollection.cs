namespace CollectionHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AddCollection : IAddCollection
    {
        private List<string> strings;

        public AddCollection()
        {
            this.strings = new List<string>();
        }

        public int Add(string el)
        {
            this.strings.Add(el);
            return this.strings.Count - 1;
        }


    }
}
