using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : LoadExcelTable
{
    protected Vector3 pivot;
    protected float speed = 0.04f;

    void Start()
    {
        pivot = new Vector3(transform.position.x, transform.position.y - 300f, transform.position.z);

        StartCoroutine(Updater(gameObject));
    }

    protected IEnumerator Updater(GameObject obj)
    {
        while (true)
        {
            speed = MainManager.Instance.speed * MainManager.Instance.speedVal;

            if (MainManager.Instance.stageChange || MainManager.Instance.gameOver)
            {
                yield return MainManager.Instance.waitFrame;
            }
            else
            {
                if (transform.position.z < -10)
                {
                    Destroy(obj.gameObject);
                }
                else
                {
                    if (MainManager.Instance.playerHit)
                        obj.transform.RotateAround(pivot, Vector3.left, -1 * speed);
                    else
                        obj.transform.RotateAround(pivot, Vector3.left, speed);
                }

                if (MainManager.Instance.gameStop)
                    yield return new WaitForSeconds(0.001f);
                else
                    yield return MainManager.Instance.waitFrame;
            }
        }
    }
}
