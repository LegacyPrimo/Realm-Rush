using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    private GameObject[] poolObjects;
    [SerializeField] [Range(0, 50)] private int poolSize = 5;

    [SerializeField] [Range(0.1f, 30f)] private float timeDelay;
    [SerializeField] private bool isPlaying;

    private void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        StartCoroutine(InstantiateEnemies());
    }

    private void PopulatePool() 
    {
        poolObjects = new GameObject[poolSize];

        for (int i = 0; i < poolObjects.Length; i++) 
        {
            poolObjects[i] = Instantiate(enemyObject, transform);
            poolObjects[i].SetActive(false);
        }
    }

    private void EnablePoolObject()
    {
        for (int i = 0; i < poolObjects.Length; i++) 
        {
            if (poolObjects[i].activeInHierarchy == false)
            {
                poolObjects[i].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator InstantiateEnemies() 
    {
        while (isPlaying) 
        {
            EnablePoolObject();
            yield return new WaitForSeconds(timeDelay);
            
        }
    }

    
}
