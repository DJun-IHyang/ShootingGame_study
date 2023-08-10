using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    GameObject player;
    public GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dir = (player.transform.position - gameObject.transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.rotation *= Quaternion.Euler(90, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += dir * speed * Time.deltaTime;

       
       

    }

    private void OnCollisionEnter(Collision other)
    {
      
        if (other.gameObject.tag == "Player")
        {
           
           if (player != null)
            {
                player.GetComponent<PlayerMove>().hp--;

                if (player.GetComponent<PlayerMove>().hp < 0)
                {
                    //���� �ı��Ѵ�.
                    Destroy(gameObject);
                    //�ε��� ��븦 �ı��Ѵ�.
                    Destroy(other.gameObject);

                    // ��ǥ10 : �÷��̾� �ı��� �ְ� ������ �÷��� ������Ʈ���� �����Ѵ�.
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                    gameManager.bestScore = gameManager.attackScore + gameManager.destroyScore;
                    gameManager.bestScoreTxt.text = gameManager.bestScore.ToString(); 

                    PlayerPrefs.SetInt("Best Score", gameManager.bestScore);
                }
            }           
        }
        //���� �ı��Ѵ�.
        Destroy(gameObject);

        //�浹�� ���� ȿ���� �����Ѵ�.
        GameObject bulletExplosionGO = Instantiate(bulletExplosion);
        bulletExplosionGO.transform.position = transform.position;

    }

}
