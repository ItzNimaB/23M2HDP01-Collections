using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace H2_Collections.Collections
{
    internal class ListCollection<T> : BaseCollection<T>
    {
        List<T>? list;
        protected override void fillCollection(string[] input, Func<string, T> func)
        {
            list = new List<T>();
            foreach(var item in input)
            {
                list.Add(func(item));
            }
        }

        protected override void printCollection(TextWriter writer)
        {
            foreach (var item in list)
            {
                writer.WriteLine(item);
            }
            writer.Flush();
        }

        protected override void sortCollection(Func<T, T> comparer)
        {
            list.Sort();
        }

        public override int Count()
        {
            if (list is null) return 0;
            return list.Count;
        }
        public override T FirstObject()
        {
            if (list is null) throw new NullReferenceException();
            return list[0];
        }

        public override T LastObject()
        {
            if (list is null) throw new NullReferenceException();
            return list[list.Count - 1];
        }
    }
}
