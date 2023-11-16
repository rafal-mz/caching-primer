using Xunit;

namespace Lru.Test;

public class LruCacheTest
{
    [Fact]
    public void Can_Query_Cache_And_Get_Items()
    {
        var cache = new LruCache(5);
        var foundItem = "I am in the cache!";
        var notFoundItem = "I am not in the cache :(";

        cache.Set(foundItem, foundItem);

        Assert.Null(cache.Get(notFoundItem));
        Assert.Equal(foundItem, cache.Get(foundItem));
    }

    [Fact]
    public void Cache_Evicts_Items_In_Lru_Order()
    {
        var cache = new LruCache(10);

        for (var i = 0; i < 5; i++)
        {
            var str = i.ToString();

            cache.Set(str, str);
        }

        cache.Get("3");
        cache.Get("4");
        cache.Get("2");
        cache.Get("0");
        cache.Get("1");


        var items = cache.GetValuesInLruOrder();

        Assert.Equal(5, items.Length);
        Assert.Equal("3", items[0]);
        Assert.Equal("4", items[1]);
        Assert.Equal("2", items[2]);
        Assert.Equal("0", items[3]);
        Assert.Equal("1", items[4]);
    }

    [Fact]
    public void Cache_Never_Exceeds_Its_Number_Of_Items()
    {
        var cache = new LruCache(5);

        Parallel.For(0, 500, (index) =>
        {
            var str = index.ToString();

            cache.Set(str, str);

            Assert.InRange(cache.Count, 0, 5);
        });
    }


}