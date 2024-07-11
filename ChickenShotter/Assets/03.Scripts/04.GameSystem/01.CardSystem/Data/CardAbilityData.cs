using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardAddStatInfo
{

    [Header("Normal Stat")]
    public float Health;            // 체력
    public float Strength;          // 공격력
    public float AttackSpeed;       // 초당 공격속도
    public float Defense;           // 방어력
    public float Speed;             // 속도
    public float Luck;              // 행운
    public float Digestion;         // 적 처치 시 회복량
    public float JumpPower;         // 점프 파워
    public float FallSpeed;         // 떨어지는 속도 ( 배율이긴 한데.. Per에 넣기 좀 뭐해서 여기 넣어둠 )
    public float Magnet;            // 자석
    public float FeverDuration;     // 피버 지속시간

    [Header("Per Stat")]
    public float StrengthPer;           // 공격력 증가%
    public float SkillCoolDownPer;      // 스킬 쿨다운%
    public float LifeDrainPer;          // 생명력 흡수%

    [Header("Level Stat")]
    public int ShotGunEgg;          // 샷건
    public int Through;             // 관통

}

[System.Serializable]
public class CardAbilityData
{

    [Header("Add Stat Data")]
    public CardAddStatInfo CardStatInfo;        // Card Stat Info

    [Header("Add Card Effect")]
    public List<CardEffectSO> CardEffectList;   // Random Effect

}
