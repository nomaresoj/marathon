using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TresEnRaya
{

    class AI
    {
        Board gameBoard;
        public List<int> array2=new List<int>();
        public AI(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public void nextMove(List<int> orden)
        {
            int i=0;
            do
            {
                Random randomGenerator = new Random();
                i = randomGenerator.Next(9);
            } while (i == orden.Last());
            orden.Add(i); 
         }
    }
}
