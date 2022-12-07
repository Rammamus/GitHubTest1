using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyScript : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 20f;

    private void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
    }
}
