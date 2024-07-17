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
    public float CurseLuck;         // ����_���
    public float Digestion;         // �� óġ �� ȸ����
    public float JumpPower;         // ���� �Ŀ�
    public float Magnet;            // �ڼ�
    public float FeverDuration;     // �ǹ� ���ӽð�

    [Header("Per Stat")]
    public float StrengthPer;           // ���ݷ� ����%
    public float HitDamageAmountPer;    // �ǰ� ������%
    public float SkillCoolDownPer;      // ��ų ��ٿ�%
    public float LifeDrainPer;          // ����� ���%
    public float ExpPer;                // ����ġ ȹ��%
    public float GoldPer;               // ��� ȹ��%
    public float FallSpeedPer;         // �������� �ӵ� ( �����̱� �ѵ�.. Per�� �ֱ� �� ���ؼ� ���� �־�� )

    [Header("Level Stat")]
    public int ShotGunEgg;          // ����
    public int Through;             // ����
    public int Life;                // ��Ȱ

    public static CardAddStatInfo operator *(CardAddStatInfo cardAddStatInfo, int num)
    {

        return new CardAddStatInfo()
        {

            Health = cardAddStatInfo.Health * num,
            Strength = cardAddStatInfo.Strength * num,
            AttackSpeed = cardAddStatInfo.AttackSpeed * num,
            Defense = cardAddStatInfo.Defense * num,
            Speed = cardAddStatInfo.Speed * num,
            Luck = cardAddStatInfo.Luck * num,
            CurseLuck = cardAddStatInfo.CurseLuck * num,
            Digestion = cardAddStatInfo.Digestion * num,
            JumpPower = cardAddStatInfo.JumpPower * num,
            Magnet = cardAddStatInfo.Magnet * num,
            FeverDuration = cardAddStatInfo.FeverDuration * num,

            StrengthPer = cardAddStatInfo.StrengthPer * num,
            HitDamageAmountPer = cardAddStatInfo.HitDamageAmountPer * num,
            SkillCoolDownPer = cardAddStatInfo.SkillCoolDownPer * num,
            LifeDrainPer = cardAddStatInfo.LifeDrainPer * num,
            ExpPer = cardAddStatInfo.ExpPer * num,
            GoldPer = cardAddStatInfo.GoldPer * num,
            FallSpeedPer = cardAddStatInfo.FallSpeedPer * num,

            ShotGunEgg = cardAddStatInfo.ShotGunEgg * num,
            Through = cardAddStatInfo.Through * num,
            Life = cardAddStatInfo.Life * num

        };

    }

}

[System.Serializable]
public class CardAbilityData
{

    [Header("Add Stat Data")]
    public CardAddStatInfo CardStatInfo;        // Card Stat Info

    [Header("Add Card Effect")]
    public List<CardEffectSO> CardEffectList;   // Random Effect

}
