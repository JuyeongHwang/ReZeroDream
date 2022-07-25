using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId = 0; //���� ���� ���� ����Ʈ ���̵�
    public int questAcitonIndex = 0; //����Ʈ ��ȭ���� ����
    public int nowDialogueObject = -1000; 

    Dictionary<int, QuestData> questList; //����Ʈ ������ ���� 

    //public AudioClip complete = null;


    //public GameObject Happy;
    ////��
    //public GameObject questImg1_1; //���� ����
    //public GameObject questImg1_2; //���� �Ϸ�
    //public GameObject questImg1_3;//���� ������
    //public GameObject questImg2_1; //����� ����
    //public GameObject questImg3_1_1; //�� ����
    //public GameObject questImg3_1_2;//�� ����

    ////��
    //public GameObject questImg4_1; //���� ����
    //public GameObject questImg4_2; //���� ����                        
    ////public GameObject questImg5_1; //�������� ����
    //public GameObject questImg6_1_1; //�� 1 ����
    //public GameObject questImg6_1_2; //�� 2 ����
    //public GameObject questImg6_1_3; //�� 3 ����
    //public GameObject questImg7_1; //�ܹ����� ����
    //public GameObject questImg8_1; //�ܹ��� ����

    //public CatNameChange catNameChange;
    //public GameObject catNameImage;


    public string qwDescript;
    public string qwContent;
    public string qwReward;
    public string qwName;

    [HideInInspector] public bool focusing = false;

    private void Start()
    {
        questList = new Dictionary<int, QuestData>(); //�ʱ�ȭ
        GenerateQuestData();

    }

    void Update()
    {
        nowDialogueObject = questList[questId].npcId[questAcitonIndex];

        //����Ʈ ����, ����, �Ϸ� ǥ��
        //if (questId == 10 && questAcitonIndex == 0)
        //{
        //    questImg1_1.SetActive(true);
        //}
        //else if (questId == 20 && questAcitonIndex == 1)
        //{
        //    questImg1_1.SetActive(false);
        //    questImg1_3.SetActive(true);
        //    //if(SpawnEmotions.instance.isPleasureBelong)
        //    //    questImg2_1.SetActive(true);

        //}
        //else if (questId == 20 && questAcitonIndex == 2)
        //{
        //    questImg2_1.SetActive(false);
        //}
        //else if (questId == 30 && questAcitonIndex == 0)
        //{
        //    questImg1_3.SetActive(false);
        //    questImg3_1_1.SetActive(true);
        //    questImg3_1_2.SetActive(true);
        //}
        //else if (questId == 30 && questAcitonIndex == 2)
        //{
        //    questImg3_1_1.SetActive(false);
        //    questImg3_1_2.SetActive(false);
        //    //OnPlayClickSound();
        //    questImg1_2.SetActive(true);
        //    ObjData objData = Happy.GetComponent<ObjData>();
        //    objData.name = "��";
        //}
        //else if (questId == 40 && questAcitonIndex == 0)
        //{
        //    questImg4_1.SetActive(true);
        //}
        //else if (questId == 70 && questAcitonIndex == 0)
        //{
        //    //DialogueManager.instance.SetQuestWindow(70);
        //    questImg4_1.SetActive(false);
        //    //questImg5_1.SetActive(false);
        //    questImg6_1_1.SetActive(true);
        //    questImg6_1_2.SetActive(true);
        //    questImg6_1_3.SetActive(true);
        //    questImg7_1.SetActive(true);
        //}
        //else if (questId == 70 && questAcitonIndex == 3) //�޸��� ä��� ����Ʈ �Ϸ�
        //{
        //    questImg6_1_1.SetActive(false);
        //    questImg6_1_2.SetActive(false);
        //    questImg6_1_3.SetActive(false);
        //}
    }


    void GenerateQuestData()
    {
        questList.Add(10, new QuestData("???�� ��ȭ�ϱ�", new int[] { 1000 },
            new string[] { "???���� ��ȭ�� �ɾ� �̰��� ���� ������ ����." }, new string[] { "???�� ��ȭ�ϱ�" }, new string[] { " " }));

        questList.Add(20, new QuestData("???�� ���� �˾ƺ���", new int[] { 1000, 2000, 1000 },
            new string[] { "�� �� ���� ���� �ϴ� �ҳ��̴�. �ҳ࿡�� �ٽ� �� �� �� ��ȭ�� �ɾ� �ܼ��� ����.", "�ֺ��� �ѷ����� ����.", "�� �� ���� ������ ȹ���ߴ�. �ٽ� �ҳ࿡�� ���ư�����." },
            new string[] { "???�� ��ȭ�ϱ�", "���� ȹ���ϱ� \n����̿� ��ȣ�ۿ��ϱ�", "???�� ��ȭ�ϱ�" },
            new string[] { " ", "����", " " }));

        questList.Add(30, new QuestData("???�� ã�ƺ���", new int[] { 10000, 11000, 1000 },
            new string[] { "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "�����ϴ� �ɿ� ���� ����� ��������. �ҳฦ ã�ư� �� ����� ���غ���." },
            new string[] { "�ֺ� �ѷ�����", "�ֺ� �ѷ�����", "��� ��ȭ�ϱ�" }, //�ٵ� ���⼭ �̷��� �����̶�� ����ص� �Ǵ� �ǰ���..??
            new string[] { " ", " ", "Ȱ��ȭ�� ���� ���� \n���� ���� ��� ����" })); //��������

        questList.Add(40, new QuestData("���ο� ���� �����ϱ�", new int[] { -10000 }, //�ϴ� ��ȭ �߸� �ȵǴϱ� ���� ��ȣ��
            new string[] { "����� ��ȭ�� ��ġ�� ���ο� ������ ���ȴ�. �̰��� ���ƴٴϸ� �����غ���." },
            new string[] { "���ο� ���� �����ϱ�" },
            new string[] { " " }));

        questList.Add(50, new QuestData("������ ���翡 ���� �˾ƺ���", new int[] { 3000 }, //��� ���� ���� -10000����/ ���� ȥ�㸻�� 3000����
           new string[] { "�� ���ߴ� ������ ����� �����ߴ�. ������ ���簡 ��Ű�� �ִ� ������ ������ ����." },
           new string[] { "���� ȹ���ϱ�" },
           new string[] { "���� \n�� �޸��� Ȱ��ȭ" }));

        questList.Add(60, new QuestData("������ ���翡 ���� �˾ƺ���", new int[] { -10000 }, 
           new string[] { "�� ���ߴ� ������ ����� �����ߴ�. ������ ���簡 ��Ű�� �ִ� ������ ������ ����." },
           new string[] { "���� ȹ���ϱ�" },
           new string[] { "���� \n�޸����� ���ο� ������ Ȱ��ȭ" }));

        questList.Add(70, new QuestData("�޸��� ä������", new int[] { 12000, 13000, 14000, 3000, 16000 },
         new string[] { "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���." },
         new string[] { "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���" },
         new string[] { "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����" }));

        questList.Add(80, new QuestData("����Ʈ ��", new int[] { 1000 },
           new string[] { "���� ������ ����." }, new string[] { " " }, new string[] { " " }));
    }

    public int GetQuestTalkIndex(int id) //npc id�ް� ����Ʈ��ȣ(����Ʈ��ũ�ε���) ��ȯ�ϴ� �Լ�
    {
        return questId + questAcitonIndex;
    }


    public string CheckQuest(int id)
    {

        if (id == questList[questId].npcId[questAcitonIndex])
        {
            questAcitonIndex++; //����Ʈ ������ ������ �°� ��ȭ�� �ϰ� ��ȭ�� ������ ����Ʈ ���� �ϳ��� �ø���
        }

        // �� ��ȭ ���� ���ø� ���� �ڵ�
        else if (id == 11000 && questId == 30 && questAcitonIndex == 0)
        {
            questAcitonIndex = 2;
        }
        //�ڵ���(����) ��ȭ ���� ����
        else if (id == 14000 && questId == 70 && questAcitonIndex == 0 || id == 14000 && questId == 70 && questAcitonIndex == 1)
        {
            questAcitonIndex = 3;
        }

        if (questAcitonIndex == questList[questId].npcId.Length)
        {   //questActionIndex�� npcId �迭�� ũ��� ������, �� ����Ʈ ��ȭ������ ���� �������� �� ����Ʈ ��ȣ ����(���� ����Ʈ ����)
            NextQuest();
        }

        //����Ʈâ
        qwDescript = questList[questId].questDescription[questAcitonIndex];
        qwContent = questList[questId].questContent[questAcitonIndex];
        qwReward = questList[questId].questReward[questAcitonIndex];

        return qwName = questList[questId].questName; //���� �������� ����Ʈ �̸� ��ȯ
    }

    public void NextQuest()
    {
        questId += 10;
        questAcitonIndex = 0;
    }

}