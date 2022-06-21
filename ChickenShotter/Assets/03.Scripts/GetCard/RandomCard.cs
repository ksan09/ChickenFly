using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum State
{
    ThickEgg = 0,
    DangerEggBox = 1,
    MoneyBox = 2,
    MaxHpUp = 3,
    HeavyHeart = 4,
    HeavyWings = 5,
    QuantityOverQuality = 6,
    Fire = 7,
    Ice = 8,
    Electric = 9,
    BigMoneyCrate = 10,
    Obesity = 11,
    EggBox = 12,
    StrongPower = 13,
    QuickAndSharp = 14,
    FastWings = 15,
    HeavyEgg = 16,
    SharpEgg = 17,
    DangerMoneyCrate = 18,
    SuperDangerEggBox = 19,
    QuickWings = 20,
    ThornEgg = 21

}

public class RandomCard : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _cardTxt;
    [SerializeField] private TextMeshProUGUI _cardTxt2;
    [SerializeField] private TextMeshProUGUI _cardTxt3;
    [SerializeField] private TextMeshProUGUI _cardExplain;
    [SerializeField] private TextMeshProUGUI _cardExplain2;
    [SerializeField] private TextMeshProUGUI _cardExplain3;
    private State _cardState;
    private State _cardState2;
    private State _cardState3;
    public State CardState { get { return _cardState; } set { _cardState = value; } }
    public State CardState2 { get { return _cardState2; } set { _cardState2 = value; } }
    public State CardState3 { get { return _cardState3; } set { _cardState3 = value; } }
    

    // Start is called before the first frame update
    void Awake()
    {
        SetCard(_cardTxt, _cardState, _cardExplain, 1);
        SetCard(_cardTxt2, _cardState2, _cardExplain2, 2);
        SetCard(_cardTxt3, _cardState3, _cardExplain3, 3);
    }

    private void SetCard(TextMeshProUGUI _cardTxt, State _state, TextMeshProUGUI _cardExplain, int a)
    {
        bool repeat = true;
        while(repeat)
        {
            float per = Random.Range(1f, 100f);
            if (per <= 7)
            {
                //�β��� źȯ ( ���ݷ� + 3 )
                _state = State.ThickEgg;
                _cardTxt.text = "Thick Egg";
                _cardExplain.text = "power 3";
                repeat = false;
            }
            else if (per <= 14)
            {
                //������ źȯ ���� ( źȯ + 1, ü�� - 1 ) ����ü�� 2�̻�
                _state = State.DangerEggBox;
                _cardTxt.text = "Danger Egg Box";
                _cardExplain.text = "egg 1, hp -1";
                repeat = false;
            }
            else if (per <= 21)
            {
                //�� ���� ( �� + 300 )
                _state = State.MoneyBox;
                _cardTxt.text = "Money Box";
                _cardExplain.text = "money 300";
                repeat = false;
            }
            else if (per <= 28)
            {
                //���� ( �ִ�ü�� + 1 )
                _state = State.MaxHpUp;
                _cardTxt.text = "MAX HP UP";
                _cardExplain.text = "max hp 1";
                repeat = false;
            }
            else if (per <= 35)
            {
                //���ſ� ���� ( �̼� ���� - 0.5, �ִ�ü�� + 1 ) �̼� 1�̻�
                _state = State.HeavyHeart;
                _cardTxt.text = "Heavy Heart";
                _cardExplain.text = "speed -0.5 max hp 1";
                repeat = false;
            }
            else if (per <= 42)
            {
                //���ſ� ���� ( �̼� ���� - 0.5, ü�� + 2 ) �̼� 1�̻�
                _state = State.HeavyWings;
                _cardTxt.text = "Heavy Wings";
                _cardExplain.text = "speed -0.5 hp 2";
                repeat = false;
            }
            else if (per <= 49)
            {
                //������ �� ( źȯ + 1, ������ - 3 ) ���� ������ 5�̻�
                _state = State.QuantityOverQuality;
                _cardTxt.text = "Quantity Over Quality!";
                _cardExplain.text = "egg 1 power - 3";
                repeat = false;
            }
            else if (per <= 56)
            {
                //ȭ�� ī�� ( ȭ�� + 1 )
                _state = State.Fire;
                _cardTxt.text = "Fire";
                _cardExplain.text = "fire 1";
                repeat = false;
            }
            else if (per <= 63)
            {
                //���� ī�� ( ���� + 1 )
                _state = State.Ice;
                _cardTxt.text = "Ice";
                _cardExplain.text = "ice 1";
                repeat = false;
            }
            else if (per <= 70)
            {
                //���� ī�� ( ���� + 1 )
                _state = State.Electric;
                _cardTxt.text = "Electric";
                _cardExplain.text = "electric 1";
                repeat = false;
            }
            else if (per <= 73)
            {
                //�Ŵ��� �� ���� ( �� + 500 )
                _state = State.BigMoneyCrate;
                _cardTxt.text = "Big Money Crate";
                _cardExplain.text = "money 500";
                repeat = false;
            }
            else if (per <= 76)
            {
                //�� ( ü�� +3, ������ ?5 ) ���� ������ 10�̻�
                _state = State.Obesity;
                _cardTxt.text = "Obesity";
                _cardExplain.text = "hp 3 power -5";
                repeat = false;
            }
            else if (per <= 79)
            {
                //źȯ ���� ( źȯ + 1 )
                _state = State.EggBox;
                _cardTxt.text = "Egg Box";
                _cardExplain.text = "egg 1";
                repeat = false;
            }
            else if (per <= 82)
            {
                //������ �� ( ���ݷ� + 8 �ִ�ü�� - 1 ) �ִ�ü�� 2�̻� ü�� 2�̻�
                _state = State.StrongPower;
                _cardTxt.text = "Strong Power!!!";
                _cardExplain.text = "power 8 max hp -1";
                repeat = false;
            }
            else if (per <= 85)
            {
                //������� ��ī�Ӱ� ( �̼� ���� + 0.5, ���� + 1 )
                _state = State.QuickAndSharp;
                _cardTxt.text = "Quick And Sharp!";
                _cardExplain.text = "speed 0.5 penetration 1";
                repeat = false;
            }
            else if (per <= 88)
            {
                //���� ���� ( �̼� ���� + 0.5 )
                _state = State.FastWings;
                _cardTxt.text = "Fast Wings";
                _cardExplain.text = "speed 0.5";
                repeat = false;
            }
            else if (per <= 90)
            {
                //���ſ� źȯ ( ���ݷ� + 8, �̼� ���� - 0,5 ) �̼� 1�̻�
                _state = State.HeavyEgg;
                _cardTxt.text = "Heavy Egg";
                _cardExplain.text = "power 8 speed -0.5";
                repeat = false;
            }
            else if (per <= 92)
            {
                //��ī�ο� źȯ ( ���� + 1, ������ + 2 )
                _state = State.SharpEgg;
                _cardTxt.text = "Sharp Egg";
                _cardExplain.text = "penetration 1 power 2";
                repeat = false;
            }
            else if (per <= 94)
            {
                //������ �� ���� ( ü�� - 1, �� + 1500 ) ���� : ����ü�� 2�̻�
                _state = State.DangerMoneyCrate;
                _cardTxt.text = "Danger Money Crate";
                _cardExplain.text = "hp -1 money 1500";
                repeat = false;
            }
            else if (per <= 96)
            {
                //������ ź�� ���� ( ź�� ���� ���� +2, ü�� - 2 ) ���� : ����ü�� 3�̻�
                _state = State.SuperDangerEggBox;
                _cardTxt.text = "Super Danger Egg Box";
                _cardExplain.text = "egg 2 hp -2";
                repeat = false;
            }
            else if (per <= 98)
            {
                //����� ���� ( �̼� ���� + 1 )
                _state = State.QuickWings;
                _cardTxt.text = "Quick Wings";
                _cardExplain.text = "speed 1";
                repeat = false;
            }
            else
            {
                //���� źȯ ( ü�� - 1, źȯ + 1, ������ + 2 ) ���� ����ü�� 2�̻�
                _state = State.ThornEgg;
                _cardTxt.text = "Thorn Egg";
                _cardExplain.text = "hp -1 egg 1 power 2";
                repeat = false;
            }
        }
        switch(a)
        {
            case 1:
                _cardState = _state;
                break;
            case 2:
                _cardState2 = _state;
                break;
            case 3:
                _cardState3 = _state;
                break;
            default:
                break;
        }
    }
}
