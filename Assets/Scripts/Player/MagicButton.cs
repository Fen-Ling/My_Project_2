using UnityEngine;
using UnityEngine.UI;

public class MagicSelector : MonoBehaviour
{
    public Button[] magicButtons;
    public Attack_Mage attackMage;
    private int selectedMagicIndex = -1;

    private void Awake()
    {
        attackMage = FindObjectOfType<Attack_Mage>();
    }
    private void Start()
    {
        for (int i = 0; i < magicButtons.Length; i++)
        {
            int index = i;
            magicButtons[i].onClick.AddListener(() => SelectMagic(index));
        }
    }

    public void SelectMagic(int index)
    {
        if (selectedMagicIndex == index) return;


        if (selectedMagicIndex >= 0 && selectedMagicIndex < magicButtons.Length)
        {
            magicButtons[selectedMagicIndex].GetComponentInChildren<Image>().color = Color.white; // Сбрасываем цвет
        }

        // Устанавливаем новую кнопку как нажатую
        selectedMagicIndex = index;
        magicButtons[selectedMagicIndex].GetComponentInChildren<Image>().color = Color.green; // Меняем цвет нажатой кнопки

        // Здесь вы можете вызвать метод для установки префаба
        attackMage.SetMagicIndex(selectedMagicIndex);
    }
}