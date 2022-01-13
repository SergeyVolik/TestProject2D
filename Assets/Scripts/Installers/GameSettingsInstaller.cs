using System;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [CreateAssetMenu(menuName = "TestProject2D/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {

        public GameSounds Sounds;
        public ShootingSettigs ShootingSettigs;
        public PlayerSettings PlayerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(Sounds);
            Container.BindInstance(ShootingSettigs);
            Container.BindInstance(PlayerSettings);
        }


    }

    [Serializable]
    public class GameSounds
    {
        public SFXSettingsSO HitSFX;
        public SFXSettingsSO BulletCollisionSFX;
        public SFXSettingsSO ShotSFX;
    }

    [Serializable]
    public class ShootingSettigs
    {
        public float BulletSpeed = 1000f;
        public float DelayBetweenShots = 0.5f;
        public int HeadDamage = 3;
        public int ChessDamage = 2;
        public int LegDamage = 1;
    }

    [Serializable]
    public class PlayerSettings
    {
        public int MaxHealth = 5;
        public LayerMask GoundMask;
        public int AdditionalJumps = 1;
        public float JumpForce = 600;

    }
}
