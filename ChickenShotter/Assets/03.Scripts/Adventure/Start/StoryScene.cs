using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StoryScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doTxt;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartStory());
    }
    private void Update()
    {
        Skip();
    }
    private void Skip()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Play");
        }
    }

    IEnumerator StartStory()
    {
        DoText(doTxt," 어느 닭이 있었습니다 ",1);
        yield return new WaitForSeconds(3f);
        DoText(doTxt, " 닭은 하늘의 최강자가 되고 싶었기에 ", 1);
        yield return new WaitForSeconds(3f);
        DoText(doTxt, " 자신의 달걀을 무기로 ", 1);
        yield return new WaitForSeconds(3f);
        DoText(doTxt, " 여행을 떠나기로 했습니다 ", 1);
        yield return new WaitForSeconds(3f);
        DoText(doTxt, " 과연 이 닭은 하늘의 최강자가 될 수 있을까요 ", 1);
        yield return new WaitForSeconds(3f);
        DoText(doTxt, " 닭 날다 ", 3);
        player.transform.DOMoveY(5, 5);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Play");

    }
    public static void DoText(TextMeshProUGUI a_text, string txt ,float a_duration)
    {
        a_text.text = txt;
        a_text.maxVisibleCharacters = 0;
        DOTween.To(x => a_text.maxVisibleCharacters = (int)x, 0f, a_text.text.Length, 2f);
    }
}
