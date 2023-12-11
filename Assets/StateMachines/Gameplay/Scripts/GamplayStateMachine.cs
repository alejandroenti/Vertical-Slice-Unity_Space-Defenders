using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamplayStateMachine : MonoBehaviour
{
    private enum States { START_STAGE, SHUFFLE_DECK, USERACTION, BATTLE, USER_ALIVE, DEATH, STAGE_CLEAR }

    private const int HAND_SIZE = 4;

    [Header("Level Rounds")]
    [SerializeField] private int totalRounds;

    [Header("States Times")]
    [SerializeField] private float startingStageMaxTime = 5f;
    [SerializeField] private float shuffleMaxTime = 8f;
    [SerializeField] private float userActionMaxTime = 10f;

    private int currentRound = 1;
    private States currentState = States.START_STAGE;

    private List<Card> original = new List<Card>();
    private List<Card> cards = new List<Card>();

    private float startingStagetimer = 0f;
    private float userActiontimer = 0f;

    private bool isStateWorking = false;

    private void Awake()
    {
        original = Game_Manager._Game_Manager.GetCardDeck();
    }

    private void Start()
    {
        UI_Manager._UI_MANAGER.UpdateTotalRounds(totalRounds);
        UI_Manager._UI_MANAGER.UpdateCurrentRound(currentRound);
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.START_STAGE:
                StartStage();
                break;
            case States.SHUFFLE_DECK:
                if (!isStateWorking)
                {
                    StartCoroutine(ShuffleDeck());
                }
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

    private void StartStage()
    {
        UI_Manager._UI_MANAGER.UpdateCurrentState("STARTING STAGE");

        startingStagetimer += Time.deltaTime;

        if (startingStagetimer >= startingStageMaxTime)
        {
            currentState = States.SHUFFLE_DECK;
            startingStagetimer = 0f;
        }
    }

    IEnumerator ShuffleDeck()
    {
        isStateWorking = true;

        UI_Manager._UI_MANAGER.UpdateCurrentState("SHUFFLING CARDS");

        // BARAJAR LAS CARTAS ACTUALES
        cards = Shuffle(original);


        yield return new WaitForSeconds(shuffleMaxTime);

        // REPARTIR 5 CARTAS EN LA MANO
        PlaceTopCards();

        currentState = States.USERACTION;
        isStateWorking = false;
        UI_Manager._UI_MANAGER.ShowDeckContainer();
    }

    private void UserAction()
    {
        UI_Manager._UI_MANAGER.UpdateCurrentState("USER ACTION");

        userActiontimer += Time.deltaTime;

        if (userActiontimer >= userActionMaxTime)
        {
            currentState = States.START_STAGE;
            userActiontimer = 0f;
            UI_Manager._UI_MANAGER.HideDeckContainer();
        }
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

    private List<Card> Shuffle(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card tempCard = deck[i];
            int rand = Random.Range(i, deck.Count);
            deck[i] = deck[rand];
            deck[rand] = tempCard;
        }

        return deck;
    }

    private void PlaceTopCards()
    {
        if (cards.Count < HAND_SIZE)
        {
            PlaceCards(cards.Count);
            return;
        }

        PlaceCards(HAND_SIZE);
    }

    private void PlaceCards(int size)
    {
        for (int i = 0; i < size; i++)
        {
            UI_Manager._UI_MANAGER.SetNewCardToHand(cards[i], i);
        }
    }
}