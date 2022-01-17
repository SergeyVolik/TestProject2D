using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{

    public class PVESceneInstall : MonoInstaller
    {

        [SerializeField]
        private SimpleEnemySpawner m_spawner;
        [SerializeField]
        private PVEUI m_pveUI;
        [SerializeField]
        private AimTouchInput mAimTouchInput;
        public override void InstallBindings()
        {
           

            Container.Bind<AimTouchInput>().FromInstance(mAimTouchInput).AsSingle();
            Container.Bind<SimpleEnemySpawner>().FromInstance(m_spawner).AsSingle();
            Container.Bind<PVEUI>().FromInstance(m_pveUI).AsSingle();
        }
    }
}
