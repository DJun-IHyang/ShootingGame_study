using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : BackGround�� Material�� Offset�� Y�� �����ӵ��� ��ȭ��Ű�� �ʹ�.
//�Ӽ� : ����ð�, �ӵ�, ���͸���
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
