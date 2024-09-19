using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;        // �������� ������ ����
    List<GameObject>[] pools;           // Ǯ ����� �ϴ� ����Ʈ

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // ������ Ǯ�� ��Ȱ��ȭ �� ���� ������Ʈ�� ����
            // ã������ select ��ü�� �Ҵ�
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        
        // ã�� �������� ���ο� ���� ������Ʈ�� ���� �� select ��ü�� �Ҵ�
        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
