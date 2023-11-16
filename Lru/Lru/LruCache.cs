using System.Collections.Concurrent;

namespace Lru;

public sealed class LruCache
{
    private readonly int _capacity;

    private readonly ConcurrentDictionary<string, LinkedListNode<string>> _storage;
    private readonly LinkedList<string> _orderer;

    public LruCache(int capacity)
    {
        _capacity = capacity;
        _storage = new ConcurrentDictionary<string, LinkedListNode<string>>();
        _orderer = new LinkedList<string>();
    }

    public int Count
    {
        get
        {
            // Return count of items that cache is currently holding.

            return int.MinValue;
        }
    }

    public string? Get(string key)
    {
        ArgumentException.ThrowIfNullOrEmpty(key);

        if (_storage.TryGetValue(key, out var value))
        {
            if (value.List == null)
            {
                return value.Value;
            }

            lock (_orderer)
            {
                if (value.List == null)
                {
                    return value.Value;
                }

                _orderer.Remove(value);
                _orderer.AddLast(value);
            }

            return value.Value;
        }

        return null;
    }

    /// <summary>
    /// Returns all cached values in order from the least recently used to the latest used.
    /// </summary>
    public string[] GetValuesInLruOrder()
    {
        // Get values from the least recently used to latest used order.

        return Array.Empty<string>();
    }

    /// <summary>
    /// Sets value in the cache.
    /// </summary>
    public bool Set(string key, string value)
    {
        // 1. Create LinkedListNode with value.
        // 2. Try to add item to the main storage. If it fails, it means item is already in the cache.
        // 3. If it succeeds, it means that we need to update orderer.
        // 4. Orderer is not thread safe by default so we need to use mutexes to make it thread safe.
        // 5. We need to add new node as the latest used (end of the linked list).
        // 6. If orderer is equal to capacity, we should remove least recently used item from both storage and orderer.

        return false;
    }
}
