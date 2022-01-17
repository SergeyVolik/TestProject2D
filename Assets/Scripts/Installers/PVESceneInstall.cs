using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{

    public class PVESceneInstall : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AimTouchInput>().FromNew().AsSingle();
        }
    }
}
