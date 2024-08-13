using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeText : MonoBehaviour
{


    private TMP_Text _text;
    private TMP_TextInfo _textInfo;

    [SerializeField] private float _strength = 5f;
    [SerializeField] private float _interval = 0.1f;

    WaitForSecondsRealtime _wfsWaitInterval;

    private void Awake()
    {

        _text = GetComponent<TMP_Text>();
        _textInfo = _text.textInfo;

        _wfsWaitInterval = new WaitForSecondsRealtime(_interval);

    }

    private void OnEnable()
    {

        StartCoroutine(ShakeCo());

    }

    IEnumerator ShakeCo()
    {

        while(true)
        {
            _text.ForceMeshUpdate();

            for (int i = 0; i < _textInfo.characterCount; ++i)
            {

                var charInfo = _textInfo.characterInfo[i];

                if (!charInfo.isVisible)    // Visible Check
                    continue;

                var vertices = _textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;    // 해당 문자 버텍스 정보 가져오기
                float value = Random.Range(0f, Mathf.PI * 2);

                for (int j = 0; j < 4; ++j)
                {

                    Vector3 origin = vertices[charInfo.vertexIndex + j];
                    vertices[charInfo.vertexIndex + j] = origin + new Vector3(Mathf.Cos(value) * _strength, Mathf.Sin(value) * _strength, 0);

                }


            }

            for (int i = 0; i < _textInfo.meshInfo.Length; ++i)
            {

                var meshInfo = _textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                _text.UpdateGeometry(meshInfo.mesh, i);

            }

            yield return _wfsWaitInterval;
        }
    }

}
