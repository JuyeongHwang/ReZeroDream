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

    [HideInInspector] public string qwDescript;
    [HideInInspector] public string qwContent;
    [HideInInspector] public string qwReward;
    [HideInInspector] public string qwName;

    [HideInInspector] public bool focusing = false;

    private SpriteRenderer huiQuestSprite;
    public Sprite[] questImgArr;

    public GameObject huiQuestImg;
    public GameObject huiMemoryQuestImg;
    public GameObject catQuestImg;
    public GameObject flowerQuestImg;
    public GameObject[] carQuestImg;

    private void Start()
    {
        questList = new Dictionary<int, QuestData>(); //�ʱ�ȭ
        GenerateQuestData();

        huiQuestSprite = huiQuestImg.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        nowDialogueObject = questList[questId].npcId[questAcitonIndex];

        if (questId == 10 && questAcitonIndex == 2)
        {
            huiQuestImg.SetActive(true);
        }
        else if (questId == 20 && questAcitonIndex == 1)
        {
            huiQuestSprite.sprite = questImgArr[1];
            huiMemoryQuestImg.SetActive(true);
        }
        else if (questId == 20 && questAcitonIndex == 4)
        {
            catQuestImg.SetActive(false);
            huiQuestSprite.sprite = questImgArr[0];
        }
        else if (questId == 30 && questAcitonIndex == 0)
        {
            huiQuestSprite.sprite = questImgArr[1];
            flowerQuestImg.SetActive(true);
        }
        else if (questId == 30 && questAcitonIndex == 2)
        {
            flowerQuestImg.SetActive(false);
            huiQuestSprite.sprite = questImgArr[2];

            //ObjData objData = Happy.GetComponent<ObjData>();
            //objData.name = "��";
        }
        else if (questId == 60 && questAcitonIndex == 0)
        {
            for (int i = 0; i < 5; i++)
                carQuestImg[i].SetActive(true);
        }
        else if (questId == 60 && questAcitonIndex == 3)
        {
            for (int i = 0; i < 5; i++)
                carQuestImg[i].SetActive(false);
        }
    }


    void GenerateQuestData()
    {
        questList.Add(10, new QuestData("???�� ��ȭ�ϱ�", new int[] { 3000, 3000, 1000 },
            new string[] { "", "", "???���� ��ȭ�� �ɾ� �̰��� ���� ������ ����." }, new string[] { "", "", "???�� ��ȭ�ϱ�" }, new string[] { " ", " ", " " }));

        questList.Add(20, new QuestData("???�� ���� �˾ƺ���", new int[] { 1000, 3000, 3000, 2000, 1000 },
            new string[] { "�� �� ���� ���� �ϴ� �ҳ��̴�. �ҳ࿡�� �ٽ� �� �� �� ��ȭ�� �ɾ� �ܼ��� ����.", "�ֺ��� �ѷ����� ����.", "�ֺ��� �ѷ����� ����.", "�ֺ��� �ѷ����� ����.", "�� �� ���� ������ ȹ���ߴ�. �ٽ� �ҳ࿡�� ���ư�����." },
            new string[] { "???�� ��ȭ�ϱ�", "���� ȹ���ϱ� \n����̿� ��ȣ�ۿ��ϱ�", "���� ȹ���ϱ� \n����̿� ��ȣ�ۿ��ϱ�", "���� ȹ���ϱ� \n����̿� ��ȣ�ۿ��ϱ�", "???�� ��ȭ�ϱ�" },
            new string[] { " ", "����", "����", "����", " " }));

        questList.Add(30, new QuestData("???�� ã�ƺ���", new int[] { 10000, 11000, 1000 },
            new string[] { "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "�����ϴ� �ɿ� ���� ����� ��������. �ҳฦ ã�ư� �� ����� ���غ���." },
            new string[] { "�ֺ� �ѷ�����", "�ֺ� �ѷ�����", "��� ��ȭ�ϱ�" }, //�ٵ� ���⼭ �̷��� �����̶�� ����ص� �Ǵ� �ǰ���..??
            new string[] { " ", " ", "Ȱ��ȭ�� ���� ���� \n���� ���� ��� ����" })); //��������

        questList.Add(40, new QuestData("���ο� ���� �����ϱ�", new int[] { 3000, -10000 }, //�ϴ� ��ȭ �߸� �ȵǴϱ� 
            new string[] { "����� ��ȭ�� ��ġ�� ���ο� ������ ���ȴ�. �̰��� ���ƴٴϸ� �����غ���.", "����� ��ȭ�� ��ġ�� ���ο� ������ ���ȴ�. �̰��� ���ƴٴϸ� �����غ���." },
            new string[] { "���ο� ���� �����ϱ�", "���ο� ���� �����ϱ�" },
            new string[] { " ", " " }));

        //questList.Add(50, new QuestData("���ο� ���� �����ϱ�", new int[] { -10000 }, //��� ���� ���� -10000����/ ���� ȥ�㸻�� 3000����
        //   new string[] { "����� ��ȭ�� ��ġ�� ���ο� ������ ���ȴ�. �̰��� ���ƴٴϸ� �����غ���." },
        //   new string[] { "���ο� ���� �����ϱ�" },
        //   new string[] { " " }));
        //�����ؾ��ϴ� �κ�: ������ ������ũ �� true�ǰ� �ٸ��� �Ű澵 �ʿ�x, ���� �߰��ϸ� ����Ʈ ���̵� 50�ǵ���, ������ �߰��ϸ� 60 �ǵ���

        questList.Add(50, new QuestData("������ ���翡 ���� �˾ƺ���", new int[] { 3000 }, 
           new string[] { "�� ���ߴ� ������ ����� �����ߴ�. ������ ���簡 ��Ű�� �ִ� ������ ������ ����." },
           new string[] { "���� ȹ���ϱ�" },
           new string[] { "���� \n�޸����� ���ο� ������ Ȱ��ȭ" }));

        questList.Add(60, new QuestData("�޸��� ä������", new int[] { 12000, 13000, 14000, 3000, 16000 },
         new string[] { "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���.", "�޸��忡 �� �� ���� ���ڵ��� �ִ�. ���õ� ������ ã�ƺ���." },
         new string[] { "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���", "����� ���õ� �͵� �����ϱ� \n����� ä���" },
         new string[] { "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����", "���� ����, ��ῡ ���� �ܼ� \n���� ���� ��� ����" }));

        questList.Add(70, new QuestData("����Ʈ ��", new int[] { -10000 },
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
        else if (id == 14000 && questId == 60 && questAcitonIndex == 0 || id == 14000 && questId == 60 && questAcitonIndex == 1)
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