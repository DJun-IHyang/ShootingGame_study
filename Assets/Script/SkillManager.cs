using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ��ų�������� Ư���ð����� �����.
//�ʿ� �Ӽ� : ��ų������, Ư�� ���� �ð�(�ּҽð�, �ִ�ð�), ����ð�
// �ܰ�1. �ð��� �帥�� 
// �ܰ�2. ����ð��� Ư�� ���� �ð�(�ּҽð�, �ִ�ð�)�� ������
// �ܰ�3. ��ų�������� �����Ѵ�.
// �ܰ�4. ��ų������ ��ġ�� ��ų�Ŵ����� ��ġ�� �����Ѵ�.
// �ܰ�5. �ð��� �ٽ� �������ش�.
public class SkillManager : MonoBehaviour
{
    //�ʿ� �Ӽ� : ��ų������, Ư�� ���� �ð�(�ּҽð�, �ִ�ð�), ����ð�
    public GameObject skillItem;
    float createTime;
    public float minCreateTime;
    public float maxCreateTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minCreateTime, maxCreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        // ��ǥ : ��ų�������� Ư���ð����� �����.
        // �ܰ�1. �ð��� �帥��.
        currentTime += Time.deltaTime;
        // �ܰ�2. ����ð��� Ư���ð��� ������
        if(currentTime > createTime)
        {
            // �ܰ�3. ��ų�������� �����Ѵ�.
            GameObject skillItemGO = Instantiate(skillItem);
            // �ܰ�4. ��ų������ ��ġ�� ��ų�Ŵ����� ��ġ�� �����Ѵ�.
            skillItemGO.transform.position = transform.position;

            currentTime = 0;

            // �ܰ�5. �ð��� �ٽ� �������ش�.
            createTime = Random.Range(minCreateTime, maxCreateTime);
        }
    }
}
