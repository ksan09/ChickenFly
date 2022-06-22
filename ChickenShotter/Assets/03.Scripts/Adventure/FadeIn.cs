using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.black;
        Fading();
    }

    private void Fading()
    {
        image.DOFade(0, 2f);
    }
}
