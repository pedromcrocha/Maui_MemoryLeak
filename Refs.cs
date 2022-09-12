using System.Diagnostics;

namespace MauiTest;
public static class Refs
{
    private static readonly List<WeakReference> _refs = new();

    public static readonly BindableProperty IsWatchedProperty = BindableProperty.CreateAttached("IsWatched", typeof(bool), typeof(Refs), false, propertyChanged: OnIsWatchedChanged);

    public static bool GetIsWatched(BindableObject obj)
    {
        return (bool)obj.GetValue(IsWatchedProperty);
    }

    public static void SetIsWatched(BindableObject obj, bool value)
    {
        obj.SetValue(IsWatchedProperty, value);
    }

    private static void OnIsWatchedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        AddRef(bindable);
    }

    public static void AddRef(object p)
    {
        _refs.Add(new WeakReference(p));
    }

    public static void Print()
    {
        _refs.RemoveAll(a => !a.IsAlive);
        foreach (WeakReference weakReference in _refs)
                Debug.WriteLine("IsAlive: " + weakReference.Target?.GetType().Name);

        Debug.WriteLine($"Total Refs still alive: {_refs.Count  }");
        Debug.WriteLine("---------------");
    }

    public static int GetAliveCount()
    {
        return _refs.Count(weakReference => weakReference.IsAlive);
    }
}