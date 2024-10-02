using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimonSaysManager : MonoBehaviour
{
    [SerializeField] List<NoteBoxController> _noteBoxes;  // List of all note boxes
    [SerializeField] float _timeBetweenNotes;  // Time between note plays

    List<NoteBoxController> _notesToPlay = new List<NoteBoxController>();  // Generated sequence
    List<NoteBoxController> _notesPlayedByPlayer = new List<NoteBoxController>();  // Player's input sequence

    public UnityEvent GameWon;

    int _currentIndex = 0;  // Index to track player's current input
    bool _isPlayingSequence = false;  // Whether the sequence is playing
    int _finishedSequences = 0;  // Tracks how many sequences have been completed successfully

    void Start()
    {
        StartNewPuzzle();
    }

    // Generate a random sequence of notes
    public void GenerateRandomSequence(int length)
    {
        _notesToPlay.Clear();  // Clear previous sequence

        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, _noteBoxes.Count);  // Pick a random note
            _notesToPlay.Add(_noteBoxes[randomIndex]);  // Add to sequence
        }
    }

    // Coroutine to play the sequence of notes
    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(2f);  // Initial delay before playing

        _isPlayingSequence = true;
        _currentIndex = 0;

        foreach (var note in _notesToPlay)
        {
            note.PlayAudio();
            StartCoroutine(note.Glow());
            yield return new WaitForSeconds(_timeBetweenNotes);  // Wait between notes
        }

        _isPlayingSequence = false;  // Allow player to interact after sequence finishes
    }

    // Called when player selects a note box
    public void PlayerSelected(NoteBoxController selectedNoteBox)
    {
        if (_isPlayingSequence) return;  // Ignore input if the sequence is still playing

        _notesPlayedByPlayer.Add(selectedNoteBox);  // Add player input to their sequence

        // Check if player's input matches the current note in the sequence
        if (_notesPlayedByPlayer[_currentIndex] == _notesToPlay[_currentIndex])
        {
            _currentIndex++;  // Move to the next note in the sequence

            // Check if the player has completed the sequence
            if (_currentIndex >= _notesToPlay.Count)
            {
                Debug.Log("Sequence Completed Successfully!");
                _finishedSequences++;

                // Show feedback for success
                foreach (NoteBoxController noteBox in _noteBoxes)
                {
                    StartCoroutine(noteBox.HighlightGreen());
                }

                // Check if the puzzle is completed after 3 successful sequences
                if (_finishedSequences >= 3)
                {
                    Debug.Log("Puzzle Completed!");
                    // Trigger door open or any other event here
                    GameWon.Invoke();
                }
                else
                {
                    // Start a new round with a longer sequence
                    StartNewPuzzle();
                }
            }
        }
        else
        {
            Debug.Log("Incorrect Sequence, Try Again.");
            foreach (NoteBoxController noteBox in _noteBoxes)
            {
                StartCoroutine(noteBox.HighlightRed());  // Show feedback for failure
            }
            // Reset puzzle and try again
            ResetPuzzle();
        }
    }

    // Reset the puzzle after a failure
    public void ResetPuzzle()
    {
        _notesPlayedByPlayer.Clear();  // Clear player's inputs
        _currentIndex = 0;  // Reset index
        _finishedSequences = 0;  // Reset successful sequences
        StartCoroutine(PlaySequence());  // Replay the sequence

    }

    // Start a new puzzle or next round
    private void StartNewPuzzle()
    {
        _notesPlayedByPlayer.Clear();  // Clear player's inputs
        _currentIndex = 0;  // Reset index
        GenerateRandomSequence(_finishedSequences + 3);  // Generate new sequence with increasing length
        StartCoroutine(PlaySequence());  // Play the new sequence
    }
}
