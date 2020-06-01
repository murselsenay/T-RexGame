using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawnerScript : MonoBehaviour
{
    public GameObject[] cactusPrefabs;
    public GameObject birdPrefab;
    void Start()
    {
        StartCoroutine(SpawnCactus());
        StartCoroutine(SpawnBird());
    }


    void Update()
    {

    }

    public IEnumerator SpawnCactus()
    {
        while (true)
        {
            int randomCactus = Random.Range(0, 4);
            Instantiate(cactusPrefabs[randomCactus], new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2,5));
        }
        

    }
    public IEnumerator SpawnBird()
    {
        while (true)
        {
            
            Instantiate(birdPrefab, new Vector3(transform.position.x, transform.position.y+0.8f, 1), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }


    }
}
