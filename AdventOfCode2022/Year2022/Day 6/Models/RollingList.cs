using System.Collections;

namespace AdventOfCode2022.Year2022.Day_6.Models;

// Credit to https://stackoverflow.com/a/18404024

public class RollingList<T> : IEnumerable<T>
{
    private readonly LinkedList<T> _list = new LinkedList<T>();

    public RollingList(int maximumCount)
    {
        if (maximumCount <= 0)
            throw new ArgumentException(null, nameof(maximumCount));

        MaximumCount = maximumCount;
    }

    public int MaximumCount { get; }
    public int Count => _list.Count;

    public void Add(T value)
    {
        if (_list.Count == MaximumCount)
        {
            _list.RemoveFirst();
        }
        _list.AddLast(value);
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            return _list.Skip(index).First();
        }
    }

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}