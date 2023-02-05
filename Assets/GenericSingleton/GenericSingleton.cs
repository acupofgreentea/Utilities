using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    public static GenericSingleton<T> Instance { get; private set; }
	
    public virtual void Awake ()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}

