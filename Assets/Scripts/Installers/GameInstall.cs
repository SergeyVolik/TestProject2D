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

        [SerializeField]
        Bullet m_BulletPrefab;

        [SerializeField]
        BloodEffect m_BloodEffectPrefab;

        [SerializeField]
        MuzzleFlashEffect m_MuzzleFlashPrefab;

        [SerializeField]
        BulletCollistionEffect m_BulletCollisionEffect;
        public override void InstallBindings()
        {
            Container.Bind<Player>().WithId(Players.Player1).FromInstance(m_Player1).AsTransient();
            Container.Bind<Player>().WithId(Players.Player2).FromInstance(m_Player2).AsTransient();

            Container.Bind<TapManager>().FromInstance(Tap).AsSingle().NonLazy();

            InstallVFXFactories();
        }

        private void InstallVFXFactories()
        {
            Container.BindFactory<Bullet, Bullet.Factory>()
                .FromComponentInNewPrefab(m_BulletPrefab)
                .WithGameObjectName("Bullet")
                .UnderTransformGroup("BulletsGroup");

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
        }
    }
}
