using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Songeul
{
    public class PlayerCam : MonoBehaviour
    {
        
        public Transform player;
        public float mouseSensitivity = 2f;
        private float cameraVerticalRotation = 0f;

        void Update()
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
            player.Rotate(Vector3.up * inputX);
        }
        
        
    }
}
