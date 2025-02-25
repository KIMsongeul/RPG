using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Songeul
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform player;
        private float detectionRange = 8f;
        private float stopRange = 2f;
        private float wanderRange = 5f;
        private float wanderTimer = 10f;

        private NavMeshAgent agent;
        private float timer;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            timer = wanderTimer;
        }

        private void Update()
        {
            float distancePlayer = Vector3.Distance(player.position, transform.position);
            if (distancePlayer <= stopRange)
            {
                agent.ResetPath();
                Debug.Log("Attack Player");
            }
            else if (distancePlayer < detectionRange)
            {
                agent.SetDestination(player.position);
                Debug.Log("Follow Player");
            }
            else
            {
                Wander();
            }

            timer += Time.deltaTime;
        }

        private void Wander()
        {
            if (timer >= wanderTimer)
            {
                Vector3 wanderPos = Random.insideUnitSphere * wanderRange;
                wanderPos += transform.position;
                agent.SetDestination(wanderPos);
                timer = 0;
                Debug.Log("Wander : " + wanderPos);
            }
        }
    }
}
