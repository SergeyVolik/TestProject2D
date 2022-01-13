using UnityEngine;
using Zenject;

namespace TestProject
{
    public class VFXManager : MonoBehaviour
    {

        BloodEffect.Factory m_BulletEffectFactory;
        MuzzleFlashEffect.Factory m_MuzzleFactory;
        BulletCollistionEffect.Factory m_BulletCollision;

        [Inject]
        void Construct(BloodEffect.Factory bulletEffectFactory, MuzzleFlashEffect.Factory muzzleFactory, BulletCollistionEffect.Factory bulletCollision)
        {
            m_BulletEffectFactory = bulletEffectFactory;
            m_MuzzleFactory = muzzleFactory;
            m_BulletCollision = bulletCollision;
        }


        public void PlayBulletCollision(Vector2 point)
        {
            var effect = m_BulletCollision.Create();
            effect.Play();
            effect.transform.position = point;
        }

        public void PlayMuzzleEffectWithPos(Vector3 postion)
        {
            var effect = m_MuzzleFactory.Create();
            effect.Play();
            effect.transform.position = postion;
        }

        public void PlayBloodEffect(bool fromLeft, Transform transform, Vector2 point)
        {
            float yRot = fromLeft ? 90 : -90;

            var effect = m_BulletEffectFactory.Create();
            effect.transform.SetParent(transform);
            effect.transform.position = point;


            effect.transform.rotation = Quaternion.Euler(effect.transform.eulerAngles.x, yRot, effect.transform.eulerAngles.z);

            effect.Play();
        }

    }

}
