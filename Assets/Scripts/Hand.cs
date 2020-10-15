using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject ActiveCard;
    [SerializeField] GameObject GeigerCounter;
    [SerializeField] Transform HeldCardsLocation;

    private ActiveCard _activeCard;
    private Slider _slider;

    private List<GameObject> _playCards;
    private List<GameObject> _gammaCards;

    // Start is called before the first frame update
    void Start()
    {
        _playCards = new List<GameObject>();
        _gammaCards = new List<GameObject>();

        _activeCard = ActiveCard.GetComponent<ActiveCard>();
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

            _activeCard.Card = null;
            card.transform.position = HeldCardsLocation.position;
        }
    }

    private void handlePlayCardGain(PlayCard playCard)
    {
        if (!isReal(playCard))
        {
            return;
        }

        addToList(playCard.gameObject, _playCards);
    }

    private void handleGammaCardGain(GammaCard gammaCard)
    {
        if (!isReal(gammaCard))
        {
            return;
        }

        addToList(gammaCard.gameObject, _gammaCards);

        handleGeigerAdjustment(_slider, gammaCard.RadiationAmount);
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
