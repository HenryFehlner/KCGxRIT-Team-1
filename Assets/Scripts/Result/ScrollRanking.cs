using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRanking : MonoBehaviour
{
    //����p�x�N�^�[
    Vector3 m_vec;
    //��x�ɗ������鑬�x
    [SerializeField]
    private float m_down;

    //�~�܂�ꏊ
    [SerializeField]
    private Transform[] m_stopTransform;

    //�Ō�܂ōs������
    private bool m_isEnd;

    //���݂̃}�E�X�ʒu
    private float m_mousePointY;
    //�ߋ��̃}�E�X�ʒu
    private float m_mouseOldPointY;
    // Start is called before the first frame update
    void Start()
    {
        m_vec = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_mouseOldPointY = 0.0f;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            m_mouseOldPointY = m_mousePointY = Input.mousePosition.y; 
        }
        if (m_isEnd == false)
        {
            if (this.gameObject.transform.position.y > m_stopTransform[0].position.y)
            {
                m_vec.y -= m_down;
            }
            else
            {
                m_vec.y = m_stopTransform[0].position.y;
                m_isEnd = true;
            }
        }
        else if(Input.GetMouseButton(0))
        {

            // �J�[�\���ʒu���擾
            m_mousePointY = Input.mousePosition.y;
            float pos = (m_mouseOldPointY - m_mousePointY) * 0.01f ;
            m_vec.y = m_vec.y- pos;
            m_mouseOldPointY = m_mousePointY;
           
        }
        else
        {
            m_mousePointY = 0.0f;
        }

        if (m_isEnd == true)
        {
            if (m_vec.y < m_stopTransform[0].position.y)
            {
                m_vec.y = m_stopTransform[0].position.y;
            }
            if (m_vec.y > m_stopTransform[1].position.y)
            {

                m_vec.y = m_stopTransform[1].position.y;
            }
        }
        this.gameObject.transform.position = m_vec;
    }
}
