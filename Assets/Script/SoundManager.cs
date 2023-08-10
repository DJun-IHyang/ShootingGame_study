using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : BGM, ���� ����, ������ ȹ�� ���带 ����Ѵ�
// �ʿ�Ӽ� : BGM, ���� ����, ������ ȹ�� ���� ����� Ŭ��
public class SoundManager : MonoBehaviour
{
    public enum SoundName
    {
        Explosion0 = 0,
        Explosion1 = 1,
        Attack0 = 2,
        Attack1 = 3,
        BGM1 = 4,
        BGM2 = 5
    }


    //BGM������ҽ�
    public AudioSource bgmAudioSource;
    //����Ʈ������ҽ�
    public AudioSource effAudioSource;

    public List<AudioClip> bgmAudioClips = new List<AudioClip>();
    public List<AudioClip> explosionAudioClips = new List<AudioClip>();
    public List<AudioClip> itemAudioClips = new List<AudioClip>();
    public List<AudioClip> fireAudioClips = new List<AudioClip>();

    private void Start()
    {
        int randBGM = Random.Range(0, bgmAudioClips.Count);
        bgmAudioSource.clip = bgmAudioClips[randBGM];
    }

}
