using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //this class is use for getting box collider referance from unity 
    public class GroundBoxCollider : MonoBehaviour
    {
        public static BoxCollider groundboxCollider;
        void Awake()
        {
            groundboxCollider = GetComponent<BoxCollider>();
        }
    }
}