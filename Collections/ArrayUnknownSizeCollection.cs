using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace H2_Collections.Collections

{
    internal class ArrayUnknownSizeCollection<T> : BaseLineCollection<T>
    {
        private T[]? array;


        protected override void fillCollection(string[] input, Func<string, T> func)
        {
            array = new T[0];
            foreach (var item in input)
            {
                Array.Resize(ref array, array.Length + 1);
                array[^1] = func(item);
            }
        }
        protected override void printCollection(TextWriter writer)
        {
            foreach (var item in array)
            {
                writer.WriteLine(item);
            }
            writer.Flush();
        }

        protected override void sortCollection(Func<T, T> comparer)
        {
            Array.Sort(array);
        }

        public override int Count()
        {
            return array.Length;
        }
        public override T FirstObject()
        {
            return array[0];
        }

        public override T LastObject()
        {
            return array[^1];
        }
    }
}
