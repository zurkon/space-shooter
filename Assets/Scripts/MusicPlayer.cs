using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Awake is called before anything else
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // GetType() gets this specific object's type (MusicPlayer)
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
