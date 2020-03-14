using System;

namespace mvp_frame
{
  public abstract class Singleton<T> where T : class
  {
    class Nested
    {
      internal static readonly T instance = Activator.CreateInstance(typeof(T), true) as T;
    }
    private static readonly T instance = null;
    public static T Instance { get { return Nested.instance; } }
  }
}
