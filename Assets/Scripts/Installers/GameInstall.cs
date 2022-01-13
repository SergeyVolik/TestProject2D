using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public enum Players
    {
        Player1,
        Player2
    }

    public class GameInstall : MonoInstaller
    {
        [SerializeField]
        TapManager Tap;

        [SerializeField]
        Player m_Player1;
        [SerializeField]
        Player m_Player2;
        public override void InstallBindings()
        {
            Container.Bind<Player>().WithId(Players.Player1).FromInstance(m_Player1).AsTransient();
            Container.Bind<Player>().WithId(Players.Player2).FromInstance(m_Player2).AsTransient();

            Container.Bind<TapManager>().FromInstance(Tap).AsSingle().NonLazy();
           
        }
    }
}