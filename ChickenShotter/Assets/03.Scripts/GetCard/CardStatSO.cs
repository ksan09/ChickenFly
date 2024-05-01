using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "SO/CardStatSO")]
public class CardStatSO : ScriptableObject
{
    public Sprite CardSprite;
    public string CardName;
    public string CardExplain;

    [Header("Card Stat")]
    public int Money;           // 돈
    public float Speed;         // 속도
    public int Strength;        // 공격력
    public int Health;          // 체력 증가
    public int MultiShot;       // 멀티샷
    public int Pierce;          // 관통
    public float Ice;           // 얼음 효과
    public int Fire;            // 불 효과
    public float Electric;      // 전기 효과

    [Header("Skill")]
    public bool UseSkill;

    public Trigger SkillTrigger;
    public CardSkill CardSkill;         // 특정 트리거로 발생되는 스킬들
}
