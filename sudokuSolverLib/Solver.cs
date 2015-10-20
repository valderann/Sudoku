using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace sudokuLib
{
    [Serializable()]
    public class sudokuBox
    {
            public Int32? intNumber;
            public bool isFilledIn=false;
            public bool isStartup=false;
            public bool isFilledInValid = false;
            public List<int> intPossibilities=new List<int>();
    }

    public class Sudoku
    {
        private sudokuBox[,] boxes=new sudokuBox[9,9];
        private DateTime dtStartTIme = DateTime.Now;
        private int intFoutenAantal = 0;
        public event EventHandler Solved;

        public Sudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for(int e=0; e<9;e++)
                {
                    boxes[i, e] = new sudokuBox();
                }
            }
        }

        


        public void removeFilledInBoxValue(int x, int y)
        {
            if (x < 9 && y < 9 && boxes[x, y].isStartup == false)
            {
                    boxes[x, y].isFilledIn = false;
                    boxes[x, y].intPossibilities.Clear();
            }
        }

        public void reset()
        {
            
            for(int x=0;x<9;x++)
            {
                for(int y=0;y<9;y++)
                {
                    removeFilledInBoxValue(x, y);
                }
            }
            dtStartTIme = DateTime.Now;
            intFoutenAantal = 0;
        }

        public void setFilledInBoxValue(int x, int y, int value)
        {
            if (x < 9 && y < 9 && value > 0 && value<10)
            {
                if (boxes[x, y].isStartup == false)
                {
                    boxes[x, y].isFilledIn = false;
                    boxes[x, y].isFilledInValid = checkField(x, y,value);
                    if (boxes[x, y].isFilledInValid == false){intFoutenAantal += 1;}

                    boxes[x, y].intNumber = value;
                    boxes[x, y].isFilledIn = true;
                    
                    if(isSolved())
                    {
                        Solved(this, null);
                    }
                }
            }
        }
        public void clearField(int x, int y)
        {
            if (x < 9 && y < 9)
            {
                boxes[x, y].isFilledIn = false;
            }
        }

        public sudokuBox getBox(int x,int y)
        {
            return boxes[x, y];
        }

        public void setStartupBoxValue(int x, int y, int value)
        {
            if (x < 9 && y < 9 && value > 0 && value < 10)
            {
                boxes[x, y].intNumber = value;
                boxes[x, y].isStartup = true;
                boxes[x, y].isFilledIn = true;
            }
        }

        public bool SolveStep()
        {
            bool isFieldSolved = true;
            for (int i = 0; i < 9; i++)
            {
                for (int e = 0; e < 9; e++)
                {
                    if (!boxes[i, e].isFilledIn)
                    {
                        boxes[i, e].intPossibilities.Clear();
                        Solve(i, e);
                    }
                }
            }

            isFieldSolved = false;
            for (int i = 0; i < 9; i++)
            {
                for (int e = 0; e < 9; e++)
                {
                    if (!boxes[i, e].isFilledIn)
                    {
                        if (boxes[i, e].intPossibilities.Count == 1)
                        {
                            isFieldSolved = true;
                            setFilledInBoxValue(i, e, boxes[i, e].intPossibilities[0]);
                        }
                    }
                }
            }
            return  isFieldSolved ;
        }

        public void Solve()
        {
            bool isFieldSolved = true;
            while (isFieldSolved == true)
            {
                isFieldSolved = SolveStep();
            }
        }

        public void Solve(int x, int y)
        {
            for (int i = 1; i < 10;i++ )
            {
                if (isXCheck(x, y, i) && isYCheck(x, y, i) && isBoxCheck(x, y, i))
                {
                    boxes[x, y].intPossibilities.Add(i);
                }
            }
        }
        public bool checkField(int x, int y,int intValue)
        {
            if (isXCheck(x, y, intValue) && isYCheck(x, y, intValue) && isBoxCheck(x, y, intValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void saveToFile(string strFilename)
        {
            Stream stream = File.Open(strFilename, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(stream, boxes);
            stream.Close();
        }

        public bool loadFromFile(string strFilename)
        {
            if(File.Exists(strFilename))
            {
                boxes = null;
                Stream stream= File.Open(strFilename, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();

                boxes = (sudokuBox[,])bformatter.Deserialize(stream);
                stream.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isXCheck(int hx, int hy, int intValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (boxes[hx, i].isFilledIn == true)
                {
                    if (boxes[hx, i].intNumber == intValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isYCheck(int hx, int hy, int intValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (boxes[i,hy].isFilledIn == true)
                {
                    if (boxes[i, hy].intNumber == intValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isSolved()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if(boxes[x,y].isStartup==false && (boxes[x,y].isFilledInValid==false || boxes[x,y].isFilledIn==false))
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        private bool isBoxCheck(int hx,int hy,int intValue)
        {
            int intBeginBox=hx/3;
            int intEindeBox=hy/3;

            for (int e = (intBeginBox*3); e < (intBeginBox*3)+3; e++)
            {
                for (int i = (intEindeBox*3); i < (intEindeBox*3)+3; i++)
                {
                    if (boxes[e, i].isFilledIn == true )
                    {
                        if (boxes[e, i].intNumber == intValue)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hx"></param>
        /// <param name="hy"></param>
        private void CrossHatchBox(Int32 hx,Int32 hy)
        {
            if (hx < 3 && hy < 3)
            {

                ArrayList intNotPossibilities=new ArrayList();
                Int32 intMinX=hx*3;
                Int32 intMaxX=(hx+1)*3;
                Int32 intMinY = hy * 3;
                Int32 intMaxY =(hy + 1) * 3;

                for (int e = intMinY; e < intMaxY; e++)
                {
                    for (int i = intMinX; i < intMaxX; i++)
                    {
                        if(boxes[i,e].intNumber!=null)
                        {
                            intNotPossibilities.Add(boxes[i, e].intNumber);
                        }
                 
                    }
                }
            }
        }

    }
}
