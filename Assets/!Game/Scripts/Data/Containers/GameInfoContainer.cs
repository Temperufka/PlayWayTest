namespace Company.Core
{
    using System;
    using UnityEngine;
    
    [Serializable]
    public class GameInfo
    {
        [SerializeField] private PrefabInfo m_prefabInfo;

        public PrefabInfo PrefabInfo
        {
            get => m_prefabInfo;
        }
    }
    
    [Serializable]
    public class GameInfoContainer : SingletonContainer<GameInfoContainer>
    {
        [SerializeField] private GameInfo m_data;

        public GameInfo Data
        {
            get => m_data;
        }
        protected override void AssignInstance()
        {
            Instance = this;
        }

        public PrefabInfo GetPrefabInfo()
        {
            return Data.PrefabInfo;
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("CompanyMenuItems/Containers(Generate)/GameInfoContainer")]
        public static void CreateAsset()
        {
            CreateAsset(new System.Diagnostics.StackFrame().GetMethod().DeclaringType);
        }
#endif
    }
}
