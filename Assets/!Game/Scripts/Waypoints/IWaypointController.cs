using System.Collections.Generic;

namespace Company.Gameplay
{
    using System;
    using  UnityEngine;
    public interface IWaypointController
    {
        void RegisterWaypoint(Vector3 position);
        void UnregisterWaypoint(Waypoint waypoint);
        void SubscribeOnWaypointStateChanged(Action action);
        void UnSubscribeOnWaypointStateChanged(Action action);
        List<Waypoint> GetRegisteredWaypoints();
    }
}