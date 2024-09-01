using System.Collections.Generic;
using UnityEngine;

public enum CardType { HP, MP }
public class Player : Singleton<Player>
{
    public int mHP = 25;
    public int cHP = 25;

    private int maxHandSize;
    private int curHandSize;

    public List<GameObject> myHand;


    private void Start()
    {
        cHP = mHP;
        //fill the 56-card deck with RANDOM cards.
        for (int i = 0; i < 56; i++)
        {
            //Card newCard = new Card();
            Card newCard = ScriptableObject.CreateInstance<Card>();

            if (Random.Range(0, 2) >= 1)
                newCard.type = CardType.HP;
            else
                newCard.type = CardType.MP;

            deck.Add(newCard);
            Debug.LogWarning($"{newCard.type} {newCard.value}");
        }
        Debug.LogError($"card #7: {deck[7].type} {deck[7].value}");
    }

    public void TakeDamage()
    {
        if (cHP <= 1)
        {
            //GameOver Goes Here
            _SC.LoadMainMenu();
            return;
        }
        cHP -= 1;
        //update player health UI
        _UM.UpdatePlayerUI();
    }

    public List<Card> deck;
}

public class Card : ScriptableObject
{
    public CardType type;
    public int value;
}