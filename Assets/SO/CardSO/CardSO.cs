using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "SO/CardSO")]
public class CardSO : ScriptableObject
{
    [field : SerializeField] public string CardName { get; private set; }
    [field: SerializeField] public int CardCost { get; private set; }
    [field: SerializeField] public Color CardColor { get; private set; }
    [field: SerializeField] public GameObject CardMethodObject { get; private set; }
    [TextArea]
    [SerializeField] private string cardDesc;

    public string CardDesc
    {
        get
        {
            return cardDesc;
        }

        private set
        {
            cardDesc = value;
        }
    }

}
