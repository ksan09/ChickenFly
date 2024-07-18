using System.Collections;
using TMPro;
using UnityEngine;

public class WobblyText : MonoBehaviour
{

    private TMP_Text _text;
    private TMP_TextInfo _textInfo;

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _strength = 10f;
    [SerializeField] private float _charDist = 0.01f;


    private void Awake()
    {

        _text = GetComponent<TMP_Text>();
        _textInfo = _text.textInfo;

    }

    // Update is called once per frame
    void Update()
    {
        
        _text.ForceMeshUpdate();
        
        for(int i = 0; i < _textInfo.characterCount; ++i)
        {

            var charInfo = _textInfo.characterInfo[i];

            if (!charInfo.isVisible)    // Visible Check
                continue;

            var vertices = _textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;    // 해당 문자 버텍스 정보 가져오기
            float firstX = vertices[charInfo.vertexIndex].x;

            for(int j = 0; j < 4; ++j)
            {

                Vector3 origin = vertices[charInfo.vertexIndex + j];
                vertices[charInfo.vertexIndex + j] = origin + new Vector3(0, Mathf.Sin(Time.time * _speed + firstX * _charDist) * _strength, 0);

            }


        }

        for (int i = 0; i < _textInfo.meshInfo.Length; ++i)
        {

            var meshInfo = _textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _text.UpdateGeometry(meshInfo.mesh, i);

        }


    }
}
