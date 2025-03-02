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
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rigid.velocity = movement * speed;
            if (movement.magnitude >= 0.1)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }
            
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
            Debug.Log(isGround);

        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
        }
    }
}
