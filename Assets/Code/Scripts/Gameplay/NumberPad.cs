using TMPro;
using UnityEngine;

namespace EscapeRoom.Gameplay
{
    public class NumberPad : MonoBehaviour
    {
        public string sequence;
        public KeycardSpawner cardSpawner;
        public TextMeshProUGUI inputDisplayText;

        private string currentEnteredCode = "";

        private void Awake()
        {
            inputDisplayText.text = "";
        }

        public void ButtonPressed(int valuePressed)
        {
            currentEnteredCode += valuePressed.ToString();

            if (currentEnteredCode.Length == 1)
            {
                inputDisplayText.text = "*";
                inputDisplayText.color = Color.black;
            }
            else
            {
                inputDisplayText.text += "*";
            }

            if (currentEnteredCode.Length == sequence.Length)
            {
                if (currentEnteredCode == sequence)
                {
                    cardSpawner.SpawnKeyCard();

                    inputDisplayText.text = "Code Valid!";
                    inputDisplayText.color = Color.green;
                }
                else
                {
                    inputDisplayText.text = "Invalid Code!";
                    inputDisplayText.color = Color.red;

                }

                ResetSequence(false);
            }
        }

        public void ResetSequence(bool clearText)
        {
            currentEnteredCode = "";

            if (clearText)
            {
                inputDisplayText.text = "";
                inputDisplayText.color = Color.black;
            }
        }
    }
}