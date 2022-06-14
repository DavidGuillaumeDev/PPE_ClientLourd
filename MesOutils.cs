using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_Salons
{
    public static class MesOutils
    {
        private static int LastPosCar(string str1, char lecaractere)
        {
            int pos = -1;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == lecaractere)
                    pos = i;
            }
            return pos
                    ;

        }
        
        private static int CompterCar(string str1, char lecaractere) //Retourne le nombre de fois où un caractere
        {
            int cpt = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == lecaractere)
                    cpt++;
            }
            return cpt;
        }

        public static bool VeriferMail(string str1)
        {
            bool isOK = true;
            if (str1.Length == 0)//Longueur nulle
                isOK = false;
            if (CompterCar(str1, '@') != 1)//Pas un @ et un seul
                isOK = false;
            int posDernierPoint = LastPosCar(str1, '.'); //On en aura besoin plus loin, on peut donc
            int posDernierArobase = LastPosCar(str1, '@');
            if (posDernierPoint < posDernierArobase)
                isOK = false;//PAs de point apres @
            if (posDernierPoint > posDernierArobase)
            {
                if ((posDernierPoint - posDernierArobase) < 2)
                    isOK = false;//Pas au moins un caractere entre @ et dernier point
            }
            if ((str1.Length - posDernierPoint) <= 2) //pas au moins deux caracteres apres dernier
              isOK = false;
            if (posDernierArobase < 1) //Au moins un caractere avant @
                isOK = false;
            if (CompterCar(str1, ' ') != 0)//Presence de caractere espace
                isOK = false;
            return isOK;

        }



    }
}
