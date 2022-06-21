using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    RandomCard rc;
    private void Awake()
    {
        rc = GetComponent<RandomCard>();
    }
    public void CardClick()
    {
        Debug.Log(rc.CardState);
        switch(rc.CardState)
        {
            case State.ThickEgg:
                PlayerManager.Instance.PlayerStrength += 3;
                break;
            case State.DangerEggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                break;
            case State.MoneyBox:
                PlayerManager.Instance.Money += 300;
                break;
            case State.MaxHpUp:
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyHeart:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyWings:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerCurrentHealth += 2;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuantityOverQuality:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerStrength -= 3;
                break;
            case State.Fire:
                PlayerManager.Instance.Fire += 1;
                break;
            case State.Ice:
                PlayerManager.Instance.Ice += 1;
                break;
            case State.Electric:
                PlayerManager.Instance.Electric += 1;
                break;
            case State.BigMoneyCrate:
                PlayerManager.Instance.Money += 500;
                break;
            case State.Obesity:
                PlayerManager.Instance.PlayerCurrentHealth += 3;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.EggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                break;
            case State.StrongPower:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerMaxHealth -= 1;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuickAndSharp:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.FastWings:
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.HeavyEgg:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                break;
            case State.SharpEgg:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            case State.DangerMoneyCrate:
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.Money += 1500;
                break;
            case State.SuperDangerEggBox:
                PlayerManager.Instance.PlayerCurrentHealth -= 2;
                PlayerManager.Instance.PlayerBulletNum += 2;
                break;
            case State.QuickWings:
                PlayerManager.Instance.PlayerSpeed += 1f;
                break;
            case State.ThornEgg:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            default:
                break;
        }
        SceneManager.LoadScene("Play");
    }
    public void CardClick2()
    {
        switch (rc.CardState2)
        {
            case State.ThickEgg:
                PlayerManager.Instance.PlayerStrength += 3;
                break;
            case State.DangerEggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                break;
            case State.MoneyBox:
                PlayerManager.Instance.Money += 300;
                break;
            case State.MaxHpUp:
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyHeart:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyWings:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerCurrentHealth += 2;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuantityOverQuality:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerStrength -= 3;
                break;
            case State.Fire:
                PlayerManager.Instance.Fire += 1;
                break;
            case State.Ice:
                PlayerManager.Instance.Ice += 1;
                break;
            case State.Electric:
                PlayerManager.Instance.Electric += 1;
                break;
            case State.BigMoneyCrate:
                PlayerManager.Instance.Money += 500;
                break;
            case State.Obesity:
                PlayerManager.Instance.PlayerCurrentHealth += 3;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.EggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                break;
            case State.StrongPower:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerMaxHealth -= 1;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuickAndSharp:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.FastWings:
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.HeavyEgg:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                break;
            case State.SharpEgg:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            case State.DangerMoneyCrate:
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.Money += 1500;
                break;
            case State.SuperDangerEggBox:
                PlayerManager.Instance.PlayerCurrentHealth -= 2;
                PlayerManager.Instance.PlayerBulletNum += 2;
                break;
            case State.QuickWings:
                PlayerManager.Instance.PlayerSpeed += 1f;
                break;
            case State.ThornEgg:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            default:
                break;
        }
        SceneManager.LoadScene("Play");
    }
    public void CardClick3()
    {
        switch (rc.CardState3)
        {
            case State.ThickEgg:
                PlayerManager.Instance.PlayerStrength += 3;
                break;
            case State.DangerEggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                break;
            case State.MoneyBox:
                PlayerManager.Instance.Money += 300;
                break;
            case State.MaxHpUp:
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyHeart:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerMaxHealth += 1;
                PlayerManager.Instance.PlayerCurrentHealth += 1;
                break;
            case State.HeavyWings:
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                PlayerManager.Instance.PlayerCurrentHealth += 2;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuantityOverQuality:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerStrength -= 3;
                break;
            case State.Fire:
                PlayerManager.Instance.Fire += 1;
                break;
            case State.Ice:
                PlayerManager.Instance.Ice += 1;
                break;
            case State.Electric:
                PlayerManager.Instance.Electric += 1;
                break;
            case State.BigMoneyCrate:
                PlayerManager.Instance.Money += 500;
                break;
            case State.Obesity:
                PlayerManager.Instance.PlayerCurrentHealth += 3;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.EggBox:
                PlayerManager.Instance.PlayerBulletNum += 1;
                break;
            case State.StrongPower:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerMaxHealth -= 1;
                PlayerManager.Instance.PlayerCurrentHealth = Mathf.Clamp(PlayerManager.Instance.PlayerCurrentHealth, 0, PlayerManager.Instance.PlayerMaxHealth);
                break;
            case State.QuickAndSharp:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.FastWings:
                PlayerManager.Instance.PlayerSpeed += 0.5f;
                break;
            case State.HeavyEgg:
                PlayerManager.Instance.PlayerStrength += 8;
                PlayerManager.Instance.PlayerSpeed -= 0.5f;
                break;
            case State.SharpEgg:
                PlayerManager.Instance.Pierce += 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            case State.DangerMoneyCrate:
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.Money += 1500;
                break;
            case State.SuperDangerEggBox:
                PlayerManager.Instance.PlayerCurrentHealth -= 2;
                PlayerManager.Instance.PlayerBulletNum += 2;
                break;
            case State.QuickWings:
                PlayerManager.Instance.PlayerSpeed += 1f;
                break;
            case State.ThornEgg:
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerCurrentHealth -= 1;
                PlayerManager.Instance.PlayerStrength += 2;
                break;
            default:
                break;
        }
        SceneManager.LoadScene("Play");
    }
}
