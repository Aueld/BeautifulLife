using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ever : MonoBehaviour
{
    public Transform tile;

    private Vector3 startVec;

    private float timer = 0f;

    private void Start()
    {
        startVec = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z + 40);

        StartCoroutine(Updater());
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.playerHit) {}
            else
            {
                if (timer > 2.7f)
                {
                    Instantiate(tile.transform, startVec, Quaternion.identity).transform.parent = transform;
                    timer = 0f;
                }
                else
                {
                    if (MainManager.Instance.speed * MainManager.Instance.speedVal > 0.1f)
                        timer += 1f;
                    else if (MainManager.Instance.speed * MainManager.Instance.speedVal > 0.05f)
                        timer += 0.3f;
                    else
                        timer += 0.12f;
                }
            }
            if (MainManager.Instance.gameStop)
                yield return new WaitForSeconds(0.001f);
            else
                yield return MainManager.Instance.waitFrame;
        }
    }
}
