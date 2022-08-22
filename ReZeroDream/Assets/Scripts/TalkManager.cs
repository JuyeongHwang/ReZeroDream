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
        


        //Quest Talks
        talkData.Add(10 + 3000, new string[] { "�����... �����? ������ ���� ����̾�.:1" });
        talkData.Add(11 + 3000, new string[] { "�� ���̴� ������...? �� �̷� ���� �ִ� �ɱ�?:1" });
        talkData.Add(12 + 1000, new string[] { "�� �� ���� �𸣴±���.:2", "���� ���ؼ� �˾ƺ� �ٷ�?:2" });

        talkData.Add(20 + 1000, new string[] { "�� ��𿡵� �־�.:2", "�ֺ��� �ѷ����� ���ڴ�?:2" });
        talkData.Add(21 + 3000, new string[] { "�̰� ����? �� ������ �ٰ�������?:1" });
        talkData.Add(22 + 3000, new string[] { "�� ���̴� ��� ����ϴ°���? �׸��� �׷����־�...:1" });
        talkData.Add(23 + 2000, new string[] { "�Ŀ�.:0", "�ε巴��, ������... ���� �������� ������ ������.:1", ":0", "�¾�. ���� Ű��� ����� �̸���...:1", "�ľ�.:0" });
        talkData.Add(24 + 1000, new string[] { "�� ����̸� ��������.:2", "������ ������ ���� �𸣴� �� ����.:2", "���� ���� �� ã�ƿ� �ٷ�?\n�ʰ� �����ߴ� �͵��� ���÷���.:2" });

        
        talkData.Add(30 + 10000, new string[] { "�̰�... �ƴ� �� ����.:1" });
        talkData.Add(30 + 11000, new string[] { "�ͼ��ϰ� ���� ��Ⱑ ��...:1", "�ε鷹���̱���. �ɸ��� �ູ...:1", "����̿� �ε鷹,\n�� ���̿� �����ִ� �� ��� ���� �����ϴ� �͵��̾�.:1","�� ���̴� �� ��� �� ��� �˰��ִ� �ɱ�?:1"});

        talkData.Add(32 + 1000, new string[] { "���� ���� ������ �����߾����� ��ﳵ��.:1", "����ü �ʴ� ������?:1", "���� ���. ���� �ʰ� �����ϴ� ���̶��\n�����̵� �� �� �ְ�, ��𿡵� ���� �� ����.:2", "���� ���� ���� �˰ڴ�?:2" });
        //�� ��ȭ > ���� ȥ�㸻 ���⼭ �ϸ� ������
        talkData.Add(33 + 3000, new string[] { "���� �����ݾ�?:1", "���ݱ��� ���� �ִ� ���� �̷��� ���� ���̾�����...:1" });
        talkData.Add(34 + 1000, new string[] { "����, ������ ���� ��ã���� ���̾�.:2", "�ƽ����� ���� �������� ���ư��� �� �ð��̾�.:2", "�ʶ�� �� �س� �� ���� �ž�.:2", "�� ������ �ʿ� �Բ��ϰ� ������, �����δ� �� ���� ������.:2"});

        talkData.Add(40 + 3000, new string[] { "�����Ⱑ �޶�����.:1", "����� ���ð� �����ִ� �͸� ����.:1", "�������鼭 �� �ǹ� ���󿡼� ���𰡸� �� �� ������...:1", "Ȯ���غ���?:1" });
        talkData.Add(42 + 3000, new string[] { "�Ʊ� ����� ��ȭ���ݾ�?:1", "�׷����� ������ �޶�. ��ſ��� �����̶�...:1", "�ܹ��ſ� �ڵ����� ���� �ǹ��ϱ�?:1", "�ٽ� ������ �ֺ��� �ѷ����� �ܼ��� ����.:1" });
        talkData.Add(50 + 3000, new string[] { "���� ����?:1", "�̻��� ����ü�� ���ƴٴϰ� �־�.\n�и� �Ʊ�� �����µ�...:1", "���𰡸� ��Ű�� �ִ� �� ����.\n������ ���� �� �������� ���� �� ���� ������ ���...:1", "�׷��� �� ���ǵ��� ����?:1", "���Ǹ��� ���ݾ� �ٸ� �� ������ �ϳ��� ������ Ȯ���غ���.:1" });

        talkData.Add(60 + 12000, new string[] { "��������. �׷��� ����� ���� �� ����.:1" });
        talkData.Add(60 + 13000, new string[] { "����� �ڵ����̴�.:1" });
        talkData.Add(60 + 14000, new string[] { "����? �� ���� ���� �ͼ���.:1", "�׷����� ������ ������� �Բ� �� ���� Ÿ�� ���̰����� ������.:1", "�׶� ���� ��ſ����µ�...:1" }); //�̸� �ϴ� ���η� (���ΰ� ���� ��ó�� ���;� �ϴϱ�)

        talkData.Add(70 + 3000, new string[] { "�ܹ������� ���� �谡 ������... �� �� ������?:1" }); //�ܹ����� �߰� > questId == 70, zeroTalk = true
        talkData.Add(71 + 3000, new string[] { "���, ����� ����� ���ݾ�! :1", "������� �԰� �ִ� ������ ���־� ����.:1", "��, �����... �������� ���� �ܹ��Ÿ� �ֹ��غ���.:1" });
        talkData.Add(72 + 4000, new string[] { "�̾������� ���̻� �ܹ��Ŵ� �� �� ����.\n�̹� ��ᰡ �� �������ŵ�.:3", "��, �� ������ٸ� �ֺ����� ���� ã�ƺ�.:3", "���� �ܹ��Ÿ� ������ �ڸ��� ���� ������ ������ �ٰ�.:3" });
        //����... �ܹ��� = ��ſ��̴ϱ� ���ΰ� �б����� ������ ���̻� ����� �ʴٴ� ���� �ؼ��� ���� ���� �� ���Ƽ� ��縦 �̷� ������ ����ҽ��ϴ�
        talkData.Add(73 + 15000, new string[] { "������ ���ߴ� �ܹ��Ű� ���� �̰ǰ�?:1", "�� �ܹ��Ŵ� �ʹ� Ŀ�� ���Է� ������ �� ���� �� ������...\n �ٽ� �������� ���� �����.:1"  });
        talkData.Add(74 + 4000, new string[] { "��? �� �ܹ��Ÿ� �Ծ �ǳİ�?:3", "�ƴ�, �ܹ��Ÿ� ã�ƿ���� �� ����̾���. :3", "�ڸ��� �ɾ������� �ܹ��Ÿ� �������ٰ�.:3" });
       //������ �ó׸�ƽ ���
        talkData.Add(80 + 1000, new string[] { " " });
        talkData.Add(90 + 1000, new string[] { " " });

        //portraitArr 0: none/ 1: zero/ 2: happy/ 3:enzo
        portraitData.Add(1000 + 2, portraitArr[2]); //����
        portraitData.Add(1000 + 1, portraitArr[1]); //���� >> ����
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
