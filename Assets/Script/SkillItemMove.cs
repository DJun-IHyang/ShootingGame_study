using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 스킬아이템이 아래 방향으로 특정속도로 이동한다.
// 속성 : 아래 방향, 특정속도

// 목표2 : 스킬이 파괴될때 아이템 이펙트를 생성한다
// 속성 : 아이템 이펙트

// 목표3. 폭발시 사운드 이펙트를 생성한다.
// 순서1. 사운드 매니저를 불러온다.
// 순서2. 사운드 매니저에서 오디오 소스의 오디오 클립을 변경해준다.
// 순서3. 사운드 매니저의 오디오 소스를 재생시킨다.
public class SkillItemMove : MonoBehaviour
{
    //특정속도
    public float speed;
    //아래 방향
    Vector3 dir = Vector3.down;
    //아이템이펙트
    public GameObject ItemExplosion;


    // Update is called once per frame
    void Update()
    {
        // 목표 : 스킬아이템이 아래로 방향으로 특정속도로 이동한다.
        transform.position += dir * speed * Time.deltaTime;

    }

    private void OnDestroy()
    {
        // 목표2 : 스킬이 파괴될때 아이템 이펙트를 생성한다
        GameObject itemExplosionGO = Instantiate(ItemExplosion);
        itemExplosionGO.transform.position = transform.position;

        // 목표3. 폭발시 사운드 이펙트를 생성한다.
        // 순서1. 사운드 매니저를 불러온다.
        GameObject soundManager = GameObject.Find("SoundManager");
        AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAudioSource;

        // 순서2. 사운드 매니저에서 오디오 소스의 오디오 클립을 변경해준다.
        audioSource.clip = soundManager.GetComponent<SoundManager>().itemAudioClips[0];

        // 순서3. 사운드 매니저의 오디오 소스를 재생시킨다.
        audioSource.Play();
    }
}
