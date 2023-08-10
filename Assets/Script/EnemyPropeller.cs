using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropeller : MonoBehaviour
{
    // Start is called before the first frame update


    public float rotationSpeed = 7200.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * Time.deltaTime * 360.0f * 800.0f);
    }
}

