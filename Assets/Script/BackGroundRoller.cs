using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : BackGround의 Material의 Offset의 Y를 일정속도로 변화시키고 싶다.
//속성 : 현재시간, 속도, 매터리얼
public class BackGroundRoller : MonoBehaviour
{
    float currentTime;
    public float speed = 1.0f;
    public Material material;

        // Update is called once per frame
        void Update()
        {
            currentTime += speed * Time.deltaTime;

            material.mainTextureOffset = Vector3.up * currentTime;
        }

}
