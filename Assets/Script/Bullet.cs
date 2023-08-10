using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 내가(총알) 위로 날아간다.
// 방향이 필요함.
// 속도가 필요함.

//목표2 : 총알이 적과 충돌하면 나(총알)와, 적이 파괴된다.
//목표3 : 충돌시 폭발 효과를 생성한다.
public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    // 목표 : 내가(총알) 위로 날아간다.
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

    }

    //목표2 : 총알이 적과 충돌하면 나(총알)와, 적이 파괴된다.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            //나를 파괴한다.
            Destroy(gameObject);
            //부딪힌 상대를 파괴한다.
            Destroy(other.gameObject);

            //목표3 : 충돌시 폭발 효과를 생성한다.
            GameObject bulletExplosionGO = Instantiate(bulletExplosion);
            bulletExplosionGO.transform.position = transform.position;
        }

    }
}
