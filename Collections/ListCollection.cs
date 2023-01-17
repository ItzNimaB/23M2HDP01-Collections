using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace H2_Collections.Collections;
internal class ListCollection<T> : BaseCollection<T>
{
    private List<T>? _list;
    protected override void fillCollection(string[] input, Func<string, T> func)
    {
        _list = new List<T>();
        foreach (var item in input) _list.Add(func(item));
    }

    protected override void printCollection(TextWriter writer)
    {
        if (_list is null) return;
        foreach (var item in _list) writer.WriteLine(item);
    }

    protected override void sortCollection(Func<T, T> comparer)
    {
        if( _list is null) return;
        _list.Sort();
    }

    public override int Count()
    {
        if (_list is null) return 0;
        return _list.Count;
    }
    public override T FirstObject()
    {
        if (_list is null) throw new NullReferenceException();
        return _list[0];
    }

    public override T LastObject()
    {
        if (_list is null) throw new NullReferenceException();
        return _list[_list.Count - 1];
    }
}
