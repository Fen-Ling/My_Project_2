using UnityEngine;

   public class PlayerHealth : MonoBehaviour
   {
       public int health = 100;  // Здоровье игрока

       public void TakeDamage(int damage)
       {
           health -= damage;
           if (health <= 0)
               Die();
       }

       void Die()
       {
           Destroy(gameObject);  // Удаляем игрока или запускаем анимацию смерти
   }
   }