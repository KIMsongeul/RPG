using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Songeul
{
    public class PlayerMovement : MonoBehaviour
    {
        private float speed = 5f;
        private float jumpForce = 60f;
        public float groundCheckDistance;
        [SerializeField]
        private LayerMask groundLayer;
        private bool isGround;
        Vector3 cameraPos;
        private Vector3 movement;
        
        private Rigidbody rigid;
        private Animator anim;

        private void Start()
        {
            rigid = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            Physics.gravity = new Vector3(0, -50f, 0);
        }

        private void FixedUpdate()
        {
            Move();
            
        }

        void Move()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");
            movement.Normalize();
            rigid.velocity = movement * speed;
            // if (movement.magnitude >= 0.1)
            // {
            //     anim.SetBool("Walk", true);
            // }
            // else
            // {
            //     anim.SetBool("Walk", false);
            // }
        }

        private void Update()
        {
            //점프
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            isGround= Physics.Raycast
                (transform.position, Vector3.down, groundCheckDistance, groundLayer);
            //Debug.Log(isGround);
            
            
            cameraPos = Camera.main.transform.forward;
            cameraPos.y = 0;
            cameraPos.Normalize();

        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
        }
    }
}
