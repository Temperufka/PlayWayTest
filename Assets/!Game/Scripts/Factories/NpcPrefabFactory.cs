namespace Company.Factory
{
    using Core;
    using Gameplay;
    using Zenject;
    using UnityEngine;
    using Settings;

    public class NpcPrefabFactory : INpcPrefabFactory
    {
        [Inject] private readonly PrefabFactory m_prefabFactory = null;
        [Inject] private readonly GameSettings.Settings m_gameSettings = null;
        private Transform m_root = null;

        Transform Root
        {
            get
            {
                if (m_root == null)
                {
                    m_root = new GameObject(GetType().Name + "_Root").transform;
                }

                return m_root;
            }
        }
        
        public NpcInstance SpawnNPCInstance()
        { 
            var prefabInfo = GameInfoContainer.Instance.GetPrefabInfo();
            var npcPrefab = prefabInfo.NpcPrefab;
            var npc = m_prefabFactory.Create(npcPrefab, Root);
            SetupNPC(npc);
            return npc;
        }


        private void SetupNPC(NpcInstance npcInstance)
        {
            var playerSettings = m_gameSettings.PlayerSettings;
            var movementSpeed = playerSettings.MovementSpeed;
            npcInstance.NavMeshAgent.speed = movementSpeed;
        }
    }
}