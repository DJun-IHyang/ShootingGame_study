using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

// 목표 : 사용자 입력(스페이스바)를 받아 총알을 만든다. 
// 순서1 입력을 받고싶다.
// 순서2 총알을 만들고싶다.

//목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.

//목표3 : 발사시 사운드매니저의 오디오소스를 재생한다.
// 순서. 시작시 사운드매니저를 불러온다
//필요속성 : 사운드매니저

public class PlayerFire : MonoBehaviour
{
    public int skillLevel = 0;
    public GameObject Bullet;

    SoundManager soundManager;

    private void Start()
    {
        // 순서. 시작시 사운드매니저를 불러온다
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 순서1 입력을 받고싶다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLevel);
        }

    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill();
                break;
            case 1:
                ExcuteSkill1();
                break;
            case 2:
                ExcuteSkill2();
                break;
            case 3:
                ExcuteSkill3();
                break;

        }

        //목표3 : 발사시 사운드매니저의 오디오소스를 재생한다.
        soundManager.effAudioSource.clip = soundManager.fireAudioClips[0];
        soundManager.effAudioSource.Play();

        // 한개의 총알이 발사된다.
        void ExcuteSkill()
        {
            // 순서2 총알을 만들고싶다.
            GameObject bulletGO = Instantiate(Bullet);

            //순서3 : 총알의 위치를 플레이어의 위치로 정해두고 싶다.
            bulletGO.transform.position = transform.position;
        }

        // 두개의 총알이 발사된다.
        void ExcuteSkill1()
        {
            // 순서2 총알을 만들고싶다.
            GameObject bulletGO = Instantiate(Bullet);
            GameObject bulletGO1 = Instantiate(Bullet);

            //순서3 : 총알의 위치를 플레이어의 위치로 정해두고 싶다.
            bulletGO.transform.position = transform.position + new Vector3(-0.5f, 0, 0);
            bulletGO1.transform.position = transform.position + new Vector3(0.5f, 0, 0);

        }

        // 세개의 총알이 발사된다
        // 1, 2, 3총알 중 1, 3 총알이 각각 Z축으로 -30도, 30도 회전 후 발사된다.
        void ExcuteSkill2()
        {
            // 순서2 총알을 만들고싶다.
            GameObject bulletGO = Instantiate(Bullet);

            //순서3 : 총알의 위치를 플레이어의 위치로 정해두고 싶다.
            bulletGO.transform.position = transform.position;

            // 순서2 총알을 만들고싶다.
            GameObject bulletGO1 = Instantiate(Bullet);
            GameObject bulletGO2 = Instantiate(Bullet);

            //순서3 : 총알의 위치를 플레이어의 위치로 정해두고 싶다.
            bulletGO1.transform.position = transform.position + new Vector3(-0.8f, 0, 0);
            bulletGO1.transform.rotation = Quaternion.Euler(0, 0, 30);
            bulletGO1.GetComponent<Bullet>().dir = bulletGO1.transform.up;


            bulletGO2.transform.position = transform.position + new Vector3(0.8f, 0, 0);
            bulletGO2.transform.rotation = Quaternion.Euler(0, 0, -30);
            bulletGO2.GetComponent<Bullet>().dir = bulletGO2.transform.up;
        }

        void ExcuteSkill3()
        {
            int degree = 15;
            int numOfBullet = 360 / degree;

            for (int i = 0; i < numOfBullet; i++)
            {
                GameObject bulletGO = Instantiate(Bullet);

                bulletGO.transform.position = transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
                bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;

            }
        }
    }


    //목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
    //단계1. 아이템을 먹었다면
    //단계2. 스킬레벨이 1올라간다.
    //단계3. 아이템을 파괴한다.
    private void OnTriggerEnter(Collider other)
    {
        //단계1. 아이템을 먹었다면
        if (other.gameObject.tag == "Item")
        {
            //단계2. 스킬레벨이 1올라간다.(최대 스킬레벨을 초과하기 전까지)
            if (skillLevel < 3)
            {
                skillLevel++;
            }
            //단계3. 아이템을 파괴한다.
            Destroy(other.gameObject);
        }
    }
}
