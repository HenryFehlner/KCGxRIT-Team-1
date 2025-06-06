using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RankingData : MonoBehaviour
{
    SaveRankingData data;
    [SerializeField]
    private GameObject m_dataObj;

    [SerializeField]
    private TextMeshProUGUI[] m_rankingText;
    // Start is called before the first frame update
    void Start()
    {
        data = m_dataObj.GetComponent<DataManager>().data;            // ランキングデータをDataManagerから参照
        var myScore = data.rankingData[10];

       

        //値が高い順でソート
        Array.Sort(data.rankingData);
        Array.Reverse(data.rankingData);
        int num = Array.IndexOf(data.rankingData, myScore);
        for (int i = 0; i < m_rankingText.Length; i++)
        {
            //テキストに代入
            m_rankingText[i].text = data.rankingData[i].ToString() ;
        }

        if (num < 10)
        {
            m_rankingText[num].color= new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

}
