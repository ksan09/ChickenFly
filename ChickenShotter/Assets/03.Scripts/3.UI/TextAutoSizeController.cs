using TMPro;
using UnityEngine;

public class TextAutoSizeController : MonoBehaviour
{

    public TMP_Text[] TextObjects;
    public int FontMaxSize = 28;
    public int FontMinSize = 4;

    private void Awake()
    {
        SetAutoFontSize();
    }

    public void SetAutoFontSize()
    {
        if (TextObjects == null || TextObjects.Length == 0)
            return;

        // Iterate over each of the text objects in the array to find a good test candidate
        // There are different ways to figure out the best candidate
        // Preferred width works fine for single line text objects
        int candidateIndex = 0;
        float maxPreferredWidth = 0;

        for (int i = 0; i < TextObjects.Length; i++)
        {
            float preferredWidth = TextObjects[i].preferredWidth;
            if (preferredWidth > maxPreferredWidth)
            {
                maxPreferredWidth = preferredWidth;
                candidateIndex = i;
            }
        }

        // Force an update of the candidate text object so we can retrieve its optimum point size.
        TextObjects[candidateIndex].enableAutoSizing = true;
        TextObjects[candidateIndex].ForceMeshUpdate();
        float optimumPointSize = TextObjects[candidateIndex].fontSize;

        // Disable auto size on our test candidate
        TextObjects[candidateIndex].enableAutoSizing = false;

        // Iterate over all other text objects to set the point size
        for (int i = 0; i < TextObjects.Length; i++)
            TextObjects[i].fontSize = Mathf.Clamp(optimumPointSize, FontMinSize, FontMaxSize);
    }

}