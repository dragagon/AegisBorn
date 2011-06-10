// Type: UnityEngine.MonoBehaviour
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System.Collections;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public class MonoBehaviour : Behaviour
    {
        public MonoBehaviour();
        public bool useGUILayout { get; set; }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void Invoke(string methodName, float time);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void InvokeRepeating(string methodName, float time, float repeatRate);

        public void CancelInvoke();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void CancelInvoke(string methodName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public bool IsInvoking(string methodName);

        public bool IsInvoking();
        public Coroutine StartCoroutine(IEnumerator routine);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public Coroutine StartCoroutine_Auto(IEnumerator routine);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public Coroutine StartCoroutine(string methodName, object value);

        public Coroutine StartCoroutine(string methodName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void StopCoroutine(string methodName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void StopAllCoroutines();

        public static void print(object message);
    }
}
