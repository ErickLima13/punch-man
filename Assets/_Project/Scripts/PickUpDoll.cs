using System.Collections.Generic;
using UnityEngine;

public class PickUpDoll : MonoBehaviour
{
    [SerializeField] Transform dollPos;

    public int dollsCount;

    public List<GameObject> dolls = new List<GameObject>();

    public void AddDoll(Transform doll)
    {
        dolls.Add(doll.gameObject);
        doll.SetParent(dollPos, true);
        doll.localPosition = new Vector3(0, dollsCount, 0);
        dollsCount++;
    }

    public void RemoveDoll()
    {
        if (dollsCount >= 0)
        {
            foreach (GameObject d in dolls)
            {
                d.transform.SetParent(null);
                dollsCount--;
            }

            dolls.Clear();
        }

       
    }

}
