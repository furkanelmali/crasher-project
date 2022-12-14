using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;

    public Joint get_Child()
    {
        return m_child;
    }
    

    public void rotate(float angle)
    {
        transform.Rotate(Vector3.up * angle);

    }
}
    