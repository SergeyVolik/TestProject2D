using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class RoketBulletInstall : MonoInstaller
    {

        [SerializeField]
        RoketBullet m_Bullet;

        public override void InstallBindings()
        {
            
            Container.Bind<IExplosionEvent>().To<RoketBullet>().FromInstance(m_Bullet).AsSingle();
        }
    }
}
