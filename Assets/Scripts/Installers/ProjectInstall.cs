using System.Collections;
using System.Collections.Generic;
using TestProject.PVE;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class ProjectInstall : MonoInstaller
    {


        [SerializeField]
        Bullet m_BulletPrefab;

        [SerializeField]
        RoketBullet m_RoketBulletPrefab;

        [SerializeField]
        Axe m_AxePrefab;

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
        
        [Header("Enemy")]
        [SerializeField]
        SimpleEnemy m_enemy;
        public override void InstallBindings()
        {
            DeclareSignals();

            Container.Bind<SoundManager>().AsSingle().NonLazy();
            Container.Bind<VFXManager>().AsSingle().NonLazy();

            InstallProjectilesFactory();

            InstallVFXFactories();

            InstallSoundShotFactory();

            InstallBonuses();

            InstallSimpleEnemyFactory();
        }

        private void DeclareSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EnemyKillSignal>();
            Container.DeclareSignal<ActivateShieldSignal>();
            Container.DeclareSignal<UIActivatedSignal>();
        }

        private void InstallSimpleEnemyFactory()
        {
            Container.BindFactory<SimpleEnemy, SimpleEnemy.Factory>()
              .FromComponentInNewPrefab(m_enemy)
              .WithGameObjectName("SimpleEnemy")
              .UnderTransformGroup("SimpleEnemyGroup");
        }

        private void InstallProjectilesFactory()
        {
            Container.BindFactory<Bullet, Bullet.Factory>()
                .FromComponentInNewPrefab(m_BulletPrefab)
                .WithGameObjectName("Bullet")
                .UnderTransformGroup("BulletsGroup");

            Container.BindFactory<RoketBullet, RoketBullet.Factory>()
               .FromComponentInNewPrefab(m_RoketBulletPrefab)
               .WithGameObjectName("RoketBullet")
               .UnderTransformGroup("RoketBulletGroup");

            Container.BindFactory<Axe, Axe.Factory>()
              .FromComponentInNewPrefab(m_AxePrefab)
              .WithGameObjectName("Axe")
              .UnderTransformGroup("AxeGroup");
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
    }
}
