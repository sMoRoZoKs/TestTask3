using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameServices : MonoBehaviour
{
    public static GameServices instance;
    public CoordinatorController coordinateController;
    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        if(coordinateController == null)
        {
            coordinateController = new CoordinatorController();
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}