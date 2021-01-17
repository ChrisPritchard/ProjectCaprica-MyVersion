using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Rotate : MonoBehaviour
{
    public Vector3 RotationSpeed = new Vector3(0, 30, 0);

    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
