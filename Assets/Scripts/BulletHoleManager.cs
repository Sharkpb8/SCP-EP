using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleManager : MonoBehaviour
{
    public List<GameObject> BulletHoleList = new List<GameObject>();

    void Update()
    {
        if (BulletHoleList.Count > 30)
        {
            GameObject oldest = BulletHoleList[0];
            BulletHoleList.RemoveAt(0);
            Destroy(oldest);
        }
    }

    public void AddBulletHole(GameObject bulletHole)
    {
        BulletHoleList.Add(bulletHole);
    }
}
