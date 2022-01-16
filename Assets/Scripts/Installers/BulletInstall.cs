using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class BulletInstall : MonoInstaller
    {

        [SerializeField]
        Bullet m_Bullet;

        public override void InstallBindings()
        {
            //Container.Bind<Bullet>().FromInstance(m_Bullet).AsSingle();
            Container.Bind<IBulletCollision>().To<Bullet>().FromInstance(m_Bullet).AsSingle();
        }
    }
}
