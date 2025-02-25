using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Songeul
{
    public class PlayerCam : MonoBehaviour
    {
        public Transform target;
        
        private float xAxis;
        private float yAxis;
        
        private float rotationSpeed = 3f;
        private float distance = 2f;
        private float rotationMin = 10f;
        private float rotationMax = 10f;
        private float smoothTime = 0.1f;
        
        private Vector3 targetRotation;
        private Vector3 currentVelocity;
    }
}
