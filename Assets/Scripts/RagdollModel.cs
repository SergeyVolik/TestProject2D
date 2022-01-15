using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class RagdollModel : MonoBehaviour
    {   
        [SerializeField]
        public BodyParts BodyParts;

        public void SetPositionsAndRotations(BodyParts realModel)
        {
            BodyParts.Chest.SetPositionAndRotation(realModel.Chest.position, realModel.Chest.rotation);     
            BodyParts.Head.SetPositionAndRotation(realModel.Head.position, realModel.Head.rotation);


            BodyParts.LeftArm.SetPositionAndRotation(realModel.LeftArm.position, realModel.LeftArm.rotation);
            BodyParts.LeftForearm.SetPositionAndRotation(realModel.LeftForearm.position, realModel.LeftForearm.rotation);
            BodyParts.RightForearm.SetPositionAndRotation(realModel.RightForearm.position, realModel.RightForearm.rotation);
            BodyParts.RightArm.SetPositionAndRotation(realModel.RightArm.position, realModel.RightArm.rotation);
            BodyParts.LeftLeg.SetPositionAndRotation(realModel.LeftLeg.position, realModel.LeftLeg.rotation);
            BodyParts.LeftThigh.SetPositionAndRotation(realModel.LeftThigh.position, realModel.LeftThigh.rotation);
            BodyParts.RightLeg.SetPositionAndRotation(realModel.RightLeg.position, realModel.RightLeg.rotation);
            BodyParts.RightThigh.SetPositionAndRotation(realModel.RightThigh.position, realModel.RightThigh.rotation);

        }

        

    }
    [System.Serializable]
    public class BodyParts
    {
        public Transform LeftArm;
        public Transform LeftForearm;
        public Transform RightArm;
        public Transform RightForearm;
        public Transform Chest;
        public Transform LeftLeg;
        public Transform LeftThigh;
        public Transform RightLeg;
        public Transform RightThigh;
        public Transform Head;

    }
}
