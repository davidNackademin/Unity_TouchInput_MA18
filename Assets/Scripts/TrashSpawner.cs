using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;
    public float delay = 0.5f;
    public float spawnRange = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateTrash());
    }

    IEnumerator CreateTrash()
    {
        while (true)
        {
            GameObject trash = Instantiate(trashPrefab);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, 0);
            trash.transform.position = spawnPosition;
            yield return new WaitForSeconds(delay);
        }
        
    }

    
}
