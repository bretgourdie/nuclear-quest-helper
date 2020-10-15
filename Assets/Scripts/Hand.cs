using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject ActiveCard;

    private ActiveCard _activeCard;

    // Start is called before the first frame update
    void Start()
    {
        _activeCard = ActiveCard.GetComponent<ActiveCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAcceptCard()
    {
        if (_activeCard.Card != null)
        {
            var card = _activeCard.Card;

            handlePlayCardDrop(card.GetComponent<PlayCard>());

            handleGammaCardDrop(card.GetComponent<GammaCard>());

            _activeCard.Card = null;
        }
    }

    private void handlePlayCardDrop(PlayCard playCard)
    {
        if (playCard == null)
        {
            return;
        }

        Debug.Log("PlayCard detected");
    }

    private void handleGammaCardDrop(GammaCard gammaCard)
    {
        if (gammaCard == null)
        {
            return;
        }

        Debug.Log("Gamma detected");
    }
}
