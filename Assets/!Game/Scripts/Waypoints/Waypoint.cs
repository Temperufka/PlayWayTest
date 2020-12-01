namespace Company.Gameplay
{

    using UnityEngine;

    public class Waypoint
    {
        private readonly Vector3 m_position;

        public Vector3 Position
        {
            get => m_position;
        }

        public Waypoint(Vector3 position)
        {
            m_position = position;
        }
    }
}