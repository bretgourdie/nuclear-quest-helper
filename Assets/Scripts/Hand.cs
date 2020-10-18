using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject ActiveCard;
    [SerializeField] GameObject GeigerCounter;
    [SerializeField] GameObject PlayCardsDeck;
    [SerializeField] GameObject GammaCardsDeck;
    [SerializeField] GameObject SkipTurnMarker;

    [SerializeField] Transform HeldCardsLocation;

    private ActiveCard _activeCard;
    private Deck _gammaCardsDeck;
    private Deck _playCardsDeck;
    private Toggle _skipTurnMarker;
    private Slider _slider;

    private float _handCardHorizontalOffset = 50;
    private float _handCardVerticalOffset = 30;

    private List<GameObject> _playCards;
    private List<GameObject> _gammaCards;

    // Start is called before the first frame update
    void Start()
    {
        _playCards = new List<GameObject>();
        _gammaCards = new List<GameObject>();

        _activeCard = ActiveCard.GetComponent<ActiveCard>();
        _gammaCardsDeck = GammaCardsDeck.GetComponent<Deck>();
        _playCardsDeck = PlayCardsDeck.GetComponent<Deck>();
        _skipTurnMarker = SkipTurnMarker.GetComponent<Toggle>();
        _slider = GeigerCounter.GetComponent<Slider>();
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

            handlePlayCardGain(card.GetComponent<PlayCard>());

            handleGammaCardGain(card.GetComponent<GammaCard>());
        }
    }

    private void handlePlayCardGain(PlayCard playCard)
    {
        if (!isReal(playCard))
        {
            return;
        }

        if (playCard.PlaysImmediately)
        {
            var card = playCard.gameObject.GetComponent<Card>();
            _playCardsDeck.ReturnCard(card);
        }

        else
        {
            addToList(playCard.gameObject, _playCards);
            resetCardStack(_playCards);
        }

        handleSkipTurnMarker(playCard.SkipNextTurn);

        cardIsNoLongerActive();

        if (playCard.DrawRadiationAfterUse)
        {
            _gammaCardsDeck.DrawCard();
        }
    }

    private void handleLoseAllGammaRadiation(bool loseAllGammaRadiation)
    {
        if (loseAllGammaRadiation)
        {
            foreach (var gammaCard in _gammaCards)
            {
                _slider.value -= gammaCard.GetComponent<GammaCard>().RadiationAmount;
                _gammaCardsDeck.ReturnCard(gammaCard.GetComponent<Card>());
            }

            _gammaCards.RemoveAll(x => true);
        }
    }

    private void handleGammaCardGain(GammaCard gammaCard)
    {
        if (!isReal(gammaCard))
        {
            return;
        }

        addToList(gammaCard.gameObject, _gammaCards);

        resetCardStack(_gammaCards);

        handleGeigerAdjustment(_slider, gammaCard.RadiationAmount);

        handleSkipTurnMarker(_slider.value >= _slider.maxValue);

        cardIsNoLongerActive();
    }

    private void handleSkipTurnMarker(bool shouldCheck)
    {
        _skipTurnMarker.isOn = shouldCheck;
    }

    private void resetCardStack(List<GameObject> deck)
    {
        for (int ii = 0; ii < deck.Count; ii++)
        {
            var card = deck[ii];

            var isPlayCard = card.GetComponent<PlayCard>() != null;

            float horizontalOffset = _handCardHorizontalOffset * (isPlayCard ? -1 : 1);

            card.transform.position = new Vector3(
                gameObject.transform.position.x + horizontalOffset,
                gameObject.transform.position.y + ii * _handCardVerticalOffset,
                gameObject.transform.position.z);

            card.transform.localScale = new Vector3(.5f, .5f);

            card.transform.SetAsLastSibling();
        }
    }

    private void cardIsNoLongerActive()
    {
        _activeCard.Card = null;
    }

    private void handleGeigerAdjustment(Slider slider, int radiationAmount)
    {
        if (slider != null)
        {
            slider.value += radiationAmount;
        }
    }

    private void handleGammaCardDiscard(GammaCard gammaCard)
    {
        if (!isReal(gammaCard))
        {
            return;
        }

        handleGeigerAdjustment(_slider, -gammaCard.RadiationAmount);
    }

    private void handlePlayCardDiscard(PlayCard playCard)
    {
        if (!isReal(playCard))
        {
            return;
        }
    }

    private bool isReal(Component component)
    {
        return component != null;
    }

    private void addToList(GameObject gameObject, List<GameObject> list)
    {
        list.Add(gameObject);
    }

    private void removeFromList(GameObject gameObject, List<GameObject> list)
    {
        list.Remove(gameObject);
    }
}
