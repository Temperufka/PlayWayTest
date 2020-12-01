namespace Company.Bootstrap.Installers
{
    using Zenject;
    using Factory;
    using Data;
    using Gameplay;
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DataProvidersBinging();
            FactoriesBinding();
            ControllersBinding();
        }

        private void DataProvidersBinging()
        {
            Container.Bind(typeof(IInitializable), typeof(ICharacterDataProvider)).To<CharacterDataProvider>().AsSingle();
        }

        private void ControllersBinding()
        {
            Container.Bind( typeof(ITickable), typeof(IInitializable)).To<PlayerMovementController>().AsSingle();
        }
        private void FactoriesBinding()
        {
            Container.Bind<PrefabFactory>().AsSingle();
            Container.Bind<INpcPrefabFactory>().To<NpcPrefabFactory>().AsSingle();

        }
    }
}