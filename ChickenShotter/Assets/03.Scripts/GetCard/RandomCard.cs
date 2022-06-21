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
                //두꺼운 탄환 ( 공격력 + 3 )
                _state = State.ThickEgg;
                _cardTxt.text = "Thick Egg";
                _cardExplain.text = "power 3";
                repeat = false;
            }
            else if (per <= 14)
            {
                //위험한 탄환 상자 ( 탄환 + 1, 체력 - 1 ) 현재체력 2이상
                _state = State.DangerEggBox;
                _cardTxt.text = "Danger Egg Box";
                _cardExplain.text = "egg 1, hp -1";
                repeat = false;
            }
            else if (per <= 21)
            {
                //돈 상자 ( 돈 + 300 )
                _state = State.MoneyBox;
                _cardTxt.text = "Money Box";
                _cardExplain.text = "money 300";
                repeat = false;
            }
            else if (per <= 28)
            {
                //심장 ( 최대체력 + 1 )
                _state = State.MaxHpUp;
                _cardTxt.text = "MAX HP UP";
                _cardExplain.text = "max hp 1";
                repeat = false;
            }
            else if (per <= 35)
            {
                //무거운 심장 ( 이속 감소 - 0.5, 최대체력 + 1 ) 이속 1이상
                _state = State.HeavyHeart;
                _cardTxt.text = "Heavy Heart";
                _cardExplain.text = "speed -0.5 max hp 1";
                repeat = false;
            }
            else if (per <= 42)
            {
                //무거운 날개 ( 이속 감소 - 0.5, 체력 + 2 ) 이속 1이상
                _state = State.HeavyWings;
                _cardTxt.text = "Heavy Wings";
                _cardExplain.text = "speed -0.5 hp 2";
                repeat = false;
            }
            else if (per <= 49)
            {
                //질보단 양 ( 탄환 + 1, 데미지 - 3 ) 조건 데미지 5이상
                _state = State.QuantityOverQuality;
                _cardTxt.text = "Quantity Over Quality!";
                _cardExplain.text = "egg 1 power - 3";
                repeat = false;
            }
            else if (per <= 56)
            {
                //화염 카드 ( 화염 + 1 )
                _state = State.Fire;
                _cardTxt.text = "Fire";
                _cardExplain.text = "fire 1";
                repeat = false;
            }
            else if (per <= 63)
            {
                //얼음 카드 ( 얼음 + 1 )
                _state = State.Ice;
                _cardTxt.text = "Ice";
                _cardExplain.text = "ice 1";
                repeat = false;
            }
            else if (per <= 70)
            {
                //전기 카드 ( 전기 + 1 )
                _state = State.Electric;
                _cardTxt.text = "Electric";
                _cardExplain.text = "electric 1";
                repeat = false;
            }
            else if (per <= 73)
            {
                //거대한 돈 상자 ( 돈 + 500 )
                _state = State.BigMoneyCrate;
                _cardTxt.text = "Big Money Crate";
                _cardExplain.text = "money 500";
                repeat = false;
            }
            else if (per <= 76)
            {
                //비만 ( 체력 +3, 데미지 ?5 ) 조건 데미지 10이상
                _state = State.Obesity;
                _cardTxt.text = "Obesity";
                _cardExplain.text = "hp 3 power -5";
                repeat = false;
            }
            else if (per <= 79)
            {
                //탄환 상자 ( 탄환 + 1 )
                _state = State.EggBox;
                _cardTxt.text = "Egg Box";
                _cardExplain.text = "egg 1";
                repeat = false;
            }
            else if (per <= 82)
            {
                //강력한 힘 ( 공격력 + 8 최대체력 - 1 ) 최대체력 2이상 체력 2이상
                _state = State.StrongPower;
                _cardTxt.text = "Strong Power!!!";
                _cardExplain.text = "power 8 max hp -1";
                repeat = false;
            }
            else if (per <= 85)
            {
                //재빠르고 날카롭게 ( 이속 증가 + 0.5, 관통 + 1 )
                _state = State.QuickAndSharp;
                _cardTxt.text = "Quick And Sharp!";
                _cardExplain.text = "speed 0.5 penetration 1";
                repeat = false;
            }
            else if (per <= 88)
            {
                //빠른 날개 ( 이속 증가 + 0.5 )
                _state = State.FastWings;
                _cardTxt.text = "Fast Wings";
                _cardExplain.text = "speed 0.5";
                repeat = false;
            }
            else if (per <= 90)
            {
                //무거운 탄환 ( 공격력 + 8, 이속 감소 - 0,5 ) 이속 1이상
                _state = State.HeavyEgg;
                _cardTxt.text = "Heavy Egg";
                _cardExplain.text = "power 8 speed -0.5";
                repeat = false;
            }
            else if (per <= 92)
            {
                //날카로운 탄환 ( 관통 + 1, 데미지 + 2 )
                _state = State.SharpEgg;
                _cardTxt.text = "Sharp Egg";
                _cardExplain.text = "penetration 1 power 2";
                repeat = false;
            }
            else if (per <= 94)
            {
                //위험한 돈 상자 ( 체력 - 1, 돈 + 1500 ) 조건 : 현재체력 2이상
                _state = State.DangerMoneyCrate;
                _cardTxt.text = "Danger Money Crate";
                _cardExplain.text = "hp -1 money 1500";
                repeat = false;
            }
            else if (per <= 96)
            {
                //위험한 탄알 상자 ( 탄알 갯수 증가 +2, 체력 - 2 ) 조건 : 현재체력 3이상
                _state = State.SuperDangerEggBox;
                _cardTxt.text = "Super Danger Egg Box";
                _cardExplain.text = "egg 2 hp -2";
                repeat = false;
            }
            else if (per <= 98)
            {
                //재빠른 날개 ( 이속 증가 + 1 )
                _state = State.QuickWings;
                _cardTxt.text = "Quick Wings";
                _cardExplain.text = "speed 1";
                repeat = false;
            }
            else
            {
                //가시 탄환 ( 체력 - 1, 탄환 + 1, 데미지 + 2 ) 조건 현재체력 2이상
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
