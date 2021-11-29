using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoop : MonoBehaviour
{
    private float speed = 0.04f;
    private float ofs;

    private void Start()
    {
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        while (true)
        {
            //Plane에 이미지파일 디폴트로 넣어야 작동

            ofs = speed * Time.time;
            
            transform.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-ofs, 0);

            yield return MainManager.Instance.waitFrame;
        }
    }
}
