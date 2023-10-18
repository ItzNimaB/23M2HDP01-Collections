using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace H2_Collections.Collections

{
    internal class LinkedListCollection<T> : BaseLineCollection<T>
    {
        LinkedList<T> linkedList;

        protected override void fillCollection(string[] input, Func<string, T> func)
        {
            linkedList = new LinkedList<T>();
            foreach (var item in input)
            {
                linkedList.AddLast(func(item));
                
            }
        }
        protected override void printCollection(TextWriter writer)
        {
            foreach (var item in linkedList)
            {
                writer.WriteLine(item);
            }
        }

        protected override void sortCollection(Func<T, T> comparer)
        {
            linkedList = new LinkedList<T>(linkedList.OrderBy(comparer));
        }

        public override int Count()
        {
            return linkedList.Count;
        }
        public override T FirstObject()
        {
            return linkedList.First();
        }

        public override T LastObject()
        {
            return linkedList.Last();
        }
    }
}
