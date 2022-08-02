using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    private static UIManager m_instance;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }



    [Header("Player")]
    [SerializeField] private UIView playerClickImage;
    [SerializeField] private UIView playerLiftImage;


    [Header("Dialogue")]
    [SerializeField] private UIView dialogueWindow;
    [SerializeField] private UIView dialoguePortraitImg;
    [SerializeField] private UIView dialogueObjectNameText;
    [SerializeField] private UIView dialogueTalkText;
    [SerializeField] private Animator animator;


    [Header("Story - Cat")]
    [SerializeField] public UIView catNameWindow;
    [SerializeField] private UIView InputCatName;

    [Header("Quest Min")]
    //[SerializeField] private Image[] questStateArr;
    [SerializeField] private UIView questMinWindow;
    [SerializeField] private UIView questMinText;
    [Header("Quest Max")]
    [SerializeField] private UIView questMaxWindow;
    [SerializeField] private UIView questMaxText;
    [SerializeField] private UIView questMaxDescriptText;
    [SerializeField] private UIView questMaxContentText;
    [SerializeField] private UIView questWindowRewardText;
    //[SerializeField] private GameObject qwOnButton;
    //[SerializeField] private GameObject qwOffButton;

    private QuestManager questManager;


    private void Start()
    {
        catNameWindow.Hide();


        questManager = FindObjectOfType<QuestManager>();
        SetFirstQuestUI(); //����ƮUI�ʱ�ȭ (������ ��ȭ ���� ���� �Ҹ��ϱ�)
    }

    // *****     [Header("Player")]     *******
    public void OnOffPlayerClickImage(bool isActive)
    {
        playerClickImage.ShowAndHide(isActive);
    }

    public void OnOffPlayerLiftImage(bool isActive)
    {
        playerLiftImage.ShowAndHide(isActive);
    }

    // *****     [Header("Dialogue")]     *******
    public void OnOffDialogueWindow(bool active) { 
        
        if(active)
        {
            dialogueWindow.Show();
            animator.SetTrigger("show");

        }
        else
        {
            //dialogueWindow.Hide();
            animator.SetTrigger("hide");
            Debug.Log("off");
        }

        //dialogueWindow.ShowAndHide(active);

    }

    public void UpdateDialogeText(string name, string talk)
    {
        dialogueTalkText.UpdateTextEffect(talk);
        dialogueObjectNameText.UpdateTextMeshProUGUI(name);
    }

    public void UpdateDialoguePortraitImage(Sprite portrait)
    {
        dialoguePortraitImg.UpdateImage(portrait);
        dialoguePortraitImg.UpdateColor(new Color(1, 1, 1, 1));
    }


    // *****     [Header("CatName")]     *******
    public void OnOffCatNameWindow(bool active) { catNameWindow.ShowAndHide(active); }


    /// ============== ���� �� =====================
    /// 
    public void OnQuestMaxOffQuestMinWindow()
    {
        questMinWindow.Hide();
        questMaxWindow.Show();
        //qwOffButton.SetActive(true);
        //qwOnButton.SetActive(false);
    }

    public void OffQuestMaxOnQuestMinWindow()
    {
        questMaxWindow.Hide();
        questMinWindow.Show();
        //qwOnButton.SetActive(true);
        //qwOffButton.SetActive(false);
    }

    private void SetFirstQuestUI()
    {
        //isQuest = false;
        questMinWindow.Show();
        questMaxWindow.Hide();

        //qwOnButton.SetActive(true);
        //qwOffButton.SetActive(false);
        questMinText.UpdateTextMeshProUGUI("???�� ��ȭ�ϱ�");
        questMaxText.UpdateTextMeshProUGUI("???�� ��ȭ�ϱ�");
        questMaxDescriptText.UpdateTextMeshProUGUI("???���� ��ȭ�� �ɾ� �̰��� ���� ������ ����.");
        questMaxContentText.UpdateTextMeshProUGUI("???�� ��ȭ�ϱ�");
        questWindowRewardText.UpdateTextMeshProUGUI(" ");
    }

    //���⼭ ����� DialogueManager���� ȣ�� (CheckQuest���� npcId > questId)
    public void UpdateQuestUI(int npcId)
    {
        string npc = questManager.CheckQuest(npcId);

        questMinText.UpdateTextMeshProUGUI(npc);
        questMaxText.UpdateTextMeshProUGUI(npc);
        questMaxDescriptText.UpdateTextMeshProUGUI(questManager.qwDescript);
        questMaxContentText.UpdateTextMeshProUGUI(questManager.qwContent);
        questWindowRewardText.UpdateTextMeshProUGUI(questManager.qwReward);
    }



    //�ָ�..
    public void UpdateCatName() {
        string catName = catNameWindow.getTextMeshProInputField();
        GameObject cat = GameObject.Find("NPC_Cat");
        cat.GetComponent<ObjData>()._name = catName;
        FindObjectOfType<DialogueManager>().Action(cat);
    }

    public void OnEndEdit(string str)
    {
        print("on End edit");
        string catName = catNameWindow.getTextMeshProInputField();
        catName = InputCatName.changeKoreanText(catName);

        GameObject cat = GameObject.Find("NPC_Cat");
        cat.GetComponent<ObjData>()._name = catName;
        FindObjectOfType<DialogueManager>().Action(cat);

        OnOffCatNameWindow(false);
        GameManager.instance.SetGameStateToDialogue();
    }

}
