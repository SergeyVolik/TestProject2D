using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{

    public class PVESceneInstall : MonoInstaller
    {

        [SerializeField]
        Axe m_AxePrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AimTouchInput>().FromNew().AsSingle();

            Container.BindFactory<Axe, Axe.Factory>()
                .FromComponentInNewPrefab(m_AxePrefab)
                .WithGameObjectName("m_AxePrefab")
                .UnderTransformGroup("m_AxePrefabGroup");
        }
    }
}
