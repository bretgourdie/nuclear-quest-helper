using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] public int NumberInDeck = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToDeck()
    {
        string deckName = GetComponent<PlayCard>() != null
            ? "PlayDeckUI"
            : "GammaDeckUI";

        var deck = findDeck(deckName);

        deck.ReturnCard(this);

        removeCardFromHand();
    }

    private void removeCardFromHand()
    {
        var hands = FindObjectsOfType<Hand>();

        foreach (var hand in hands)
        {
            if (hand.HasCard(this))
            {
                hand.LoseCard(this);
                return;
            }
        }
    }

    private Deck findDeck(string deckName)
    {
        var decks = FindObjectsOfType<Deck>();
        foreach (var deck in decks)
        {
            if (deck.name == deckName)
            {
                return deck;
            }
        }

        return null;
    }
}
