using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    // A static reference to this object, so other scripts can access it
    // and we can check if an instance already exists.
    public static ScenePersist instance;

    void Awake()
    {
        // Check if an instance of this object already exists
        if (instance != null && instance != this)
        {
            // If it does, destroy this new object immediately.
            Destroy(this.gameObject);
            return; // Exit the function to prevent further code execution
        }

        // If no instance exists, set this one as the instance and make it persistent
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}



