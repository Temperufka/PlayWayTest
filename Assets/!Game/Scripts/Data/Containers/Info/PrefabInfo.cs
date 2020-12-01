
namespace Company.Core
{

    using UnityEngine;
    using System;
    using Gameplay;

    [Serializable]
    public class PrefabInfo
    {
        [SerializeField] private NpcInstance m_npcPrefab = null;

        public NpcInstance NpcPrefab
        {
            get => m_npcPrefab;
        }
    }
}