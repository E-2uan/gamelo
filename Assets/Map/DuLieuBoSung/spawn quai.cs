using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnquai : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private float timeBetweenSpawns = 2f;

    [SerializeField] private float enemyScaleFactor = 0.5f; // Hệ số giảm kích thước quái

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);

            // Chọn ngẫu nhiên một quái và một điểm spawn
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnPoint = spawns[Random.Range(0, spawns.Length)].transform;

            // Tạo ra quái tại vị trí spawnPoint
            GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);

            // Scale gốc của enemy (từ prefab)
            Vector3 originalScale = enemy.transform.localScale;

            // Kiểm tra vị trí spawn để lật mặt đúng hướng
            if (spawnPoint.position.x < transform.position.x)
            {
                // Spawn bên trái → nhìn phải
                newEnemy.transform.localScale = new Vector3(
                    Mathf.Abs(originalScale.x) * enemyScaleFactor,
                    originalScale.y * enemyScaleFactor,
                    originalScale.z
                );
            }
            if(spawnPoint.position.x > transform.position.x)
            {
                // Spawn bên phải → nhìn trái
                newEnemy.transform.localScale = new Vector3(
                    Mathf.Abs(originalScale.x) * enemyScaleFactor,
                    originalScale.y * enemyScaleFactor,
                    originalScale.z
                );
            }
        }
    }
}
