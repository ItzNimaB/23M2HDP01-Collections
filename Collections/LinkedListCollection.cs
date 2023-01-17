using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Collections.Collections;
internal class LinkedListCollection<T> : BaseCollection<T>
{
    private LinkedList<T>? _list;
    protected override void fillCollection(string[] input, Func<string, T> func)
    {
        _list = new LinkedList<T>();
        foreach (var item in input)
            _list.AddFirst(func(item));
    }

    protected override void printCollection(TextWriter writer)
    {
        if (_list is null) return;
        foreach (var item in _list) writer.WriteLine(item.ToString());
    }

    protected override void sortCollection(Func<T, T> comparer)
    {
        if(_list is null) return;
        var newList = new LinkedList<T>(_list.OrderBy(comparer));
        _list = newList;
    }

    public override int Count()
    {
        if (_list is null) return 0;
        return _list.Count;
    }
    public override T FirstObject()
    {
        if (_list is null) throw new NullReferenceException();
        return _list.First();
    }

    public override T LastObject()
    {
        if (_list is null) throw new NullReferenceException();
        return _list.Last();
    }
}
