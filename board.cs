using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class Board
    {
        private TileStates[,] boardData = new TileStates[3, 3];
        public enum TileStates { On = 0, Off = 1 };

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boardData[i, j] = TileStates.Off;
                }
            }
        }

        public void clear()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boardData[i, j] = TileStates.Off;
                }
            }
        }

        public void setTile(int x, int y)
        {
            clear();
            boardData[x, y] = TileStates.On;
        }

        public void setTile(string name, List<int> orden)
        {
            int i = 0, j = 0;

            switch (name)
            {
                case "c0_0":
                    this.setTile(0, 0);
                    orden.Add(0);
                    break;
                case "c0_1":
                    this.setTile(0, 1);
                    orden.Add(1);
                    break;
                case "c0_2":
                    this.setTile(0, 2);
                    orden.Add(2);
                    break;
                case "c1_0":
                    this.setTile(1, 0);
                    orden.Add(3);
                    break;
                case "c1_1":
                    this.setTile(1, 1);
                    orden.Add(4);
                    break;
                case "c1_2":
                    this.setTile(1, 2);
                    orden.Add(5);
                    break;
                case "c2_0":
                    this.setTile(2, 0);
                    orden.Add(6);
                    break;
                case "c2_1":
                    this.setTile(2, 1);
                    orden.Add(7);
                    break;
                case "c2_2":
                    this.setTile(2, 2);
                    orden.Add(8);
                    break;

            }
        }

        public TileStates getTile(int x, int y)
        {
            return boardData[x, y];
        }

        public bool evaluateBoard(List<int> orden1, List<int> orden2)
        {
            for (int i=0;i<orden1.Count; i++)
            {

                if (orden1.ElementAt(i) != orden2.ElementAt(i))
                {
                    return false;
                }

            }
            return true;
        }
    }
}