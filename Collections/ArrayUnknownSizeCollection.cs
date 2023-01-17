using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace H2_Collections.Collections;
internal class ArrayUnknownSizeCollection<T> : BaseCollection<T>
{
    T[] _array = new T[0];
    public override int Count()
    {
        return _array.Length;
    }

    public override T FirstObject()
    {
        return (T)_array[0];
    }

    public override T LastObject()
    {
        return (_array[_array.Length - 1]);
    }

    protected override void fillCollection(string[] input, Func<string, T> func)
    {
        foreach (var item in input)
        {
            _array = _array.Append(func(item)).ToArray<T>();
        }
    }

    protected override void printCollection(TextWriter writer)
    {
        if (_array is null) return;
        //print all data
        foreach (var item in _array)
        {
            writer.WriteLine(item);
        }
        writer.Flush();
    }

    protected override void sortCollection(Func<T, T> comparer)
    {
        _array = _array.OrderBy(comparer).ToArray<T>();
    }
}
