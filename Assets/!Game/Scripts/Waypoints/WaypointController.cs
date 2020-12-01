using Company.Settings;
using Zenject;

namespace Company.Gameplay
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaypointController : IWaypointController, IInitializable
    {
        [Inject] 
        private readonly GameSettings.Settings m_gameSettings = null;
        private readonly List<Waypoint> m_registeredWaypoints = new List<Waypoint>();

        private event Action OnWaypointStateChanged ;
        

        public void RegisterWaypoint(Vector3 position)
        {
            if (m_registeredWaypoints.Any(x => x.Position == position))
            {
                return;
            }
            m_registeredWaypoints.Add(new Waypoint(position));
            OnWaypointStateChanged?.Invoke();
        }

        public void UnregisterWaypoint(Waypoint waypoint)
        {
            if (m_registeredWaypoints.Contains(waypoint))
            {
                m_registeredWaypoints.Remove(waypoint);
                OnWaypointStateChanged?.Invoke();
            }
        }

        public List<Waypoint> GetRegisteredWaypoints()
        {
            return m_registeredWaypoints;
        }
        public void SubscribeOnWaypointStateChanged(Action action)
        {
            OnWaypointStateChanged += action;
        }
        public void UnSubscribeOnWaypointStateChanged(Action action)
        {
            OnWaypointStateChanged -= action;
        }

        public void Initialize()
        {
            var waypoints = m_gameSettings.Waypoints;
            waypoints.ForEach(x=>RegisterWaypoint(x.Position));
        }
    }
}