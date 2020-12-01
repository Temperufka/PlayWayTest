namespace Company.Core
{
    using UnityEngine;
    public abstract class SingletonContainer<T> : BaseContainer where T : ScriptableObject
    {
        public static T Instance { get; protected set; }
        protected sealed override void OnEnable()
        {
            AssignInstance();
        }
        protected abstract void AssignInstance();
 
    }
}