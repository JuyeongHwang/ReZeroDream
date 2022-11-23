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

     public string qwDescript;
     public string qwContent;
     public string qwReward;
    [HideInInspector] public string qwName;

    [HideInInspector] public bool focusing = false;

    private SpriteRenderer huiQuestSprite;
    public Sprite[] questImgArr;

    public GameObject huiQuestImg;
    public GameObject huiMemoryQuestImg;
    public GameObject catQuestImg;
    public GameObject flowerQuestImg;
    public GameObject flowerQuestImg2;
    //public GameObject[] carQuestImg;
    //public GameObject[] wantQuestImg;

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
            flowerQuestImg2.SetActive(true);
        }
        else if (questId == 30 && questAcitonIndex == 2)
        {
            flowerQuestImg.SetActive(false);
            flowerQuestImg2.SetActive(false);
        }
        else if (questId == 30 && questAcitonIndex == 3)
        {
            huiQuestImg.SetActive(false);
        }
        else if (questId == 30 && questAcitonIndex == 4)
        {
            huiQuestImg.SetActive(true);
            huiQuestSprite.sprite = questImgArr[2];
        }
        //else if (questId == 60 && questAcitonIndex == 0)
        //{
        //    for (int i = 0; i < 5; i++)
        //        carQuestImg[i].SetActive(true);
        //}
        //else if (questId == 60 && questAcitonIndex == 3)
        //{
        //    for (int i = 0; i < 5; i++)
        //        carQuestImg[i].SetActive(false);
        //}
        //else if (questId == 90)
        //{
        //    if (questAcitonIndex == 0)
        //    {
        //        wantQuestImg[0].SetActive(true);
        //    }
        //    if (questAcitonIndex == 1)
        //    {
        //        wantQuestImg[0].SetActive(false);
        //        wantQuestImg[1].SetActive(true);
        //    }
        //    if (questAcitonIndex == 2)
        //    {
        //        wantQuestImg[1].SetActive(false);
        //        wantQuestImg[2].SetActive(true);
        //    }
        //    if (questAcitonIndex == 3)
        //    {
        //        wantQuestImg[2].SetActive(false);
        //        wantQuestImg[3].SetActive(true);
        //    }
        //    if (questAcitonIndex == 4)
        //    {
        //        wantQuestImg[3].SetActive(false);
        //        wantQuestImg[4].SetActive(true);
        //    }
        //    if (questAcitonIndex == 5)
        //    {
        //        wantQuestImg[4].SetActive(false);
        //        wantQuestImg[5].SetActive(true);
        //    }
        //}
    }

    void GenerateQuestData()
    {   //�� �κ� ���� ��� ���� ���� �ʿ�
        questList.Add(10, new QuestData("???�� ��ȭ�ϱ�", new int[] { 3000, 3000, 1000 },
            new string[] { "", "", "����: ???���� ��ȭ�� �ɾ� �̰��� ���� ������ ����." }, new string[] { "", "", "����: ???�� ��ȭ�ϱ�" }, new string[] { " ", " ", " " }));

        questList.Add(20, new QuestData("???�� ���� �˾ƺ���", new int[] { 1000, 3000, 3000, 2000, 1000 },
            new string[] { "�� �� ���� ���� �ϴ� �ҳ��̴�. �ҳ࿡�� �ٽ� �� �� �� ��ȭ�� �ɾ� �ܼ��� ����.", "����: �ֺ��� �ѷ����� ����.", "����: �ֺ��� �ѷ����� ����.", "����: �ֺ��� �ѷ����� ����.", "����: ��ġ ��ȭ�� ���� ���̸� ȹ���ߴ�.\n    �ٽ� �ҳ࿡�� ���ư�����." },
            new string[] { "����: ???�� ��ȭ�ϱ�", "����: ��ȭ�� ȹ���ϱ�", "����: ��ȭ�� ȹ���ϱ�", "����̿� ��ȣ�ۿ��ϱ�", "???�� ��ȭ�ϱ�" },
            new string[] { " ", "����: ��ȭ��", "����: ��ȭ��", "����: ����̿� ���� ���", "" }));

        questList.Add(30, new QuestData("???�� ã�ƺ���", new int[] { 10000, 11000, 1000, 3000, 1000 },
            new string[] { "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "���� �����ߴ� �͵鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "�����ϴ� �ɿ� ���� ����� ��������. �ҳ�, �� ã�ư� �� ����� ���غ���.", " ", "�ֺ��� ���� ���ߴ�. ��� �� ������ �񿡰� �����." },
            new string[] { "����: �ɰ� ��ȣ�ۿ��ϱ�", "����: �ɰ� ��ȣ�ۿ��ϱ�", "����: ��� ��ȭ�ϱ�", "", "����: ��� ��ȭ�ϱ�" }, 
            new string[] { "����: �ɿ� ���� ���", "����: �ɿ� ���� ���", "����: �������� ��ȭ���� ù ������", "", "����: ���� ���� ��� ����" }));


        questList.Add(40, new QuestData("������� ���ÿ�\n���� �˾ƺ���", new int[] { 3000, -10000, 3000 }, //�ϴ� ��ȭ �߸� �ȵǴϱ� 
            new string[] { "","�Ʊ� �������鼭 ���󿡼� ���𰡸� �� �� ����. ���� ���� Ȯ���� �� ������� ���� �� ���̰����� ���� �ܼ��� ����.", ""},
            new string[] { "","����: ���� �� Ȯ���ϱ�", "" },
            new string[] { "", " ", "" }));

        questList.Add(50, new QuestData("������� ���ÿ�\n���� �˾ƺ���(2)", new int[] { 3000 },
            new string[] { "��ȭ���� �� �� ���� ���ڵ��� �ִ�.��ſ��� ���鿡�� ������ �־����� ? �ֺ��� �ѷ����� ã�ƺ���." },
            new string[] { "����: �ڵ����� ���� �����ϱ�\n    �ܹ��ſ� ���� �����ϱ�" },
            new string[] { "����: �ڵ����� ���� ���\n    ��ῡ ���� �ܼ�\n    �ܹ��ſ� ���� ���" }));

        questList.Add(60, new QuestData("��ȭ�� ä���", new int[] { 12000, 13000, 14000 },
            new string[] { "��ȭ���� �� �� ���� ���ڵ��� �ִ�. ��ſ��� ���鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "��ȭ���� �� �� ���� ���ڵ��� �ִ�. ��ſ��� ���鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���.", "��ȭ���� �� �� ���� ���ڵ��� �ִ�.��ſ��� ���鿡�� ������ �־�����? �ֺ��� �ѷ����� ã�ƺ���." },
            new string[] { "����: �ڵ����� ���� �����ϱ�\n    �ܹ��ſ� ���� �����ϱ�", "����: �ڵ����� ���� �����ϱ�\n    �ܹ��ſ� ���� �����ϱ�", "����: �ڵ����� ���� �����ϱ�\n    �ܹ��ſ� ���� �����ϱ�" },
            new string[] { "����: �ڵ����� ���� ���\n    ��ῡ ���� �ܼ�\n    �ܹ��ſ� ���� ���", "����: �ڵ����� ���� ���\n    ��ῡ ���� �ܼ�\n    �ܹ��ſ� ���� ���", "����: �ڵ����� ���� ���\n    ��ῡ ���� �ܼ�\n    �ܹ��ſ� ���� ���" }));

        //�ܹ����� �߰��ϸ� questId == 70, zeroTalk = true
        //(�ڵ����� ��ȭ���� �ʰ� �ܹ����� ������ ���� �Ÿ� ���� ���� ��쵵 ��������. ��� �׷��� �޸��忡�� �ڵ��� �׸��� ������ų� Xǥ�� �Ǿ ������)
        questList.Add(70, new QuestData("��ȭ�� ä���", new int[] { 3000, 3000, 4000, 15000, 4000, 3000 },
            new string[] { "", "�ܹ������� �� �޸����� �ܹ��� �׸��� ���� �ܼ��� ���, ������� ä������.", "�������� ��ȭ�� �ɾ� �ֹ��� �غ���.", "������ ���ϴ� '�� �ܹ���'�� �����ϱ�? ���� ������ ���캸�� �ٸ� ����� �԰� ���� ���� �ܹ��Ű� �ִ��� ã�ƺ���.",
            "�ܹ��Ÿ� �����. ���Է� ���ư� �������� ��ȭ�� �ɾ��.", " " },
            new string[] { "", "����: �ܹ����� ����", "����: ������ ��ȭ�ϱ�", "����: �ֺ��� �ѷ����� �ܹ��� ã��", "����: ������ ��ȭ�ϱ�", " " },
            //�׸��� ���� ������ �ٸ� npc���� ��ȭ �߰��ص� ���� �� ���ƿ�!
            new string[] { "", " ", " ", " "," ", "����: �ܹ��ſ� ���� ���\n    �������� ��ȭ���� �ι�° ������" }));

        

        questList.Add(80, new QuestData("�⹦�� ���\n�� ���� �˾ƺ���", new int[] { 3000, 3000 },
        new string[] { "��ſ��� ����� ��� ã���� ���ο� ������ �����ߴ�.", "�ֺ��� �ѷ����� �� �ð��� ���� ��濡 ���� �ܼ��� ����." }, 
        new string[] { "����: �ֺ� �ѷ�����", "����: �ֺ� �ѷ�����" }, new string[] { " ", " " }));

        questList.Add(90, new QuestData("��� �ȱ�", new int[] {16000, 17000, 18000, 19000, 20000, 21000 },
        new string[] { "��ȭ���� ȹ���ߴ��� �ֺ��� ���ߵ��� �����̱� �����Ѵ�. �� ������ ��ȭ�� �� �׸��� � �ǹ��ϱ�? ����� ������ �˾ƺ���.", "����� ������ �����ִ� �л��鿡�� ��ȭ�� �ɾ��.", "����� ������ �����ִ� �л��鿡�� ��ȭ�� �ɾ��.", "����� ������ �����ִ� �л��鿡�� ��ȭ�� �ɾ��.", "����� ������ �����ִ� �л��鿡�� ��ȭ�� �ɾ��.", "����� ������ �����ִ� �л��鿡�� ��ȭ�� �ɾ��."},
        new string[] { "����: ��� �ȱ�", "����: �л���� ��ȭ�ϱ�", "����: �л���� ��ȭ�ϱ�", "����: �л���� ��ȭ�ϱ�", "����: �л���� ��ȭ�ϱ�", "����: �л���� ��ȭ�ϱ�" }, new string[] { " ", " ", " ", " ", " ","" }));

        //questList.Add(100, new QuestData("�Ҿ���� ��� ��ã��", new int[] { 3000 },
        //new string[] { "�ذ� �ִ� �����鿡 ���� ����� ��������. �׵�� ��ȭ�� �Ҿ���� ����̶� ������ ��ã��."}, new string[] { "����: ������� ��ȭ�ϱ�" }, new string[] { "����: �����鿡 ���� ���\n    '���'" }));

        questList.Add(100, new QuestData("����Ʈ ��", new int[] { -10000 },
        new string[] { "���� ����" }, new string[] { " " }, new string[] { " " }));
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
            questId = 70;
            questAcitonIndex = 0;
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