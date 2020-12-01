
using System;

namespace Company.Gameplay
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.AI;
    using Zenject;
    using Settings;

    public class PlayerMovementController :  ITickable, IInitializable, IDisposable
    {

        [Inject] 
        private readonly IWaypointController m_waypointController = null;
        [Inject] 
        private readonly ICharacterDataProvider m_characterDataProvider = null;
        
        private int m_currentPoint = 0;
        private Vector3 m_currentDestination = Vector3.zero;

        private bool m_allowProcess = false;


        private List<Waypoint> WayPoints
        {
            get => m_waypointController.GetRegisteredWaypoints();
        }

        private NpcInstance RegisteredNPC
        {
            get => m_characterDataProvider.GetRegisteredNPC();
        }
        
        private void CheckMovement()
        {
            if (RegisteredNPC == null)
            {
                return;
            }
            
            var agent = RegisteredNPC.NavMeshAgent;
            if (agent.destination == m_currentDestination)
            {
                CheckNextPoint(agent);
            }
        }
        
        private void CheckNextPoint(NavMeshAgent navMeshAgent)
        {
            if (WayPoints.Count == 0)
            {
                return;
            }

            navMeshAgent.destination = WayPoints[m_currentPoint].Position;
            m_currentDestination = navMeshAgent.destination;
            m_currentPoint = (m_currentPoint + 1) % WayPoints.Count;
        }


        private void CheckProcessAllow()
        {
            if (WayPoints.Count > 0 && m_allowProcess == false)
            {
                m_allowProcess = true;
                CheckNextPoint(RegisteredNPC.NavMeshAgent);
            }

            if (WayPoints.Count == 0)
            {
                m_allowProcess = false;
            }
        }
        public void Tick()
        {
            if (m_allowProcess)
            {
                CheckMovement();
            }
        }

        public void Initialize()
        {
            m_waypointController.SubscribeOnWaypointStateChanged(CheckProcessAllow);
        }
        
        public void Dispose()
        {
            m_waypointController.UnSubscribeOnWaypointStateChanged(CheckProcessAllow);
        }
    }
}