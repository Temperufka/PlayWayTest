namespace Company.Bootstrap.Installers
{
    using UnityEngine;
    using Zenject;
    using Settings;

    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings.Settings m_gameSettings = null;

        public override void InstallBindings()
        {
            Container.BindInstances(m_gameSettings);
        }
    }
}