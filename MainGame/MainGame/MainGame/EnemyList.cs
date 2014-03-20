using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainGame
{
    
    class EnemyList
    {
        public Enemy[] enemies;
        public EnemyList()
        {
            enemies = new Enemy[0];
        }

        public void Add(Enemy e)
        {
            Enemy[] tmp = new Enemy[enemies.Length+1];
            for (int i = 0; i < enemies.Length; i++)
            {
                tmp[i] = enemies[i];
            }
            tmp[enemies.Length] = e;
            enemies = tmp;
        }

        public void removeAt(int index)
        {
            Enemy[] tmp = new Enemy[enemies.Length - 1];

            int i = 0;

            for (; i < index - 1; i++)
            {
                tmp[i] = enemies[i];
            }

            for (int j = index + 1; j < enemies.Length; j++)
            {
                i++;
                tmp[i] = enemies[j];
            }

            enemies = tmp;
        }

        public int orderEnemiesByPlacement(float playerPos)
        {
            int pos = this.getSize();   //Draw on top by default
            
            //Orders enemies
            for (int i = 0; i < this.getSize(); i++)
            {
                for (int j = i; j < this.getSize(); j++)
                {
                    if (enemies[i] != null && enemies[j] != null && (enemies[i].getPosition().Y-30) > enemies[j].getPosition().Y)   //+(x) is to prevent graphics bugging out with enemies constantly swapping positions
                    {
                        Enemy temp = enemies[i];
                        enemies[i] = enemies[j];
                        enemies[j] = temp;
                    }
                }
            }

            for (int i = 0; i < this.getSize(); i++)
            {
                if (enemies[i] != null && playerPos < enemies[i].getPosition().Y)
                    return i;
            }
            return pos;
        }

        public Enemy getAtIndex(int index)
        {

            if (index < enemies.Length && enemies[index] != null )
                return enemies[index];
            else
            {
                return null;
            }
        }

        public int getSize()
        {
            return enemies.Length;
        }

        public bool isAllDead()
        {
            for (int x = 0; x < enemies.Length; x++)
            {
                if (enemies[x] != null && enemies[x].dying == false && enemies[x].speed != 0)   //Speed check is to allow moving past the punching bag
                    return false;
            }
                return true;
        }

        public void removeNull()
        {            
            int numNulls = 0;

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null)
                {
                    numNulls++;
                }
            }

            Enemy[] tmp = new Enemy[enemies.Length - numNulls];

            int index = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    tmp[index] = enemies[i];
                    index++;
                }
            }

            enemies = tmp;
        }

        public void removeAll()
        {
            enemies = null;
            enemies = new Enemy[0];
        }


    }
}
