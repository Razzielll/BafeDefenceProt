using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnCenter;
    [SerializeField] float spawnLenghtX;
    [SerializeField] float spawnLenghtY;
    [SerializeField] float spawnPerSecond = 1f;
    [SerializeField] Transform enemyContainer;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > 1 / spawnPerSecond)
        {
            SpawnEnemy();
            timer = 0;
        }
        
    }

    public void SpawnEnemy()
    {
        float newRandX = Random.Range(-spawnLenghtX, spawnLenghtX);
        float newRandY = Random.Range(-spawnLenghtY, spawnLenghtY);


        float newX = newRandX + spawnCenter.position.x;
        float newZ = newRandY + spawnCenter.position.z;
        float newY = transform.position.y;
        Vector3 spawnPosition = new Vector3(newX,newY,newZ);
        Instantiate(enemyPrefab, spawnPosition,Quaternion.identity, enemyContainer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnCenter.position, new Vector3(2*spawnLenghtX, 1f, 2*spawnLenghtY));
    }
}
