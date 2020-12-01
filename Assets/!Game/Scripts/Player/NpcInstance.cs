namespace Company.Gameplay
{
    using System;
    using UnityEngine.AI;
    using UnityEngine;

    [RequireComponent(typeof(NavMeshAgent))]
    public class NpcInstance : MonoBehaviour
    {
        private NavMeshAgent m_navMeshAgent = null;

        public NavMeshAgent NavMeshAgent
        {
            get
            {
                if (m_navMeshAgent == null)
                {
                    if (TryGetComponent(out NavMeshAgent navMesh))
                    {
                        m_navMeshAgent = navMesh;
                    }
                    else
                    {
                        throw new Exception("NavMeshAgent not found");
                    }
                }

                return m_navMeshAgent;
            }
        }
    }
}