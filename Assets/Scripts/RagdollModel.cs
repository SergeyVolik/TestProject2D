using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class RagdollModel : MonoBehaviour
    {   
        [SerializeField]
        public BodyParts BodyParts;

        RagdollSettings m_Settings;

        [Inject]
        void Construct(RagdollSettings settings)
        {
            m_Settings = settings;
        }

        private void Start()
        {
            Debug.Log("RagdollModel setup");
            for (int i = 0; i < BodyParts.Parts.Count; i++)
            {
                SetupPart(BodyParts.Parts[i]);
            }

        }
        public void Activate()
        {

            for (int i = 0; i < BodyParts.Parts.Count; i++)
            {
                ActivatePart(BodyParts.Parts[i]);
            }
        }

        void ActivatePart(Rigidbody2D part)
        {
            part.bodyType = RigidbodyType2D.Dynamic;

        }

        void SetupPart(Rigidbody2D part)
        {
            part.mass = m_Settings.mass;
            part.gravityScale = m_Settings.gravity;

            if (part.TryGetComponent<HingeJoint2D>(out var hj))
            {
                Debug.Log("HingeJoint2D setup");
                hj.breakForce = m_Settings.breakForce;
            }
        }

    }
    [System.Serializable]
    public class BodyParts
    {
        public List<Rigidbody2D> Parts;


    }
}
