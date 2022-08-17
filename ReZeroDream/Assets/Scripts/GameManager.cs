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
    //public GameObject[] spawnEmotions = new GameObject[3];
    public GameObject[] spawnMemories = new GameObject[3];

    enum StoryState { HUI, ENJOY, WANT };
    [SerializeField] StoryState storyState = StoryState.HUI;
    enum GameState { STORY, PLAY, SETTING, DIALOGUE};
    [SerializeField] GameState gameState = GameState.PLAY;
    enum UserState { MOVE, INTERACTION, HEAR, FLOATING, DEFENCE, THROWREADY, THROW};
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
        if (IsStoryStateEnjoy())
        {
            FindObjectOfType<QuestManager>().questId = 40;
            FindObjectOfType<QuestManager>().questAcitonIndex = 0;

        }
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
    public void SetUserStateToFloating()
    {
        userState = SetState(UserState.FLOATING);
    }
    public void SetUserStateToThrowReady()
    {
        userState = SetState(UserState.THROWREADY);
    }
    public void SetUserStateToThrow()
    {
        userState = SetState(UserState.THROW);
    }
    public bool IsUserStateThrow()
    {
        return IsUserState(UserState.THROW);
    }
    public bool IsUserStateThrowReady()
    {
        return IsUserState(UserState.THROWREADY);
    }
    public bool IsUserStateFloating()
    {
        return IsUserState(UserState.FLOATING);
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

    public void SetStoryStateToHui()
    {
        storyState = SetState(StoryState.HUI);
    }
    public void SetStoryStateToEnjoy()
    {
        storyState = SetState(StoryState.ENJOY);
    }
    public void SetStoryStateToWant()
    {
        storyState = SetState(StoryState.WANT);
    }
    public bool IsStoryStateHui()
    {
        return IsStoryState(StoryState.HUI);
    }
    public bool IsStoryStateEnjoy()
    {
        return IsStoryState(StoryState.ENJOY);
    }
    public bool IsStoryStateWant()
    {
        return IsStoryState(StoryState.WANT);
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

    bool IsStoryState(StoryState gs)
    {
        return (storyState == gs);
    }
}
