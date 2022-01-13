using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class HealthBarInstall : MonoInstaller
    {

        [SerializeField]
        HealthHandler m_HealthHandler;

        public override void InstallBindings()
        {
            Container.Bind<HealthHandler>().FromInstance(m_HealthHandler).AsSingle();
           
        }
    }
}
