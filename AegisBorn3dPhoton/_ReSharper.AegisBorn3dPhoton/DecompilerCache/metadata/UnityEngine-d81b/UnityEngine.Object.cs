// Type: UnityEngine.Object
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using Boo.Lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public class Object
    {
        public static implicit operator bool(UnityEngine.Object exists);
        public static bool operator ==(UnityEngine.Object x, UnityEngine.Object y);
        public static bool operator !=(UnityEngine.Object x, UnityEngine.Object y);
        public override bool Equals(object o);
        public override int GetHashCode();
        public int GetInstanceID();

        [DuckTyped]
        public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation);

        [DuckTyped]
        public static UnityEngine.Object Instantiate(UnityEngine.Object original);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static void Destroy(UnityEngine.Object obj, float t);

        public static void Destroy(UnityEngine.Object obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static void DestroyImmediate(UnityEngine.Object obj, bool allowDestroyingAssets);

        public static void DestroyImmediate(UnityEngine.Object obj);

        [DuckTyped]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static UnityEngine.Object[] FindObjectsOfType(System.Type type);

        [DuckTyped]
        public static UnityEngine.Object FindObjectOfType(System.Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static void DontDestroyOnLoad(UnityEngine.Object target);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static void DestroyObject(UnityEngine.Object obj, float t);

        public static void DestroyObject(UnityEngine.Object obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static UnityEngine.Object[] FindSceneObjectsOfType(System.Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static UnityEngine.Object[] FindObjectsOfTypeIncludingAssets(System.Type type);

        [DuckTyped]
        [Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
        public static UnityEngine.Object[] FindObjectsOfTypeAll(System.Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override string ToString();

        public string name { get; set; }
        public HideFlags hideFlags { get; set; }
    }
}
