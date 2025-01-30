using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Stick stick;

        public void PointerDown()
        {
            stick.Down();
        }

        public void PointerUp()
        {
            stick.Up();
        }
    }
}