using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveRankingData data;     // json�ϊ�����f�[�^�̃N���X
    string filepath;                            // json�t�@�C���̃p�X
    string fileName = "RankingData.json";              // json�t�@�C����

    //-------------------------------------------------------------------
    // �J�n���Ƀt�@�C���`�F�b�N�A�ǂݍ���
    void Awake()
    {
        //setting 60 fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        // �p�X���擾
        filepath = Application.dataPath + "/" + fileName ;

        Debug.LogWarning("���[�h");

        // �t�@�C�����Ȃ��Ƃ��A�t�@�C���쐬
        if (!File.Exists(filepath))
        {
            Save(data);

        }

        // �t�@�C����ǂݍ����data�Ɋi�[
        data = Load(filepath);
        for (int i = 0; i < data.rankingData.Length; i++)
        {
            if (data.rankingData[i] <=0)
            {
                data.rankingData[i] = 0;
            }

        }



    }

    //-------------------------------------------------------------------
    // json�Ƃ��ăf�[�^��ۑ�
    void Save(SaveRankingData data)
    {
        string json = JsonUtility.ToJson(data);                 // json�Ƃ��ĕϊ�
        StreamWriter wr = new StreamWriter(filepath, false);    // �t�@�C���������ݎw��
        wr.WriteLine(json);                                     // json�ϊ�����������������
        wr.Close();                                             // �t�@�C������
    }

    // json�t�@�C���ǂݍ���
    SaveRankingData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<SaveRankingData>(json);            // json�t�@�C�����^�ɖ߂��ĕԂ�
    }

    public void SaveStart()
    {

        Save(data);
        Debug.LogWarning("Save���ł��܂���");
    }

    //-------------------------------------------------------------------
    // �Q�[���I�����ɕۑ�
    void OnDestroy()
    {
        Save(data);
    }
}
