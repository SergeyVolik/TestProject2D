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

        [Header("Gameplay")]

        [SerializeField]
        Player m_Player1;
        [SerializeField]
        Player m_Player2;

        [SerializeField]
        DeathHandler m_Player1DeathHandler;
        [SerializeField]
        DeathHandler m_Player2DeathHandler;

        [SerializeField]
        ShowWinnerText m_Player1ShowWinnerText;
        [SerializeField]
        ShowWinnerText m_Player2ShowWinnerText;

      



        [Header("UI managers")]
        [SerializeField]
        UiManager m_Ui;

        [SerializeField]
        TapManager Tap;


        [SerializeField]
        BonusSpawner m_BonusSpawner;
        public override void InstallBindings()
        {
            Container.Bind<Player>().WithId(Players.Player1).FromInstance(m_Player1).AsTransient();
            Container.Bind<Player>().WithId(Players.Player2).FromInstance(m_Player2).AsTransient();

            Container.Bind<DeathHandler>().WithId(Players.Player1).FromInstance(m_Player1DeathHandler).AsTransient();
            Container.Bind<DeathHandler>().WithId(Players.Player2).FromInstance(m_Player2DeathHandler).AsTransient();

            Container.Bind<ShowWinnerText>().WithId(Players.Player1).FromInstance(m_Player1ShowWinnerText).AsTransient();
            Container.Bind<ShowWinnerText>().WithId(Players.Player2).FromInstance(m_Player2ShowWinnerText).AsTransient();

            Container.Bind<TapManager>().FromInstance(Tap).AsSingle().NonLazy();
            
            Container.Bind<UiManager>().FromInstance(m_Ui).AsSingle().NonLazy();
            Container.Bind<BonusSpawner>().FromInstance(m_BonusSpawner).AsSingle().NonLazy();

            Container.BindInterfacesTo<JumpManager>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DebugManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WinDetector>().FromNew().AsSingle().NonLazy();

        }

       
    }
}
