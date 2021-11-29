using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeMov : ObjectMove
{
    //private Vector3 pivot;
    //private float speed = 0.04f;

    private void Start()
    {
        pivot = new Vector3(transform.position.x, transform.position.y - 300f, transform.position.z);

        StartCoroutine(Updater(gameObject));
    }

    //private IEnumerator Updater()
    //{
    //    while (true)
    //    {
    //        speed = MainManager.Instance.speed * MainManager.Instance.speedVal;

    //        if (MainManager.Instance.stageChange)
    //        {
    //            yield return MainManager.Instance.waitFrame;
    //        }
    //        else
    //        {
    //            if (transform.position.z < -10)
    //            {
    //                Destroy(gameObject);
    //            }
    //            else
    //            {
    //                if (MainManager.Instance.playerHit)
    //                    transform.RotateAround(pivot, Vector3.left, -1 * speed);
    //                else
    //                    transform.RotateAround(pivot, Vector3.left, speed);
    //            }

    //            if (MainManager.Instance.gameStop)
    //                yield return new WaitForSeconds(0.001f);
    //            else
    //                yield return MainManager.Instance.waitFrame;
    //        }
    //    }
    //}
}
