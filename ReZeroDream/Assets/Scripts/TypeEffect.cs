using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds; //��� �ӵ� ����: 1�ʿ� �� ��
    public bool isAnim;
    string targetMsg; //ǥ���� ��ȭ �޽���
    TextMeshProUGUI msgText;
    AudioSource audioSource;
    int index; 
    float interval;
    

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg) //��ȭ ���ڿ� �޴� �Լ�
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart() //����
    {
        msgText.text = "";
        index = 0;

        isAnim = true; //�ؽ�Ʈ �ִϸ��̼� ����

        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);

    }

    void Effecting() //��� ��
    {
        GameManager.instance.SetUserStateToHear();
        if (msgText.text == targetMsg) // ��ȭ �� ���
        {
            GameManager.instance.SetUserStateToInteration();
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index]; //string: char�� �迭
        if(targetMsg[index] != ' ' && targetMsg[index] != '.')
            audioSource.Play();
        
        index++;
        Invoke("Effecting", interval); //Invoke: �ð��� �ݺ� ȣ��
    }

    void EffectEnd() //����
    {
        isAnim = false;
    }
}
