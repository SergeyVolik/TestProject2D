using UnityEngine;

namespace TestProject
{
    public class AudioSettingsSO : ScriptableObject
    {
        [SerializeField]
        protected AudioClip[] SFX;
        public virtual void Play(AudioSource source)
        {
            source.clip = SFX[Random.Range(0, SFX.Length)];
            source.Play();
        }
    }
}
