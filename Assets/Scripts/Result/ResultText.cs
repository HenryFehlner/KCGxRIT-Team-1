using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class ResultText : MonoBehaviour
{
    //Score�e�L�X�g
    [SerializeField]
    private TextMeshProUGUI[] m_scoreText;


    private GameObject m_gameManager;

    private ScoreScript score;

    private static int tortal;
    private static int fainal;

    // Start is called before the first frame update
    void Start()
    {

        m_gameManager = GameObject.Find("GameManager");

        //�X�R�A�X�N���v�g����l���擾
        score=m_gameManager.GetComponent<ScoreScript>();


         tortal = score.TotalNumberSorted;
        fainal = (int)score.FinalScore;
        m_scoreText[0].text = score.MaxCombo.ToString();
        m_scoreText[1].text = score.TotalNumberSorted.ToString();
        m_scoreText[2].text = score.NumEscaped.ToString();
        m_scoreText[3].text = score.FinalScore.ToString();

       var data = GameObject.Find("Main Camera").GetComponent<DataManager>().data;            // �����L���O�f�[�^��DataManager����Q��
        data.rankingData[10] = (int)score.FinalScore;

        m_gameManager.SetActive(false);
    }

    /// <summary>
    /// TotalScore��getter
    /// </summary>
    /// <returns></returns>
    public int NumberSorted()
    {
        return tortal;
    }

    /// <summary>
    /// TotalScore��getter
    /// </summary>
    /// <returns></returns>
    public int GetTotalScore()
    {
        return fainal;
    }
}
