using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����
    
    public bool isGameover { get; private set; } // ���� ���� ����

    // ���� ���� ����
    //0 : HUI, 1 : ENJOY, 2 : WANT, ...
    public bool[] belongEmotions = new bool[3] { false, false, false };
    public bool[] spawnEmotions = new bool[3] { true, false, false };

    //public enum MouseState { BASIC,MOUSEOVER, DIALOGUE, CAMERA};
    //public MouseState mouseState = MouseState.BASIC;

    public enum PlayState { PLAY, SETTING, DIALOGUE};
    public PlayState playState = PlayState.PLAY;
    
    
    public enum UserState { MOVE, INTERACTION };
    public UserState userState = UserState.MOVE;

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        print("game start");
    }

    public void SetPlayStateToPlay()
    {
        playState = PlayState.PLAY;
    }
    public void SetPlayStateToSetting()
    {
        playState = PlayState.SETTING;
    }
    public void SetPlayStateDialogue()
    {
        playState = PlayState.DIALOGUE;
    }
    public bool IsPlayStatePlay()
    {
        return (playState == PlayState.PLAY);
    }
    public bool IsPlayStateSetting()
    {
        return (playState == PlayState.SETTING);
    }
    public bool IsPlayStateDialogue()
    {
        return (playState == PlayState.DIALOGUE);
    }

    public void SetUserStateMove()
    {
        userState = UserState.MOVE;
    }
    public void SetUserStateInteraction()
    {
        userState = UserState.INTERACTION;
    }

    public bool IsUserMoveMode()
    {
        return (userState == UserState.MOVE);
    }
    public bool IsUserInteractionMode()
    {
        return (userState == UserState.INTERACTION);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

}
