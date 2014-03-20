using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainGame
{
    static class InventoryHolder
    {
        public static List<DropItems> inventory = new List<DropItems>();
        public static List<DropItems> tmpInventory = new List<DropItems>();

        public static bool allPickedUp()
        {
            for (int i = 0; i < tmpInventory.Count; i++)
            {
                if (tmpInventory[i].pickedUp == false)
                    return false;
            }

            return true;
        }
    }
}
