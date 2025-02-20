// using UnityEngine;

// public class ColliderController : MonoBehaviour
// {
//     public float radius = 200f; // Радиус сферы
//     private Collider[] colliders;

//     void FixedUpdate()
//     {
//          // Получаем все коллайдеры в радиусе
//         colliders = Physics.OverlapSphere(transform.position, radius);

//         // Получаем все объекты в сцене
//         GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

//         foreach (GameObject obj in allObjects)
//         {
//             // Проверяем, есть ли у объекта коллайдер
//             Collider objCollider = obj.GetComponent<Collider>();
//             if (objCollider != null)
//             {
//                 bool isInSphere = false;
//                 foreach (Collider collider in colliders)
//                 {
//                     if (collider.gameObject == obj)
//                     {
//                         isInSphere = true;
//                         break;
//                     }
//                 }

//                 // Включаем или отключаем объект в зависимости от его положения
//                 obj.SetActive(isInSphere);
//             }
//         }
//     }
// }
