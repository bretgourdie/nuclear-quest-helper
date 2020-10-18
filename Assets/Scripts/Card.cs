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
        Deck deck = default;
        if (GetComponent<PlayCard>() != null)
        {
            deck = findDeck("PlayDeckUI");
        }

        else if (GetComponent<GammaCard>() != null)
        {
            deck = findDeck("GammaDeckUI");
        }

        deck.ReturnCard(this);
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
