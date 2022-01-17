using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace TestProject.PVE
{
    public class ThrowAxe : MonoBehaviour
    {
        AimTouchInput m_Input;
        Axe.Factory m_Factory;
        [SerializeField]
        Transform m_BodyAxe;

        [SerializeField]
        Transform m_Spine;

        [SerializeField]
        private float Power = 1000;

        [SerializeField]
        private float AxeRotPower = 200;

        
        [Inject]
        void Construct(AimTouchInput input, Axe.Factory factory)
        {
            m_Input = input;
            m_Factory = factory;
        }

        private void OnEnable()
        {
            m_Input.OnAimStarted += M_Input_OnAimStarted;
            m_Input.OnAimEnded += M_Input_OnAimEnded;
        }

        private void M_Input_OnAimEnded()
        {
            PlayThrowAnimation();
        }

        private void M_Input_OnAimStarted(Vector2 obj)
        {
            
        }

        private void OnDisable()
        {
            m_Input.OnAimStarted -= M_Input_OnAimStarted;
            m_Input.OnAimEnded -= M_Input_OnAimEnded;
        }

        public void PlayThrowAnimation()
        {
            m_Spine
                .DORotate(new Vector3(0, m_Spine.rotation.eulerAngles.y, m_Spine.rotation.eulerAngles.z), 0.3f)
                .SetEase(Ease.Linear)
                .OnComplete(() => {
                    Throw();
            });
        }

        public void Throw()
        {
            var axe = m_Factory.Create();
            axe.transform.SetPositionAndRotation(m_BodyAxe.transform.position, m_BodyAxe.transform.rotation);
            var rb = axe.GetComponent<Rigidbody2D>();
            var vec = (m_Input.StartPos - m_Input.EndPos);
            //Debug.Log(vec.magnitude);
            //Debug.Log(vec.sqrMagnitude);
            rb.AddForce(vec.normalized * Power);
            rb.AddTorque(AxeRotPower);
            StartCoroutine(HideAxe());
        }

        IEnumerator HideAxe()
        {
            m_BodyAxe.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            m_BodyAxe.gameObject.SetActive(true);
        }

    }

}

