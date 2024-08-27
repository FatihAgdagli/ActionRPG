using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprialOrder : MonoBehaviour
{
    [SerializeField] Transform Prefab;
    [SerializeField] float c;

    private List<Transform> transformList = new List<Transform>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Transform prefabTransform = Instantiate(Prefab, transform);
            transformList.Add(prefabTransform);
            ReOrder();
        }
    }

    private void ReOrder()
    {
        for (int i = 0; i < transformList.Count; i++)
        {
            transformList[i].localPosition = GetOrderPosition(i);
        }
    }

    Vector3 GetOrderPosition(int index)
    {
        float r = c * Mathf.Sqrt(index + 1);
        
        float tetha = (index + 1) * 137.508f;

        float x = r * Mathf.Cos(tetha);
        float z = r * Mathf.Sin(tetha);
        return new Vector3(x, 0, z);
    }
}
