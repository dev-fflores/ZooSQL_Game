using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cartoon
{
    public enum CartoonPageState
    {
        Waiting,
        Writing,
        Finished
    }
    public class CartoonPage : MonoBehaviour
    {
        [TextArea(3, 10)]
        public List<string> _dialogues;
        [SerializeField] private TextMeshProUGUI _dialogueText;
        // [SerializeField] private float _dialogueSpeed = 0.1f;
        public string currentDialogueText;
        public bool IsDialogueFinished { get; private set; }
        // public CartoonPageState CurrentCartoonPageState { get; private set; }
        public int CurrentDialogueIndex { get; set; }

        private void Awake()
        {
            _dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            IsDialogueFinished = false;
            CurrentDialogueIndex = 0;
            _dialogueText.text = string.Empty;
            currentDialogueText = _dialogues[CurrentDialogueIndex];
            
            WritePartialDialogue();
            // CurrentCartoonPageState = CartoonPageState.Start;
            // StartWriteDialogueWithAnimation(_dialogues[CurrentDialogueIndex]);
        }

        public void WritePartialDialogue()
        {
            if (IsDialogueFinished)
            {
                return;
            }
            
            if (CurrentDialogueIndex > 0)
            {
                _dialogueText.text += "\n";
            }
            
            _dialogueText.text += _dialogues[CurrentDialogueIndex];
            CurrentDialogueIndex++;

            if (CurrentDialogueIndex >= _dialogues.Count)
            {
                IsDialogueFinished = true;
            }
        }

        // public void StartWriteDialogueWithAnimation(string dialogue)
        // {
        //     StartCoroutine(WritePartialDialogueAnimation(dialogue));
        // }
        
        // public void StopAllCoroutinesInThisCartoonPage()
        // {
        //     StopAllCoroutines();
        // }
        
        // public void FinishWritingPartialDialogue()
        // {
        //     StopAllCoroutinesInThisCartoonPage();
        //     _dialogueText.text = currentDialogueText;
        //     CurrentCartoonPageState = CartoonPageState.Finished;
        //     CurrentDialogueIndex++;
        // }
        //
        // private IEnumerator WritePartialDialogueAnimation(string dialogue)
        // {
        //     if (CurrentDialogueIndex > 0)
        //     {
        //         _dialogueText.text += "\n";
        //         currentDialogueText += "\n";
        //         currentDialogueText += dialogue;
        //     }
        //     CurrentCartoonPageState = CartoonPageState.Writing;
        //     foreach (var letter in dialogue)
        //     {
        //         _dialogueText.text += letter;
        //         yield return new WaitForSeconds(_dialogueSpeed);
        //     }
        //     CurrentCartoonPageState = CartoonPageState.Finished;
        // }

        // public void OnPointerClick(PointerEventData eventData)
        // {
        //     if (CartoonPageState == CartoonPageState.Writing)
        //     {
        //         StopAllCoroutines();
        //         _dialogueText.text = _currentDialogueText;
        //         CartoonPageState = CartoonPageState.Finished;
        //         CurrentDialogueIndex++;
        //     }
        //     else if (CartoonPageState == CartoonPageState.Finished)
        //     {
        //         if (CurrentDialogueIndex < _dialogues.Count)
        //         {
        //             StartWriteDialogueWithAnimation(CurrentDialogueIndex);
        //         }
        //         else
        //         {
        //             Debug.Log("Dialogue Finished");
        //         }
        //     }
        // }
    }
}