// Type: UnityEngine.Component
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using Boo.Lang;
using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public class Component : UnityEngine.Object
    {
        public Transform transform { get; }
        public Rigidbody rigidbody { get; }
        public Camera camera { get; }
        public Light light { get; }
        public Animation animation { get; }
        public ConstantForce constantForce { get; }
        public Renderer renderer { get; }
        public AudioSource audio { get; }
        public GUIText guiText { get; }
        public NetworkView networkView { get; }

        [DuckTyped]
        [Obsolete("Please use guiTexture instead")]
        public GUIElement guiElement { get; }

        public GUITexture guiTexture { get; }

        [DuckTyped]
        public Collider collider { get; }

        public HingeJoint hingeJoint { get; }
        public ParticleEmitter particleEmitter { get; }
        public GameObject gameObject { get; }

        [Obsolete(
            "the active property is deprecated on components. Please use gameObject.active instead. If you meant to enable / disable a single component use enabled instead."
            )]
        public bool active { get; set; }

        public string tag { get; set; }

        [DuckTyped]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public Component GetComponent(System.Type type);

        public T GetComponent<T>() where T : Component;

        [DuckTyped]
        public Component GetComponent(string type);

        [DuckTyped]
        public Component GetComponentInChildren(System.Type t);

        public T GetComponentInChildren<T>() where T : Component;

        [DuckTyped]
        public Component[] GetComponentsInChildren(System.Type t);

        public Component[] GetComponentsInChildren(System.Type t, bool includeInactive);
        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component;
        public T[] GetComponentsInChildren<T>() where T : Component;

        [DuckTyped]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public Component[] GetComponents(System.Type type);

        public T[] GetComponents<T>() where T : Component;

        [MethodImpl(MethodImplOptions.InternalCall)]
        public bool CompareTag(string tag);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void SendMessageUpwards(string methodName, object value, SendMessageOptions options);

        public void SendMessageUpwards(string methodName, object value);
        public void SendMessageUpwards(string methodName);
        public void SendMessageUpwards(string methodName, SendMessageOptions options);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void SendMessage(string methodName, object value, SendMessageOptions options);

        public void SendMessage(string methodName, object value);
        public void SendMessage(string methodName);
        public void SendMessage(string methodName, SendMessageOptions options);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options);

        public void BroadcastMessage(string methodName, object parameter);
        public void BroadcastMessage(string methodName);
        public void BroadcastMessage(string methodName, SendMessageOptions options);
    }
}
