# nuclear-quest-helper

Play now! https://bretgourdie.github.io/nuclear-quest-helper/

Use as a companion for Nuclear Quest to keep track of hands, decks, and nuclear radiation.

Start by entering player names in the textboxes.

Click a deck to draw a card. This becomes the "Active Card". An Active Card must be put into a hand or returned to the deck before a new Active Card can take its place.

If the Active Card should be played immediately, click the Active Card to return it to the deck:
* If the card requires the player to draw a gamma radiation card, the gamma radiation card will be drawn automatically

Otherwise, click the cardback for a specific player to apply the card to a hand:
* If the card is a gamma radiation card, it will apply the gamma radiation to the slider
* If the card forces a lost turn, the "lost turn" checkbox will be checked
* If 30 or more gamma radiation is drawn, the "lost turn" checkbox will be checked

If there is no current Active Card, a player can click a card in a hand:
* If the card is a gamma radiation card, the card will be returned to the gamma radiation deck and the slider will be reduced automatically
* Otherwise, the instructions for the new Active Card will be displayed until the Active Card is returned to the deck by clicking on it

Use the "Roll" button to roll the two dice. Clicking on either dice will re-roll that specific die.

Use the "NextTurn" button to advance the turn to the next player. Play flows in a circular order: P1 -> P2 -> P3 -> P4 -> P1.
Click on a player button (P#) to set it to that person's turn.

Enjoy! This was thrown together in Unity as a 2D WebGL game using only the Canvas and UI objects.

This program is "ferda kids"; please keep this open-source for the pursuit of knowledge!
