using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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
    [SerializeField] private GameObject panel;
    private State _cardState;
    private State _cardState2;
    private State _cardState3;
    public State CardState { get { return _cardState; } set { _cardState = value; } }
    public State CardState2 { get { return _cardState2; } set { _cardState2 = value; } }
    public State CardState3 { get { return _cardState3; } set { _cardState3 = value; } }
    

    // Start is called before the first frame update
    void Awake()
    {
        panel.transform.DOMoveY(540, 2f);
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
                _cardTxt.text = "두꺼운 달걀";
                _cardExplain.text = "공격력 3";
                repeat = false;
            }
            else if (per <= 14)
            {
                //위험한 탄환 상자 ( 탄환 + 1, 체력 - 1 ) 현재체력 2이상
                _state = State.DangerEggBox;
                _cardTxt.text = "가시달린 달걀 상자";
                _cardExplain.text = "탄알 수 1, 체력감소 1";
                repeat = false;
            }
            else if (per <= 21)
            {
                //돈 상자 ( 돈 + 300 )
                _state = State.MoneyBox;
                _cardTxt.text = "돈 상자";
                _cardExplain.text = "돈 300";
                repeat = false;
            }
            else if (per <= 28)
            {
                //심장 ( 최대체력 + 1 )
                _state = State.MaxHpUp;
                _cardTxt.text = "MAX HP UP!";
                _cardExplain.text = "최대 체력 1";
                repeat = false;
            }
            else if (per <= 35)
            {
                //무거운 심장 ( 이속 감소 - 0.5, 최대체력 + 1 ) 이속 1이상
                _state = State.HeavyHeart;
                _cardTxt.text = "무거운 심장";
                _cardExplain.text = "속도 -0.5 최대체력 1";
                repeat = false;
            }
            else if (per <= 42)
            {
                //무거운 날개 ( 이속 감소 - 0.5, 체력 + 2 ) 이속 1이상
                _state = State.HeavyWings;
                _cardTxt.text = "무거운 날개";
                _cardExplain.text = "속도 -0.5 체력 회복 2";
                repeat = false;
            }
            else if (per <= 49)
            {
                //질보단 양 ( 탄환 + 1, 데미지 - 3 ) 조건 데미지 5이상
                _state = State.QuantityOverQuality;
                _cardTxt.text = "질보다 양!";
                _cardExplain.text = "탄환 수 1 공격력 - 3";
                repeat = false;
            }
            else if (per <= 56)
            {
                //화염 카드 ( 화염 + 1 )
                _state = State.Fire;
                _cardTxt.text = "화염";
                _cardExplain.text = "불 속성 1";
                repeat = false;
            }
            else if (per <= 63)
            {
                //얼음 카드 ( 얼음 + 1 )
                _state = State.Ice;
                _cardTxt.text = "얼음";
                _cardExplain.text = "얼음 속성 1";
                repeat = false;
            }
            else if (per <= 70)
            {
                //전기 카드 ( 전기 + 1 )
                _state = State.Electric;
                _cardTxt.text = "전기";
                _cardExplain.text = "전기 속성 1";
                repeat = false;
            }
            else if (per <= 73)
            {
                //거대한 돈 상자 ( 돈 + 500 )
                _state = State.BigMoneyCrate;
                _cardTxt.text = "거대한 돈 상자";
                _cardExplain.text = "돈 500";
                repeat = false;
            }
            else if (per <= 76)
            {
                //비만 ( 체력 +3, 데미지 ?5 ) 조건 데미지 10이상
                _state = State.Obesity;
                _cardTxt.text = "비만";
                _cardExplain.text = "체력 회복 3 공격력 -3";
                repeat = false;
            }
            else if (per <= 79)
            {
                //탄환 상자 ( 탄환 + 1 )
                _state = State.EggBox;
                _cardTxt.text = "달걀 상자";
                _cardExplain.text = "탄환 수 1";
                repeat = false;
            }
            else if (per <= 82)
            {
                //강력한 힘 ( 공격력 + 8 최대체력 - 1 ) 최대체력 2이상 체력 2이상
                _state = State.StrongPower;
                _cardTxt.text = "강력한 힘!!";
                _cardExplain.text = "공격력 8 최대체력감소 1";
                repeat = false;
            }
            else if (per <= 85)
            {
                //재빠르고 날카롭게 ( 이속 증가 + 0.5, 관통 + 1 )
                _state = State.QuickAndSharp;
                _cardTxt.text = "재빠르고 날카롭게!";
                _cardExplain.text = "속도 0.5 관통 1";
                repeat = false;
            }
            else if (per <= 88)
            {
                //빠른 날개 ( 이속 증가 + 0.5 )
                _state = State.FastWings;
                _cardTxt.text = "빠른 날개";
                _cardExplain.text = "속도 0.5";
                repeat = false;
            }
            else if (per <= 90)
            {
                //무거운 탄환 ( 공격력 + 8, 이속 감소 - 0,5 ) 이속 1이상
                _state = State.HeavyEgg;
                _cardTxt.text = "무거운 탄환";
                _cardExplain.text = "공격력 8 속도 -0.5";
                repeat = false;
            }
            else if (per <= 92)
            {
                //날카로운 탄환 ( 관통 + 1, 데미지 + 2 )
                _state = State.SharpEgg;
                _cardTxt.text = "날카로운 탄환";
                _cardExplain.text = "관통 1 공격력 2";
                repeat = false;
            }
            else if (per <= 94)
            {
                //위험한 돈 상자 ( 체력 - 1, 돈 + 1500 ) 조건 : 현재체력 2이상
                _state = State.DangerMoneyCrate;
                _cardTxt.text = "가시달린 돈 상자";
                _cardExplain.text = "체력감소 1 돈 1500";
                repeat = false;
            }
            else if (per <= 96)
            {
                //위험한 탄알 상자 ( 탄알 갯수 증가 +2, 체력 - 2 ) 조건 : 현재체력 3이상
                _state = State.SuperDangerEggBox;
                _cardTxt.text = "가시달린 큰 달걀 상자";
                _cardExplain.text = "탄환 수 2 체력감소 2";
                repeat = false;
            }
            else if (per <= 98)
            {
                //재빠른 날개 ( 이속 증가 + 1 )
                _state = State.QuickWings;
                _cardTxt.text = "재빠른 날개";
                _cardExplain.text = "속도 1";
                repeat = false;
            }
            else
            {
                //가시 탄환 ( 체력 - 1, 탄환 + 1, 데미지 + 2 ) 조건 현재체력 2이상
                _state = State.ThornEgg;
                _cardTxt.text = "가시달린 달걀";
                _cardExplain.text = "체력감소 1 탄환 수 1 공격력 2";
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
