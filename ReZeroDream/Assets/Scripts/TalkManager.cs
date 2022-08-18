using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; //��ȭ�����͸� ������ dictionary ���� (Ű: object id, ��: ��ȭ����)

    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr; //�ʻ�ȭ ��������Ʈ ������ �迭 

    private void Start()
    {
        talkData = new Dictionary<int, string[]>(); //�ʱ�ȭ
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    //Talk Data
    void GenerateData()
    {
        talkData.Add(-1000, new string[] { "��ȭ�� �� ������. ������ ���� �� ����.:1" });

        talkData.Add(1000, new string[] { "������...:2" });
        talkData.Add(2000, new string[] { "�Ŀ�:0" });
        talkData.Add(4000, new string[] { "�ܹ��Ű� �� �ȷȾ�.:3" });
        
        //talkData.Add(5000, new string[] { "� �б��� ���� ��.:0" }); //����
        //talkData.Add(6000, new string[] { "� �б��� ���� ��.:0" }); //�ƺ�
        //talkData.Add(7000, new string[] { "� �б��� ���� ��.:0" }); //����

        talkData.Add(10000, new string[] { "�̸� �� ���̴�.:1" });
        talkData.Add(11000, new string[] { "���� ���ο� ���̴�.:1" });
        talkData.Add(12000, new string[] { "��������. �׷��� ����� ���� �� ����.:1" });
        talkData.Add(13000, new string[] { "����� �ڵ����̴�.:1" });
        talkData.Add(14000, new string[] { "���̰� ���� ����.:1", "� ����� �������� �� ���⵵ ��... ���� �ڿ� �ٽ� �����غ���.:1" }); //����Ʈ ��ȭ ������ �̸��� ���η� �����ؼ�...
        talkData.Add(15000, new string[] { "�ܹ��� ���� ���� �谡 ������...:1" }); //�ܹ����� ó�� �߰��� �� �� zeroTalk = true;


        //Quest Talks
        talkData.Add(10 + 3000, new string[] { "�����... �����? ������ ���� ����̾�.:1" });
        talkData.Add(11 + 3000, new string[] { "�� ���̴� ������...? �� �̷� ���� �ִ� �ɱ� ?:1" });
        talkData.Add(12 + 1000, new string[] { "�� �� ���� �𸣴±���.:2", "���� ���ؼ� �˾ƺ� �ٷ�?:2" });

        talkData.Add(20 + 1000, new string[] { "�� ��𿡵� �־�.:2", "�ֺ��� �ѷ����� ���ڴ�?:2" });
        talkData.Add(21 + 3000, new string[] { "�̰� ����? �� ������ �ٰ�������?:1" });
        talkData.Add(22 + 3000, new string[] { "�� ���̴� ��� ����ϴ°���? �׸��� �׷����־�...:1" });
        talkData.Add(23 + 2000, new string[] { "�Ŀ�.:0", "�ε巴��, ������... ���� �������� ������ ������.:1", ":0", "�¾�. ���� Ű��� ����� �̸���...:1", "�ľ�.:0" });
        talkData.Add(24 + 1000, new string[] { "���� ã�ƿԱ���.:2", "����� �������� �ʴ�?:2", "������ ������ ���̳�. �� ���� �� ã�ƿ���.:2", "�װ� �����ߴ� �͵��� ���÷���.:2", "�ʰ� ���ϴ� ���� ���� �� �� �־�.:2" });

        talkData.Add(30 + 10000, new string[] { "�̰ǡ� �ƴ� �� ����.:1" });
        talkData.Add(30 + 11000, new string[] { "�ͼ��ϰ�, ���� ��Ⱑ ��... ���Ѻ��� �͸����ε� ������...:1" });
        talkData.Add(32 + 1000, new string[] { "���� ����� ���̳�.:2", "�������� ���ư��� ����.:2",
            "�׷��� �� �ۿ��� ������ ���·� �����ϴ� �͵鵵 ������\n�����ϴ� �� ���� �ž�.:2", "��ΰ� ��ó�� ��ȭ�� �ذ��� �� �ִٸ� �����ٵ�...:2" });
        talkData.Add(33 + 3000, new string[] { "���� ������!:1", "���� ���ƿ°� ����. ��� �� ������?.:1" });

        talkData.Add(40 + 3000, new string[] { "�����Ⱑ �޶�����.:1"});
        talkData.Add(50 + 3000, new string[] { "������ �Ʊ� �� ���̰� ���� ������ ������ �ǰ�.:1", "��ȭ�� ������ �ʴ´ٰ� �߾�����... \nȤ�� �𸣴ϱ� �� �� �ٰ�������.:1" });

        talkData.Add(60 + 12000, new string[] { "��������. �׷��� ����� ���� �� ����.:1" });
        talkData.Add(60 + 13000, new string[] { "����� �ڵ����̴�.:1" });
        talkData.Add(60 + 14000, new string[] { "����? �� ���� ���� �ͼ���.:1", "�׷����� �� ���� ���� Ÿ�� ������� �Բ� �ٴٷ� ������ ������.:1", "�׶� ���Ҵ� �ٴٰ� ���� �������µ�...:1" }); //�̸� �ϴ� ���η� (���ΰ� ���� ��ó�� ���;� �ϴϱ�)

        //talkData.Add(63 + 3000, new string[] { "���! ����� ����� ���ݾ�?:1" });
        //talkData.Add(64 + 16000, new string[] { "�� �ڸ��� �����. �� �ܹ��Ŵ� �Ծ �Ǵ� �ǰ�:1", "�� ���Դ� �̻���. ������ ����... �� �ڸ��� ������ �ֳİ� ��� �ƹ��� ��������� �ʾ�.:1", "����, ������ϱ� �׳� ����!:1" });

        talkData.Add(80 + 1000, new string[] { " " });


        //portraitArr 0: none/ 1: zero/ 2: happy/ 3:enzo
        portraitData.Add(1000 + 2, portraitArr[2]); //����
        portraitData.Add(3000 + 1, portraitArr[1]); //����
        portraitData.Add(2000 + 0, portraitArr[0]); //����� > none
        portraitData.Add(2000 + 1, portraitArr[1]); //����� > zero
        portraitData.Add(4000 + 3, portraitArr[3]); //���� 

        portraitData.Add(10000 + 1, portraitArr[1]); //�̸��𸦲� > zero
        portraitData.Add(11000 + 1, portraitArr[1]); //���ο�� > zero

        portraitData.Add(12000 + 1, portraitArr[1]); //������ > zero
        portraitData.Add(13000 + 1, portraitArr[1]); //�ڵ��� > zero
        portraitData.Add(14000 + 1, portraitArr[1]); //�´��� > zero
        portraitData.Add(15000 + 1, portraitArr[1]); //�ܹ����� > zero
        portraitData.Add(16000 + 1, portraitArr[1]); //�ܹ��� > zero


    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) //talkData�� ���� ���� ���� ���̵� ���� ��
        {
            if (!talkData.ContainsKey(id - id % 10)) //�ش� ����Ʈ�� ������ ��� �ƿ� x
            {
                if (talkData.ContainsKey(id - id % 100))
                    return GetTalk(id - id % 100, talkIndex);
                else
                    return GetTalk(-1000, talkIndex); //"��ȭ�� �� ������. ������ ���� �� ����." 
            }

            else //�ش� ����Ʈ�� ������ ������ ��ȭ�� ������ ���� ���� ��
            {
                return GetTalk(id - id % 10, talkIndex); //�ݺ� ��ȭ
            }
        }

        if (talkIndex == talkData[id].Length)
        {//talkIndex�� ��ȭ�� ���� ������ ���� ��ȭ�� �� Ȯ��
            return null;
        }
        else
            return talkData[id][talkIndex]; //�ε����� ���� �� ���徿 �������
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

}
