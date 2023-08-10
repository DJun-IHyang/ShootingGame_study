using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ����(�Ѿ�) ���� ���ư���.
// ������ �ʿ���.
// �ӵ��� �ʿ���.

//��ǥ2 : �Ѿ��� ���� �浹�ϸ� ��(�Ѿ�)��, ���� �ı��ȴ�.
//��ǥ3 : �浹�� ���� ȿ���� �����Ѵ�.
public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    // ��ǥ : ����(�Ѿ�) ���� ���ư���.
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

    }

    //��ǥ2 : �Ѿ��� ���� �浹�ϸ� ��(�Ѿ�)��, ���� �ı��ȴ�.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            //���� �ı��Ѵ�.
            Destroy(gameObject);
            //�ε��� ��븦 �ı��Ѵ�.
            Destroy(other.gameObject);

            //��ǥ3 : �浹�� ���� ȿ���� �����Ѵ�.
            GameObject bulletExplosionGO = Instantiate(bulletExplosion);
            bulletExplosionGO.transform.position = transform.position;
        }

    }
}
