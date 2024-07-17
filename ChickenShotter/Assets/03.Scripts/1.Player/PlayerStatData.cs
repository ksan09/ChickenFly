using UnityEngine;

[System.Serializable]
public struct PlayerStatData
{

    [Header("Normal Stat")]
    public float MaxHealth;         // ü��
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
    public float HitDamageAmountPer;    // �߰� �ǰ� ������%
    public float SkillCoolDownPer;      // ��ų ��ٿ�%
    public float LifeDrainPer;          // ����� ���%
    public float ExpPer;                // ����ġ ȹ��%
    public float GoldPer;               // ��� ȹ��%
    public float FallSpeedPer;          // �������� �ӵ� ( �����̱� �ѵ�.. Per�� �ֱ� �� ���ؼ� ���� �־�� )

    [Header("Level Stat")]
    public int ShotGunEgg;          // ����
    public int Through;             // ����
    public int Life;                // ��Ȱ


}