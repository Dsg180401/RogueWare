using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSequencePuzzle : MonoBehaviour
{
    // Correct order
    public List<int> correctSequence = new List<int>();

    // What player has pressed
    private List<int> currentSequence = new List<int>();

    // Fires when puzzle solved
    public UnityEvent onPuzzleSolved;

    // Optional: reset buttons on failure
    public Interactables.Button[] buttons;

    public void PressButton(int id)
    {
        currentSequence.Add(id);

        int currentIndex = currentSequence.Count - 1;

        // Wrong button pressed
        if (currentSequence[currentIndex] != correctSequence[currentIndex])
        {
            Debug.Log("Wrong sequence!");

            ResetPuzzle();
            return;
        }

        // Sequence complete
        if (currentSequence.Count == correctSequence.Count)
        {
            Debug.Log("Puzzle solved!");

            onPuzzleSolved.Invoke();
        }
    }

    void ResetPuzzle()
    {
        currentSequence.Clear();

        // Reset all buttons visually
        foreach (var button in buttons)
        {
            button.Reset();
        }
    }
}