namespace Company.Gameplay
{
   
    using UnityEngine;
    using UnityEngine.AI;
    using Zenject;
    using Settings;

    public class PlayerMovementController :  ITickable, IInitializable
    {
        [Inject] 
        private readonly GameSettings.Settings m_gameSettings = null;

        [Inject] 
        private readonly ICharacterDataProvider m_characterDataProvider = null;
        private int m_currentPoint = 0;
        private Vector3 m_currentDestination = Vector3.zero;

        private void CheckMovement()
        {
            var npc = m_characterDataProvider.GetRegisteredNPC();
            var agent = npc.NavMeshAgent;
            if (agent.destination == m_currentDestination)
            {
                CheckNextPoint(agent);
            }
        }

 
        private void CheckNextPoint(NavMeshAgent navMeshAgent)
        {
            var wayPoints = m_gameSettings.Waypoints;
            if (wayPoints.Count == 0)
            {
                return;
            }

            navMeshAgent.destination = wayPoints[m_currentPoint].Position;
            m_currentDestination = navMeshAgent.destination;
            m_currentPoint = (m_currentPoint + 1) % wayPoints.Count;
        }


        public void Tick()
        {
            CheckMovement();
        }

        public void Initialize()
        {
            var npc = m_characterDataProvider.GetRegisteredNPC();
            CheckNextPoint(npc.NavMeshAgent);
        }
    }
}