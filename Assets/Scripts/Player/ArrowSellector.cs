using UnityEngine;
using UnityEngine.UI;

public class ArrowSelector : MonoBehaviour
{
    public Button[] ArrowButtons;
    public GameObject Buttons;
    public Attack_Archer attackArrow;
    private int selectedArrowIndex = -1;

    private void Awake()
    {
        attackArrow = gameObject.GetComponentInParent<Attack_Archer>();
    }

    private void Start()
    {
        Buttons.SetActive(true);
        for (int i = 0; i < ArrowButtons.Length; i++)
        {
            int index = i;
            ArrowButtons[i].onClick.AddListener(() => SelectArrow(index));
        }
    }

    public void SelectArrow(int index)
    {
        if (selectedArrowIndex == index) return;


        if (selectedArrowIndex >= 0 && selectedArrowIndex < ArrowButtons.Length)
        {
            ArrowButtons[selectedArrowIndex].GetComponentInChildren<Image>().color = Color.white; // Сбрасываем цвет
        }

        // Устанавливаем новую кнопку как нажатую
        selectedArrowIndex = index;
        ArrowButtons[selectedArrowIndex].GetComponentInChildren<Image>().color = Color.red; // Меняем цвет нажатой кнопки

        attackArrow.ChooseFireType(selectedArrowIndex);

    }
}