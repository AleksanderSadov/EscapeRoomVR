using TMPro;
using UnityEngine;

namespace EscapeRoom.Gameplay
{
    public class FinalCodeManager : MonoBehaviour
    {
        public int finalCodeLength = 4;
        public string generatedFinalCode = ""; 

        private TextMeshProUGUI codeText;
        private NumberPad finalCodeNumberPad;

        private void Start()
        {
            FindDependencies();
            GenerateRandomCode();
            SetRandomCode();
        }

        private void FindDependencies()
        {
            finalCodeNumberPad = FindObjectOfType<NumberPad>();
            codeText = GameObject.FindWithTag("FinalCode").GetComponent<TextMeshProUGUI>();
        }

        private void GenerateRandomCode()
        {
            for (int i = 0; i < finalCodeLength; i++)
            {
                int randomNumber = Random.Range(0, 10);
                generatedFinalCode += randomNumber.ToString();
            }
        }

        private void SetRandomCode()
        {
            finalCodeNumberPad.sequence = generatedFinalCode;
            codeText.text = generatedFinalCode;
        }
    }
}

