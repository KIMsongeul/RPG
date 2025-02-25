using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Songeul
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private int i;
        private int spawnRange = 8;
        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            while (true)
            {
                Vector3 spawnPosition = Random.insideUnitSphere * spawnRange;
                spawnPosition += transform.position;
                GameObject enemyObj = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemyObj.name = "Enemy(" + i + ")";
                HpSystem hpSystem = enemyObj.AddComponent<HpSystem>();
                hpSystem.maxHp = 10;
                hpSystem.attackDamage = 3;
                i++;
                yield return new WaitForSeconds(3.0f);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRange);
        }
    }
}
