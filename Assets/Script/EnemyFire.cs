using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : Ư�� �ð��� �ѹ��� �Ѿ��� ����� �÷��̾ ���� �߻��Ѵ�.
//�ʿ�Ӽ� : �Ѿ�, ����ð�, Ư���ð�, �÷��̾�, �÷��̾����
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
            //����2 : �Ѿ��� ����� �ʹ�.
            GameObject bulletGO = Instantiate(bullet);

            //����3 : �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bulletGO.transform.position = transform.position;

            currentTime = 0;
        }
    }
}
