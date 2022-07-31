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

    //public enum GameMode { STORY,PLAY, SETTING, DIALOGUE };
    //public GameMode gameMode = GameMode.PLAY;

    //public enum PlayState { PLAY, SETTING, DIALOGUE};
    //public PlayState playState = PlayState.PLAY;
    
    //public enum UserState { MOVE, INTERACTION };
    //public UserState userState = UserState.MOVE;

    enum GameState { STORY, PLAY, SETTING, DIALOGUE};
    [SerializeField] GameState gameState = GameState.PLAY;
    enum UserState { MOVE, INTERACTION, HEAR};
    [SerializeField] UserState userState = UserState.MOVE;

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

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }


    public void SetGameStateToStory()
    {
        gameState = SetState(GameState.STORY);
    }
    public void SetGameStateToPlay()
    {
        gameState = SetState(GameState.PLAY);
    }
    public void SetGameStateToDialogue()
    {
        gameState = SetState(GameState.DIALOGUE);
    }
    public void SetGameStateToSetting()
    {
        gameState = SetState(GameState.SETTING);
    }
    public bool IsGameStateStory()
    {
        return IsGameState(GameState.STORY);
    }
    public bool IsGameStatePlay()
    {
        return IsGameState(GameState.PLAY);
    }
    public bool IsGameStateDialogue()
    {
        return IsGameState(GameState.DIALOGUE);
    }
    public bool IsGameStateSetting()
    {
        return IsGameState(GameState.SETTING);
    }

    public void SetUserStateToMove()
    {
        userState = SetState(UserState.MOVE);
    }
    public void SetUserStateToInteration()
    {
        userState = SetState(UserState.INTERACTION);
    }
    public void SetUserStateToHear()
    {
        userState = SetState(UserState.HEAR);
    }
    public bool IsUserStateMove()
    {
        return IsUserState(UserState.MOVE);
    }
    public bool IsUserStateInteraction()
    {
        return IsUserState(UserState.INTERACTION);
    }
    public bool IsUserStateHear()
    {
        return IsUserState(UserState.HEAR);
    }


   

    T SetState<T>(T state){
        return state;
    }

    bool IsGameState(GameState gs)
    {
        return (gameState == gs);
    }

    bool IsUserState(UserState gs)
    {
        return (userState == gs);
    }


}
