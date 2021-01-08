using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Object Pool Info")]
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    [Tooltip("Objects that you want to create a Pool.")]
    public List<GameObject> objectsToPool;
    [Tooltip("How many instance of each object you want to store.")]
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        // For each objectToPool from the objectsToPool List
        foreach (GameObject objectToPool in objectsToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string objectTag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(objectTag))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
