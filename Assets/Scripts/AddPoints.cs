using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public List<GameObject> pointContainers;
    public GameObject point;

    public void Add(int index)
    {
        Instantiate(point, pointContainers[index].transform);
    }
}
