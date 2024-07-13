using System.Collections;
using System.Runtime.CompilerServices;

namespace RangeExtension.Utilities;

public static class RangeExtension
{
    public static IEnumerator<int> GetEnumerator(this Range range)
    {
        for (int i = range.Start.Value; i < range.End.Value; i++)
            yield return i;
    }
}

[CollectionBuilder(typeof(RangeCollentionBuilder), "Create")]
public class RangeCollention : IEnumerable<Range>
{
    private readonly Range[] ranges;

    public RangeCollention(ReadOnlySpan<Range> ranges)
    {
        this.ranges = ranges.ToArray();
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var r in ranges)
        {
            foreach (var i in r)
            {
                yield return i;
            }
        }
    }

    IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
    {
        return ((IEnumerable<Range>)ranges).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ranges.GetEnumerator();
    }
}

public static class RangeCollentionBuilder
{
    public static RangeCollention Create(ReadOnlySpan<Range> values) => new(values);
}