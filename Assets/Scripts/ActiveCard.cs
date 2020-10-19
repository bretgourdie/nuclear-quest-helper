using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCard : MonoBehaviour
{
    [SerializeField] GameObject Instructions = default;

    private Text _instructionText;

    private Card _card;
    public Card Card
    {
        get => _card;
        set
        {
            _card = value;

            if (_card != null)
            {
                _card.transform.position = transform.position;
            }

            setInstructionText(_card);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instructionText = Instructions.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setInstructionText(Card card)
    {
        var playCard = card?.GetComponent<PlayCard>();

        if (card == null || playCard == null)
        {
            _instructionText.text = string.Empty;
            return;
        }

        if (!playCard.PlaysImmediately && playCard.WasPlayedFromHand)
        {
            _instructionText.text = playCard.InstructionsOnPlay;
        }

        else
        {
            _instructionText.text = playCard.InstructionsOnGain;
        }
    }
}
