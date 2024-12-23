// using UnityEngine;

// public class PickUp_Weapon : MonoBehaviour
// {
//     public GameObject Player;
//     public float radius = 5f;
//     private GameObject currentWeapon;
//     private bool canPickUp;
//     private Attack_Warrior attackWarrior; // Ссылка на Attack_Warrior

//     void Start()
//     {
//         attackWarrior = Player.GetComponent<Attack_Warrior>(); // Получаем доступ к Attack_Warrior на объекте игрока
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.E)) PickUp();
//         if (Input.GetKeyDown(KeyCode.Q)) Drop();
//     }

//     void PickUp()
//     {
//         if (currentWeapon != null)
//         {
//             Collider collider = currentWeapon.GetComponent<Collider>();
//             if (collider != null)
//             {
//                 collider.enabled = true; // Активируем коллайдер
//             }
//             Drop(); // Если уже есть оружие, сбрасываем его
//         }

//         Collider[] hitColliders = Physics.OverlapSphere(Player.transform.position, radius);
//         foreach (var hitCollider in hitColliders)
//         {
//             if (hitCollider.CompareTag("Weapon"))
//             {
//                 currentWeapon = hitCollider.gameObject;
//                 currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
//                 currentWeapon.transform.parent = transform;
//                 currentWeapon.transform.localPosition = Vector3.zero;
//                 currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
//                 canPickUp = true;

//                 Debug.Log("Подобрано оружие: " + currentWeapon.name);
//                 break; // Выход из цикла после подбора
//             }
//         }
//     }

//     void Drop()
//     {
//         if (currentWeapon != null)
//         {
//             // Включаем коллайдер перед сбросом
//             Collider collider = currentWeapon.GetComponent<Collider>();
//             if (collider != null)
//             {
//                 collider.enabled = true; // Активируем коллайдер
//             }

//             // Получаем позицию для сброса оружия перед персонажем
//             Vector3 dropPosition = Player.transform.position + Player.transform.forward * 1.5f;

//             // Сбрасываем оружие
//             currentWeapon.transform.parent = null;
//             currentWeapon.transform.position = dropPosition; // Устанавливаем позицию перед персонажем
//             Rigidbody rb = currentWeapon.GetComponent<Rigidbody>();
//             if (rb != null)
//             {
//                 rb.isKinematic = false; // Убираем кинематику
//                 rb.linearVelocity = Vector3.zero; // Обнуляем скорость перед сбросом
//                 rb.angularVelocity = Vector3.zero; // Обнуляем угловую скорость перед сбросом
//             }

//             canPickUp = false;
//             Debug.Log("Оружие сброшено: " + currentWeapon.name);
//             currentWeapon = null;
//         }
//     }
// }