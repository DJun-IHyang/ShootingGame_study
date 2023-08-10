using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ���� �����Ѵ�.
// �ʿ� �Ӽ� : Ư�� �ð�, ���� �ð�, �� GameObject
// ����1. ���� �ð��� �帥��.
// ����2. ���� �ð��� Ư�� �ð��� �Ǹ�
// ����3. ���� EnemyManager��ġ�� �����Ѵ�.
// ����4. �ð��� �ʱ�ȭ ���ش�.

// ��ǥ2 : Ư�� �ð��� ������ �ð����� �����Ѵ�.
public class EnemyManager : MonoBehaviour
{
    // �ʿ� �Ӽ� : Ư�� �ð�, ���� �ð�, �� GameObject
    // Ư���ð�
    public float createTime;

    // ����ð�
    float currentTime;

    //�� ���ӿ�����Ʈ
    public GameObject enemy;

    //������ �ð��� �ּ� �ִ밪
    public int minTime = 3;
    public int maxTime = 5;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // ����1. ���� �ð��� �帥��.
       /* currentTime = currentTime + Time.deltaTime;*/
        currentTime += Time.deltaTime;
        print("currentTime" + currentTime);

        // ����2. ���� �ð��� Ư�� �ð��� �Ǹ�
        if (currentTime > createTime)
        {
            // ����3. ���� EnemyManager��ġ�� �����Ѵ�.
            GameObject enemyGO = Instantiate(enemy);
            enemyGO.transform.position = transform.position;

            // ����4. �ð��� �ʱ�ȭ ���ش�.
            currentTime = 0;
        }
    }
}
