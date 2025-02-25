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
        private float groundCheckDistance = 1.1f;
        [SerializeField]
        private LayerMask groundLayer;
        private bool isGround;
        
        private Rigidbody rigid;

        private void Start()
        {
            rigid = GetComponent<Rigidbody>();
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

        }
    }
}
