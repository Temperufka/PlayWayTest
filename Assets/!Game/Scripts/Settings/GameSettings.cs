
using System.Collections.Generic;

namespace Company.Settings
{
    using UnityEngine;
    using System;

    public class GameSettings
    {
        private readonly Settings m_settings = null;

        public GameSettings(Settings settings)
        {
            m_settings = settings;
        }

        [Serializable]
        public class Settings
        {
            [SerializeField] private PlayerSettings m_playerSettings = null;
            [SerializeField] private List<Waypoint> m_wayPoints = new List<Waypoint>();

            public PlayerSettings PlayerSettings
            {
                get => m_playerSettings;
            }

            public List<Waypoint> Waypoints
            {
                get => m_wayPoints;
            }
        }

        [Serializable]
        public class PlayerSettings
        {
            [SerializeField] private float m_movementSpeed = 200f;

            public float MovementSpeed
            {
                get => m_movementSpeed;
            }
        }

        [Serializable]
        public class Waypoint
        {
            [SerializeField] private Vector3 m_position = Vector3.zero;

            public Vector3 Position
            {
                get => m_position;
            }
            
        }
    }
}