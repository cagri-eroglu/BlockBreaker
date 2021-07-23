using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //Debug Purposes
    //cached references
    SceneLoader sceneLoader;
    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void DestroyBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

