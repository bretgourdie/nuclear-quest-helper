using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> UniqueCards = default;
    [SerializeField] GameObject ActiveCard = default;
    [SerializeField] Transform InstantiatedLocation = default;
    [SerializeField] public List<Card> CardQueue = default;
    [SerializeField] public AudioClip DrawCardSound = default;

    private ActiveCard _activeCard;

    // Start is called before the first frame update
    void Start()
    {
        CardQueue = new List<Card>();
        _activeCard = ActiveCard.GetComponent<ActiveCard>();

        var cards = new List<Card>();
        foreach (var card in UniqueCards)
        {
            for (int ii = 0; ii < card.NumberInDeck; ii++)
            {
                var clonedCard = Instantiate(card, InstantiatedLocation.position, Quaternion.identity);
                clonedCard.transform.SetParent(InstantiatedLocation);
                cards.Add(clonedCard);
            }
        }

        while (cards.Count > 0)
        {
            var randomIndex = Random.Range(0, cards.Count);

            var removed = cards[randomIndex];

            cards.RemoveAt(randomIndex);

            CardQueue.Add(removed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        if (CardQueue.Count > 0)
        {
            var card = CardQueue[0];
            CardQueue.RemoveAt(0);
            _activeCard.Card = card;
            AudioSource.PlayClipAtPoint(DrawCardSound, Camera.main.transform.position);
        }
    }

    public void ReturnCard(Card card)
    {
        CardQueue.Add(card);
        _activeCard.Card = null;
        card.transform.position = InstantiatedLocation.position;
    }

    public void OnMouseDown()
    {
        if (_activeCard.Card == null)
        {
            DrawCard();
        }
    }
}
