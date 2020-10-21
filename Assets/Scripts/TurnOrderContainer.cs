using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrderContainer : MonoBehaviour
{
    [SerializeField] List<GameObject> TurnButtonPrefabs = default;
    [SerializeField] GameObject NextTurnPrefab = default;
    [SerializeField] Color CurrentTurnColor = Color.red;

    private int currentTurnIndex = 0;
    private ColorBlock _currentTurnColors;
    private ColorBlock _notTurnColors;

    // Start is called before the first frame update
    void Start()
    {
        if (TurnButtonPrefabs.Count > 0)
        {
            var button = TurnButtonPrefabs[0].GetComponent<Button>();

            if (button != null)
            {
                initializeColorBlocks(button.colors);
                button.colors = _currentTurnColors;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initializeColorBlocks(ColorBlock template)
    {
        _notTurnColors = template;

        _currentTurnColors = template;
        _currentTurnColors.normalColor = CurrentTurnColor;
        _currentTurnColors.highlightedColor = CurrentTurnColor;
        _currentTurnColors.selectedColor = CurrentTurnColor;
    }

    public void AdvanceTurn()
    {
        handleTurnChange((currentTurnIndex + 1) % TurnButtonPrefabs.Count);
    }

    private void handleTurnChange(int nextPlayerIndex)
    {
        var endingTurnButton = TurnButtonPrefabs[currentTurnIndex];

        setButtonColor(endingTurnButton, _notTurnColors);

        currentTurnIndex = nextPlayerIndex;

        var newTurnButton = TurnButtonPrefabs[currentTurnIndex];

        setButtonColor(newTurnButton, _currentTurnColors);
    }

    public void GoToTurn(int player)
    {
        handleTurnChange(player - 1);
    }

    private void setButtonColor(GameObject buttonGameObject, ColorBlock colors)
    {
        var button = buttonGameObject.GetComponent<Button>();

        button.colors = colors;
    }
}
