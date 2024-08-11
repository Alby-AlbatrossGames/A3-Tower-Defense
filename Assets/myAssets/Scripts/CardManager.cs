using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CardManager : GameBehaviour
{
    private enum CardType { Tower, HP, Coin }
    private int maxHandSize;
    private int curHandSize;
    public List<GameObject> cardSlots;


}
