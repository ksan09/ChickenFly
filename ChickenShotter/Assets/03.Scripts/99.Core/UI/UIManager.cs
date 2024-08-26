using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{

    Setting,
    SelectCard,
    GetCard

}

public class UIManager : MonoSingleton<UIManager>
{

    [Header("Panel")]
    [SerializeField] private IngamePanel _settingCardPanel;
    [SerializeField] private IngamePanel _selectCardPanel;
    [SerializeField] private IngamePanel _getCardPanel;

    [Header("Game Object")]
    [SerializeField] private GameObject _ingameController;

    private Dictionary<PanelType, IngamePanel> PanelDictionary;

    public override void Init()
    {

        // Panel Dictionary
        PanelDictionary = new Dictionary<PanelType, IngamePanel>()
        {

            { PanelType.Setting,        _settingCardPanel   },
            { PanelType.SelectCard,     _selectCardPanel    },
            { PanelType.GetCard,        _getCardPanel       },


        };

    }

    public void OpenPanel(PanelType type)
    {

        if (PanelDictionary.ContainsKey(type))
        {

            PanelDictionary[type].OnOpenTransition();
            PanelDictionary[type].OnOpenEvent();

            GameManager.Instance.ChangeGameMode(Chf_GameMode.OnlyUI);
            _ingameController.SetActive(false);

        }

    }

    public void ClosePanel(PanelType type)
    {

        if(PanelDictionary.ContainsKey(type))
        {

            PanelDictionary[type].OnCloseTransition();
            PanelDictionary[type].OnCloseEvent();

            GameManager.Instance.ChangeGameMode(Chf_GameMode.OnlyPlay);
            _ingameController.SetActive(true);

        }

    }

    public IngamePanel GetPanel(PanelType type)
    {

        if (PanelDictionary.ContainsKey(type))
        {

            return PanelDictionary[type];

        }

        return null;

    }

}
