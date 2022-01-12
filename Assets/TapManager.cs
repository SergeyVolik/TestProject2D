using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class TapManager : ITickable
    {

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CheckLeftBound())
                {
                    Debug.Log("Left Part Of Screen");
                    return;
                }

                Debug.Log("Right Part Of Screen");
            }
        }


        bool CheckLeftBound()
        {
            var pos = Input.mousePosition;

            if (pos.x < Screen.width / 2)
            {
                return true;
            }

            return false;
        }

    }

}
