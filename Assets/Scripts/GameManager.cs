using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Bott;
    public GameObject left;
    public GameObject right;
    public GameObject top;
    public Transform GameViewPoint;
    public float spawnInterval = 2f;
    public float spawnOffset = -10f;
    public float speed = 5f;        
    public float spawnRange = 1f;   
    private List<GameObject> prefabs;

    void Start()
    {
        prefabs = new List<GameObject> { Bott, left, right, top };
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomObject();
        }
    }
    void SpawnRandomObject()
    {
        if (prefabs.Count == 0) return;

        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Count)];
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = GameViewPoint.position + new Vector3(randomX, randomY, spawnOffset);
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity); 
        spawnedObject.AddComponent<MovingObject>().Initialize(GameViewPoint.position.z, speed);
        Debug.Log("Spawneado en posición: " + spawnPosition);
    }
}
