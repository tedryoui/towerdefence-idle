using Game_User_Interface;
using Game_User_Interface.Coins_Model;
using Game_User_Interface.Upgrade_Buttons_Model;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UserInterfaceInstaller : MonoInstaller
    {
        [SerializeField] private UserInterfaceHandler userInterfaceHandler;
        
        public override void InstallBindings()
        {
            Container.Bind<UserInterfaceHandler>()
                .FromInstance(userInterfaceHandler)
                .AsSingle()
                .NonLazy();
        }
    }
}