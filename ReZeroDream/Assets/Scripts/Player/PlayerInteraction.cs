using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private PlayerState playerState; //����޴� �κ�
    private Animator playerAnimator;
    private PlayerInput playerInput;
    private DialogueManager dialogueManager;
    private QuestManager questManager;

    //enum LiftState { ReadyLift, StartLift, EndLift};
    //LiftState liftState = LiftState.EndLift;
    public Transform throwItemPos;
    public GameObject liftedItem { get; private set; }
    public GameObject throwItem { get; private set; }
    void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerInput = GetComponent<PlayerInput>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        questManager = FindObjectOfType<QuestManager>();
        playerAnimator = GetComponent<Animator>();
    }


    private void Update()
    {

        Click();
        Lift();

        if (GameManager.instance.IsUserStateThrowReady() && throwItem)
        {
            throwItem.transform.position = throwItemPos.position;
            //throwItem.transform.SetParent(throwItemPos, true);
        }
    }

    void Click()
    {
        clickUI();

        if (playerInput.Lclick)
        {
            if (GameManager.instance.IsGameStateStory()) return;

            if (GameManager.instance.IsUserStateThrowReady())
            {
                GameManager.instance.SetUserStateToThrow();
                throwItem.GetComponent<throwSleepBall>().Launch();
                GameManager.instance.SetUserStateToMove();
                return;
            }


            //������ Ų ���
            if (GameManager.instance.IsGameStatePlay() && dialogueManager.isAction)
            {
                UIManager.instance.OnOffDialogueWindow(false);

                GameManager.instance.SetGameStateToPlay();
                GameManager.instance.SetUserStateToMove();
            }
            //���� ȥ�㸻
            if (questManager.nowDialogueObject == 3000 && dialogueManager.zeroTalk)
            {
                if (!GameManager.instance.IsUserStateHear())
                {
                    dialogueManager.Action(gameObject); //�� script�� �پ��ִ� gameObject�� ��ȯ. �� gameobject == zero
                }
                return;
            }

            else { 
            }

            if (!playerInput.scanObject)
            {
                if (dialogueManager.isAction)
                {
                    //����
                    dialogueManager.talkIndex = 0;
                    dialogueManager.isAction = false;
                    UIManager.instance.OnOffDialogueWindow(false);

                    GameManager.instance.SetGameStateToPlay();
                    GameManager.instance.SetUserStateToMove();
                }
                return;
            }

            if (playerInput.scanObject.name == "NPC_Cat")
            {
                if (GameManager.instance.spawnMemories[0] && !GameManager.instance.belongEmotions[0]) return;
            }

            if (!GameManager.instance.IsUserStateHear())
            {
                if (playerInput.scanObject.GetComponent<ObjData>().isNpc)
                    playerInput.scanObject.transform.LookAt(transform);

                dialogueManager.Action(playerInput.scanObject);
            }

        }
    }

    void clickUI()
    {
        
        UIManager.instance.OnOffPlayerClickImage(((playerInput.scanObject) ? true : false));
        if(!GameManager.instance.IsGameStatePlay() || !GameManager.instance.IsUserStateMove())
        {
            UIManager.instance.OnOffPlayerClickImage(false);
        }

    }


    bool canLift = false;
    bool canThrow = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            canLift = true;
            liftedItem = other.gameObject;
        }
        if(other.tag == "attackItem")
        {
            canThrow = true;
            throwItem = other.gameObject;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            canLift = true;
            liftedItem = other.gameObject;
        }
        if (other.tag == "attackItem")
        {
            canThrow = true;
            throwItem = other.gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        canLift = false;
        liftedItem = null;
        if (!GameManager.instance.IsUserStateThrowReady())
        {

            canThrow = false;
            throwItem = null;

        }

    }

    void Lift()
    {
        liftUI();

        if (playerInput.lift)
        {
            if (canLift)
            {
                canLift = false;
                playerState.CheckLiftedItem(liftedItem);

            }
            if (throwItem)
            {

                GameManager.instance.SetUserStateToThrowReady();
            }
        }

        //playerAnimator.SetBool("isLift", liftState == LiftState.StartLift ? true : false);

        //if (liftState == LiftState.ReadyLift)
        //{
        //    if (playerInput.lift)
        //    {
        //        GameManager.instance.SetUserStateToInteration();
        //        liftState = LiftState.StartLift;
        //        playerState.CheckLiftedItem(liftedItem);
        //        StartCoroutine(WaitLifting());
        //    }
        //}
    }

    void liftUI()
    {
        UIManager.instance.OnOffPlayerLiftImage(canLift? true : false);
    }

    
}
