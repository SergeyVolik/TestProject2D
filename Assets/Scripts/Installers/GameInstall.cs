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

        [SerializeField]
        Bullet m_BulletPrefab;

        [SerializeField]
        RoketBullet m_RoketBulletPrefab;

        [Header("Effects")]


        [SerializeField]
        BloodEffect m_BloodEffectPrefab;

        [SerializeField]
        MuzzleFlashEffect m_MuzzleFlashPrefab;

        [SerializeField]
        BulletCollistionEffect m_BulletCollisionEffect;

        [SerializeField]
        ExplosionEffect m_ExplosionEffectPrefab;

        [Header("Sound")]
        [SerializeField]
        SoundShot m_SoundShotPrefab;



        [Header("UI managers")]
        [SerializeField]
        UiManager m_Ui;

        [SerializeField]
        TapManager Tap;

        [Header("Bonus prefabs")]
        [SerializeField]
        Bomb m_BombPrefab;
        [SerializeField]
        FirstAidKit m_FirstAidKitPrefab;
        [SerializeField]
        ShieldBuster m_ShieldPrefab;
        [SerializeField]
        HeadShieldBuster m_HeadShieldPrefab;
        [SerializeField]
        RoketBulletsBonus m_RoketBulletsBonusPrefab;

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
            Container.Bind<SoundManager>().AsSingle().NonLazy();
            Container.Bind<VFXManager>().AsSingle().NonLazy();
            Container.Bind<UiManager>().FromInstance(m_Ui).AsSingle().NonLazy();
            Container.Bind<BonusSpawner>().FromInstance(m_BonusSpawner).AsSingle().NonLazy();

            Container.BindInterfacesTo<JumpManager>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DebugManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WinDetector>().FromNew().AsSingle().NonLazy();

            InstallBulletFactory();

            InstallVFXFactories();

            InstallSoundShotFactory();

            InstallBonuses();
        }

        private void InstallBonuses()
        {
            Container.BindFactory<Bomb, Bomb.Factory>()
               .FromComponentInNewPrefab(m_BombPrefab)
               .WithGameObjectName("Bomb")
               .UnderTransformGroup("BombGroup");

            Container.BindFactory<FirstAidKit, FirstAidKit.Factory>()
                .FromComponentInNewPrefab(m_FirstAidKitPrefab)
                .WithGameObjectName("FirstAidKit")
                .UnderTransformGroup("FirstAidKitGroup");

            Container.BindFactory<ShieldBuster, ShieldBuster.Factory>()
                .FromComponentInNewPrefab(m_ShieldPrefab)
                .WithGameObjectName("ShieldBuster")
                .UnderTransformGroup("ShieldBusterGroup");

            Container.BindFactory<RoketBulletsBonus, RoketBulletsBonus.Factory>()
                .FromComponentInNewPrefab(m_RoketBulletsBonusPrefab)
                .WithGameObjectName("RoketBulletsBonus")
                .UnderTransformGroup("RoketBulletsBonusGroup");

            Container.BindFactory<HeadShieldBuster, HeadShieldBuster.Factory>()
               .FromComponentInNewPrefab(m_HeadShieldPrefab)
               .WithGameObjectName("HeadShieldBuster")
               .UnderTransformGroup("HeadShieldBusterGroup");
        }

        private void InstallBulletFactory()
        {
            Container.BindFactory<Bullet, Bullet.Factory>()
                .FromComponentInNewPrefab(m_BulletPrefab)
                .WithGameObjectName("Bullet")
                .UnderTransformGroup("BulletsGroup");

            Container.BindFactory<RoketBullet, RoketBullet.Factory>()
               .FromComponentInNewPrefab(m_RoketBulletPrefab)
               .WithGameObjectName("RoketBullet")
               .UnderTransformGroup("RoketBulletGroup");
        }

        private void InstallSoundShotFactory()
        {
            Container.BindFactory<SoundShot, SoundShot.Factory>()
               .FromComponentInNewPrefab(m_SoundShotPrefab)
               .WithGameObjectName("SoundShot")
               .UnderTransformGroup("SoundShotGroup");
        }

        private void InstallVFXFactories()
        {
            Container.BindFactory<BloodEffect, BloodEffect.Factory>()
                .FromComponentInNewPrefab(m_BloodEffectPrefab)
                .WithGameObjectName("BloodEffect")
                .UnderTransformGroup("BloodEffectGroup");

            Container.BindFactory<MuzzleFlashEffect, MuzzleFlashEffect.Factory>()
               .FromComponentInNewPrefab(m_MuzzleFlashPrefab)
               .WithGameObjectName("MuzzleFlashEffect")
               .UnderTransformGroup("MuzzleFlashEffectGroup");

            Container.BindFactory<BulletCollistionEffect, BulletCollistionEffect.Factory>()
               .FromComponentInNewPrefab(m_BulletCollisionEffect)
               .WithGameObjectName("BulletCollisionEffect")
               .UnderTransformGroup("BulletCollistionEffectGroup");

            Container.BindFactory<ExplosionEffect, ExplosionEffect.Factory>()
               .FromComponentInNewPrefab(m_ExplosionEffectPrefab)
               .WithGameObjectName("ExplosionEffect")
               .UnderTransformGroup("ExplosionEffectGroup");
        }
    }
}
