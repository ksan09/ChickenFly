using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardAddStatInfo
{

    [Header("Normal Stat")]
    public float Health;            // ü��
    public float Strength;          // ���ݷ�
    public float AttackSpeed;       // �ʴ� ���ݼӵ�
    public float Defense;           // ����
    public float Speed;             // �ӵ�
    public float Luck;              // ���
    public float Digestion;         // �� óġ �� ȸ����
    public float JumpPower;         // ���� �Ŀ�
    public float FallSpeed;         // �������� �ӵ� ( �����̱� �ѵ�.. Per�� �ֱ� �� ���ؼ� ���� �־�� )
    public float Magnet;            // �ڼ�
    public float FeverDuration;     // �ǹ� ���ӽð�

    [Header("Per Stat")]
    public float StrengthPer;           // ���ݷ� ����%
    public float SkillCoolDownPer;      // ��ų ��ٿ�%
    public float LifeDrainPer;          // ����� ���%

    [Header("Level Stat")]
    public int ShotGunEgg;          // ����
    public int Through;             // ����

}

[System.Serializable]
public class CardAbilityData
{

    [Header("Add Stat Data")]
    public CardAddStatInfo CardStatInfo;        // Card Stat Info

    [Header("Add Card Effect")]
    public List<CardEffectSO> CardEffectList;   // Random Effect

}
