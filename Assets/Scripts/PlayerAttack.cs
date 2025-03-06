using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Songeul
{
    public class PlayerAttack : MonoBehaviour, IPointerDownHandler
    {
        private float range = 7f;
        public Transform aimPoint;
        public Transform cam;


        public void OnPointerDown(PointerEventData eventData)
        {
            Attack();
        }
        void Attack()
        {
            RaycastHit hit;

            Physics.Raycast(cam.position, aimPoint.forward, out hit, range);
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log(hit.transform.name);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * range);
        }
    }
}
