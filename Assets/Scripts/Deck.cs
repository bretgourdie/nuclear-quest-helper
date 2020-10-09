using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> UniqueCards;
    [SerializeField] GameObject ActiveCard;
    [SerializeField] Transform InstantiatedLocation;

    private ActiveCard _activeCard;

    private Queue<Card> _cardQueue;

    // Start is called before the first frame update
    void Start()
    {
        _cardQueue = new Queue<Card>();
        _activeCard = ActiveCard.GetComponent<ActiveCard>();

        var cards = new List<Card>();
        foreach (var card in UniqueCards)
        {
            for (int ii = 0; ii < card.NumberInDeck; ii++)
            {
                cards.Add(Instantiate(card, InstantiatedLocation));
            }
        }

        while (cards.Count > 0)
        {
            var randomIndex = Random.Range(0, cards.Count);

            var removed = cards[randomIndex];

            cards.RemoveAt(randomIndex);

            _cardQueue.Enqueue(removed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Card _drawCard()
    {
        if (_cardQueue.Count > 0)
        {
            return _cardQueue.Dequeue();
        }

        return null;
    }

    private void _returnCard(Card card)
    {
        _cardQueue.Enqueue(card);
        card.transform.position = InstantiatedLocation.position;
    }

    public void OnMouseDown()
    {
        if (_activeCard.Card == null)
        {
            var card = _drawCard();
            _activeCard.Card = card;
            card.transform.position = _activeCard.transform.position;
        }
    }
}
