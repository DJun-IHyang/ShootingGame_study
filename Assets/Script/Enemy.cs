using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//목표 : 아래 방향으로 이동한다.
//목표2 : 다른 충돌체와 부딪혔으면 나, 상대를 파괴한다.
//목표3 : 시작시 30%의 확률로 플레이어를 따라간다
//필요속성 : 30%의 확률
//목표4 : 10프로의 확률로 플레이어를 따라간다.
//필요속성 : 플레이어의 방향

//목표5 : 적도 플레이어를 향해 특정 시간에 한번씩 총을 쏜다.
//필요속성 : 총알 , 특정시간

//목표6 : 충돌시 폭발 효과를 생성한다.
//필요속성 : 폭발효과 게임오브젝트

// 목표7: 충돌시 hp가 감소한다.
// 필요속성: hp

// 목표8 : 피격시 게임매니저의 attackScore를 10씩 올려준다
// 순서. 시작시 게임매니저를 불러온다
// 필요속성 : 게임매니저

// 목표9 : 피격시 게임매니저의 destroyScore를 100씩 올려준다

// 목표10 : 플레이어 파괴시 최고 점수를 플렛폼 레지스트리에 저장한다.

// 목표11 : 피격시 피격 soundEff를 실행한다
// 순서. 시작시 사운드매니저를 불러온다
// 필요속성 : 사운드매니저

public class Enemy : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 dir = Vector3.down;
    int randValue;
    GameObject? player;

    public GameObject bulletExplosion;

    //필요속성 : 플레이어의 방향
    Vector3 playerDir;

    //필요속성: hp
    int hp = 5;

    // 필요속성 : 게임매니저
    GameManager gameManager;

    // 필요속성 : 사운드매니저
    SoundManager soundManager;

    private void Start()
    {
        //필요속성 : 30%의 확률
        randValue = Random.Range(0, 10); // 0 ~ 9 사이의 임의 값
        player = GameObject.Find("Player");

        if (randValue < 5)
        {
            if (player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
                /*dir.Normalize();*/
            }
        }

        // 순서. 시작시 게임매니저를 불러온다
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // 순서. 시작시 사운드매니저를 불러온다
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    //목표 : 아래 방향으로 이동한다.
    void Update()
    {
        if (randValue < 1)
        {
            if (player != null)
            {
                playerDir = (player.transform.position - gameObject.transform.position).normalized;
            dir = playerDir;
            }
        }
        transform.position += dir * speed * Time.deltaTime;
    }

    //목표2 : 다른 충돌체와 부딪혔으면 나, 상대를 파괴한다.
    //충돌 순간 실행
    private void OnCollisionEnter(Collision otherObject)
    {
        hp--;
        // 목표8 : 피격시 게임매니저의 attackScore를 10씩 올려준다
        gameManager.attackScore += 10;
        gameManager.attackScoreTxt.text = gameManager.attackScore.ToString();

        if (otherObject.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMove>().hp--;

            if (player.GetComponent<PlayerMove>().hp < 0)
            {
                //부딪힌 상대를 파괴한다.
                Destroy(otherObject.gameObject);

                gameManager.bestScore = gameManager.attackScore + gameManager.destroyScore;
                gameManager.bestScoreTxt.text = gameManager.bestScore.ToString();

                // 목표10 : 플레이어 파괴시 최고 점수를 플렛폼 레지스트리에 저장한다.
                PlayerPrefs.SetInt("Best Score", gameManager.bestScore);

                // 목표11 : 피격시 피격 soundEff를 실행한다
                soundManager.effAudioSource.clip = soundManager.bgmAudioClips[0];
                soundManager.effAudioSource.Play();

            }

            //충돌시 폭발 효과를 생성한다.
            GameObject bulletExplosionGO = Instantiate(bulletExplosion);
            bulletExplosionGO.transform.position = transform.position;

            // 목표9 : 피격시 게임매니저의 destroyScore를 100씩 올려준다
            gameManager.destroyScore += 100;
            gameManager.destroyScoreTxt.text = gameManager.destroyScore.ToString();

            Destroy(gameObject);
        }
        else if (hp < 0)
        {
            //나를 파괴한다.
            Destroy(gameObject);
            //부딪힌 상대를 파괴한다.
            Destroy(otherObject.gameObject);

            //충돌시 폭발 효과를 생성한다.
            GameObject bulletExplosionGO = Instantiate(bulletExplosion);
            bulletExplosionGO.transform.position = transform.position;

            // 목표11 : 피격시 피격 soundEff를 실행한다
            soundManager.effAudioSource.clip = soundManager.bgmAudioClips[0];
            soundManager.effAudioSource.Play(); 
        }
    }


    // 충돌 중 실행
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //충돌 종료시 실행
    private void OnCollisionExit(Collision collision)
    {
        
    }


}
