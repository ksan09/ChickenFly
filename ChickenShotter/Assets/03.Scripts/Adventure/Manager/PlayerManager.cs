using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    [field: SerializeField]
    public int Money { get; set; } = 0;
    [field: SerializeField]
    public float PlayerSpeed { get; set; } = 5;
    [field: SerializeField]
    public int PlayerStrength { get; set; } = 8;
    [field: SerializeField]
    public int PlayerMaxHealth { get; set; } = 8;
    [field: SerializeField]
    public int PlayerCurrentHealth { get; set; } = 8;
    [field: SerializeField]
    public int PlayerBulletNum { get; set; } = 1;
    [field: SerializeField]
    public int Pierce { get; set; } = 1;
    [field: SerializeField]
    public float Ice { get; set; } = 0;
    [field: SerializeField]
    public int Fire { get; set; } = 0;
    [field: SerializeField]
    public float Electric { get; set; } = 0;
    
    public void ResetPlayer()
    {
        Money = 0;
        PlayerSpeed = 5;
        PlayerStrength = 8;
        PlayerMaxHealth = 8;
        PlayerCurrentHealth = 8;
        PlayerBulletNum = 1;
        Pierce = 1;
        Ice = 0;
        Fire = 0;
        Electric = 0;
    }

}
