using UnityEngine;

   public class MagicEffect : MonoBehaviour
   {
       public float damage = 10f;

       private void OnTriggerEnter(Collider other)
       {
           // Наносим урон, если объект – враг
           if (other.CompareTag("Enemy"))
           {
               // Примените урон к врагу (здесь нужно сделать, чтобы у Enemy был соответствующий метод)
            //    other.GetComponent<Enemy>().TakeDamage(damage);
               Destroy(gameObject); // Уничтожаем магический эффект после контакта
           }
       }
   }