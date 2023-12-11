using UnityEngine;

public class GamplayStateMachine : MonoBehaviour
{
    private enum States { SHUFFLE_DECK, USERACTION, BATTLE, USER_ALIVE, DEATH, STAGE_CLEAR }

    [Header("Level Rounds")]
    [SerializeField] private int totalRounds;

    private int currentRound = 1;
    private States currentState = States.SHUFFLE_DECK;

    private void Start()
    {
        UI_Manager._UI_MANAGER.UpdateTotalRounds(totalRounds);
        UI_Manager._UI_MANAGER.UpdateCurrentRound(currentRound);
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.SHUFFLE_DECK:
                ShuffleDeck();
                break;
            case States.USERACTION:
                UserAction();
                break;
            case States.BATTLE:
                Battle();
                break;
            case States.USER_ALIVE:
                UserAlive();
                break;
            case States.DEATH:
                Death();
                break;
            case States.STAGE_CLEAR:
                StageClear();
                break;
            default:
                break;
        }
    }

    private void ShuffleDeck()
    {

    }

    private void UserAction()
    {

    }

    private void Battle()
    {

    }

    private void UserAlive()
    {

    }

    private void Death()
    {

    }

    private void StageClear()
    {

    }
}
