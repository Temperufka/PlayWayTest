namespace Company.Factory
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Zenject;

    public class PrefabFactory
    {
        private readonly DiContainer m_container;
        private readonly List<Object> m_prefabs;
        public PrefabFactory(DiContainer container, List<Object> prefabs)
        {
            m_container = container;
            m_prefabs = prefabs;
        }

        public T Create<T>() where T : MonoBehaviour
        {
            var prefab = m_prefabs.OfType<T>().Single();
            return m_container.InstantiatePrefabForComponent<T>(prefab);
        }

        public T Create<T>(T prefab, Transform parent = null) where T : MonoBehaviour
        {
            if (parent != null)
            {
                return m_container.InstantiatePrefabForComponent<T>(prefab, parent);
            }
            else
            {
                return m_container.InstantiatePrefabForComponent<T>(prefab);
            }

        }
    }
}