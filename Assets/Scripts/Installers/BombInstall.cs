using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class BombInstall : MonoInstaller
    {

        [SerializeField]
        Bomb m_Bullet;

        public override void InstallBindings()
        {
            
            Container.Bind<IExplosionEvent>().To<Bomb>().FromInstance(m_Bullet).AsSingle();
        }
    }
}
