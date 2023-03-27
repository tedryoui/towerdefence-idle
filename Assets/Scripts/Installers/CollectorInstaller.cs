using Collector_Scripts;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CollectorInstaller : MonoInstaller
    {
        [SerializeField] private Collector _collector;
        
        public override void InstallBindings()
        {
            Container.Bind<Collector>()
                .FromInstance(_collector)
                .AsSingle()
                .NonLazy();
        }
    }
}