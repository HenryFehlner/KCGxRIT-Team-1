using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuwaMoco : MonoBehaviour
{
    [SerializeField ,Header("��������I�u�W�F�N�g")]
    private GameObject[] m_createObject;


    [SerializeField, Header("��������Ԋu")]
    private int m_spawnTime;


    //�X�|�[���̃J�E���g
    private int m_cnt;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(m_createObject[0], this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
