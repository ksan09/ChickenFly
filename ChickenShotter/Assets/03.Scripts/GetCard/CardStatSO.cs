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
    public int Money;           // ��
    public float Speed;         // �ӵ�
    public int Strength;        // ���ݷ�
    public int Health;          // ü�� ����
    public int MultiShot;       // ��Ƽ��
    public int Pierce;          // ����
    public float Ice;           // ���� ȿ��
    public int Fire;            // �� ȿ��
    public float Electric;      // ���� ȿ��

    [Header("Skill")]
    public bool UseSkill;

    public Trigger SkillTrigger;
    public CardSkill CardSkill;         // Ư�� Ʈ���ŷ� �߻��Ǵ� ��ų��
}
