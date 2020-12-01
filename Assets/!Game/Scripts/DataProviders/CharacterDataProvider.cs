using UnityEngine;

namespace Company.Data
{
    using System;
    using Factory;
    using Gameplay;
    using Zenject;


    public class CharacterDataProvider : ICharacterDataProvider, IInitializable
    {
        [Inject] 
        private readonly INpcPrefabFactory m_npcPrefabFactory;
        private NpcInstance m_npc = null;
        
        public void Initialize()
        {
            var npc = m_npcPrefabFactory.SpawnNPCInstance();
            RegisterNpcInstance(npc);
            
        }
        private void RegisterNpcInstance(NpcInstance npcInstance)
        {
            if (m_npc == null)
            {
                m_npc = npcInstance;
            }
            else
            {
                throw new Exception("NPC is already registered");
            }
            
        }

        
        public NpcInstance GetRegisteredNPC()
        {
            return m_npc;
        }
    }
}