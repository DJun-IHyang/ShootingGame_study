using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 특정 시간에 한번씩 총알을 만들고 플레이어를 향해 발사한다.
//필요속성 : 총알, 현재시간, 특정시간, 플레이어, 플레이어방향
public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    float currentTime;
    public float createTime = 1;
 


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
       

        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            //순서2 : 총알을 만들고 싶다.
            GameObject bulletGO = Instantiate(bullet);

            //순서3 : 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bulletGO.transform.position = transform.position;

            currentTime = 0;
        }
    }
}
