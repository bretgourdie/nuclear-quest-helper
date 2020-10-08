using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> Cards;

    private Queue<Card> cardQueue;

    // Start is called before the first frame update
    void Start()
    {
        var cards = new List<Card>(Cards);
        while (cards.Count > 0)
        {
            var randomIndex = Random.Range(0, cards.Count);

            var removed = cards[randomIndex];

            cards.RemoveAt(randomIndex);

            cardQueue.Enqueue(removed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card DrawCard()
    {
        if (cardQueue.Count > 0)
        {
            return cardQueue.Dequeue();
        }

        return null;
    }

    public void DiscardCard(Card card)
    {
        cardQueue.Enqueue(card);
    }
}
