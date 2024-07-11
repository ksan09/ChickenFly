using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;

            if(instance == null)
            {
                instance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    Debug.LogError($"! - {typeof(T).Name} is Too Many");
                }

            }

            if(instance != null)
            {
                instance.Init();
                return instance;
            }

            return null;
        }
    }

    public virtual void Init()
    {

    }

    private void OnValidate()
    {
        name = this.GetType().Name;
    }
}
