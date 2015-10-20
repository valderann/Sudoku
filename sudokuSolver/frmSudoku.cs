using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace sudokuSolver
{
    
    public partial class frmSudoku : Form
    {
        private const int intBoxSize = 35;
        private sudokuLib.Sudoku sudokuPuzzle = new sudokuLib.Sudoku();
        private int intSelectedX = -1;
        private int intSelectedY = -1;

        public frmSudoku()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sudokuPuzzle.Solve();
            pnlSudoku.Invalidate();
        }

       
        private void pnlSudoku_Paint(object sender, PaintEventArgs e)
        {
            

            sudokuLib.sudokuBox tmpBox=new sudokuLib.sudokuBox();

            Pen pn = new Pen(Color.Black, 1);
            Pen pnDouble= new Pen(Color.Black,3);
            Pen pnTemp;

            SolidBrush drawBrush = new SolidBrush(Color.Black);
            SolidBrush filledInBrush = new SolidBrush(Color.DarkBlue);
            SolidBrush invalidBrush = new SolidBrush(Color.DarkRed);
            SolidBrush tmpBrush;

            Font drawFont = new Font("Arial", 10);
            Font suggestionFont = new Font("Arial", 6);

            for (int i = 0; i < 10; i++)
            {
                pnTemp= pn;
                if (i % 3 == 0) { pnTemp = pnDouble; }
                e.Graphics.DrawLine(pnTemp, new Point(0, intBoxSize * i), new Point((intBoxSize * 9), (intBoxSize * i)));
                e.Graphics.DrawLine(pnTemp, new Point(intBoxSize * i, 0), new Point(intBoxSize * i, (intBoxSize * 9)));

                if (i < 9)
                {
                    for (int eb = 0; eb < 9; eb++)
                    {
                        tmpBox = sudokuPuzzle.getBox(i, eb);
                        if (tmpBox.isFilledIn == true)
                        {
                            tmpBrush = drawBrush;
                            if (tmpBox.isStartup == false) {
                                tmpBrush = tmpBox.isFilledInValid ? filledInBrush : invalidBrush;
                            }

                            e.Graphics.DrawString(Convert.ToString(tmpBox.intNumber), drawFont, tmpBrush, i * intBoxSize, eb * intBoxSize);
                        }
                        else
                        {
                            int intPosXPlus = 0;
                            int intPosYPlus = 0;

                            foreach (int xItem in tmpBox.intPossibilities)
                            {

                                e.Graphics.DrawString(Convert.ToString(xItem), suggestionFont, drawBrush, (i * intBoxSize) + intPosXPlus, (eb * intBoxSize) + intPosYPlus);
                                intPosXPlus += 10;
                                if (intPosXPlus > intBoxSize - 10)
                                {
                                    intPosXPlus = 0;
                                    intPosYPlus += 10;
                                }
                            }

                        }

                        if (tmpBox.isStartup == false)
                        {                        
                            if (intSelectedX==i && intSelectedY==eb)
                            {
                                
                                SolidBrush brSelected = new SolidBrush(Color.FromArgb(40, Color.Blue));
                                if (!tmpBox.isFilledInValid && tmpBox.isFilledIn)
                                {
                                    brSelected = new SolidBrush(Color.FromArgb(40, Color.Red));
                                }
                                e.Graphics.FillRectangle(brSelected, intBoxSize * i, intBoxSize * eb, intBoxSize, intBoxSize);
                            }

                        }

                    }
                }
            }

        }

        private void sudokupuzzle_solved(object sender, EventArgs e)
        {
            TimeTaken.Stop();
            MessageBox.Show("You solved the sudoku in "+Convert.ToString(_intTimeTaken)+" seconds");
        }

        private void frmSudoku_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            TimeTaken.Start();
            sudokuPuzzle.Solved += sudokupuzzle_solved;
            sudokuPuzzle.setStartupBoxValue(1,0,6);
            sudokuPuzzle.setStartupBoxValue(0, 2, 1);
            sudokuPuzzle.setStartupBoxValue(2, 2, 7);

            sudokuPuzzle.setStartupBoxValue(3, 1, 6);
            sudokuPuzzle.setStartupBoxValue(4, 1, 5);
            sudokuPuzzle.setStartupBoxValue(5, 1, 1);

            sudokuPuzzle.setStartupBoxValue(6, 2, 6);
            sudokuPuzzle.setStartupBoxValue(7, 0, 1);
            sudokuPuzzle.setStartupBoxValue(8, 2, 2);

            sudokuPuzzle.setStartupBoxValue(0, 3, 6);
            sudokuPuzzle.setStartupBoxValue(1, 3, 2);
            sudokuPuzzle.setStartupBoxValue(2, 4, 3);
            sudokuPuzzle.setStartupBoxValue(0, 5, 4);
            sudokuPuzzle.setStartupBoxValue(1, 5, 8);

            sudokuPuzzle.setStartupBoxValue(3, 3, 3);
            sudokuPuzzle.setStartupBoxValue(5, 3, 5);
            sudokuPuzzle.setStartupBoxValue(5, 5, 7);
            sudokuPuzzle.setStartupBoxValue(3, 5, 9);

            sudokuPuzzle.setStartupBoxValue(7, 3, 9);
            sudokuPuzzle.setStartupBoxValue(8, 3, 4);
            sudokuPuzzle.setStartupBoxValue(6, 4, 2);
            sudokuPuzzle.setStartupBoxValue(7, 5, 3);
            sudokuPuzzle.setStartupBoxValue(8, 5, 6);

            sudokuPuzzle.setStartupBoxValue(0, 6, 9);
            sudokuPuzzle.setStartupBoxValue(1, 8, 5);
            sudokuPuzzle.setStartupBoxValue(2, 6, 6);

            sudokuPuzzle.setStartupBoxValue(3, 7, 7);
            sudokuPuzzle.setStartupBoxValue(4, 7, 9);
            sudokuPuzzle.setStartupBoxValue(5, 7, 4);

            sudokuPuzzle.setStartupBoxValue(6, 6, 4);
            sudokuPuzzle.setStartupBoxValue(7, 8, 7);
            sudokuPuzzle.setStartupBoxValue(8, 6, 8);

        }

        private void pnlSudoku_MouseClick(object sender, MouseEventArgs e)
        {
              int intX= e.X /intBoxSize;
              int intY=  e.Y / intBoxSize;
              //System.Diagnostics.Debug.WriteLine(Convert.ToString(intX) + "-" + Convert.ToString(intY));

              if (intX < 9 && intY < 9)
              {
                  if (intSelectedX != intX || intSelectedY != intY)
                  {
                    intSelectedX = intX;
                    intSelectedY = intY;
                    pnlSudoku.Invalidate();
                    pnlSudoku.Focus();
                  }
              }        
        }

        private void pnlSudoku_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int intKeyTest=-1;
            if((e.KeyCode > Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode > Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) 
            {
                if(e.KeyCode > Keys.D0 && e.KeyCode <= Keys.D9)
                {
                    intKeyTest = e.KeyCode-Keys.D0;
                }
                else if (e.KeyCode > Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {
                    intKeyTest = e.KeyCode - Keys.NumPad0;
                }
            }
            else if(e.KeyCode==Keys.Delete)
            {
                sudokuPuzzle.removeFilledInBoxValue(intSelectedX, intSelectedY);
                pnlSudoku.Invalidate();
            }


            if (intKeyTest!=-1)
            {

                if (intSelectedX != -1 && intSelectedY != -1)
                {
                    sudokuPuzzle.setFilledInBoxValue(intSelectedX, intSelectedY, intKeyTest);
                    pnlSudoku.Invalidate();
                }
            }
        }

        private string printInt(int val)
        {
            return Convert.ToString(val).PadLeft(2, '0');
        }

        private int _intTimeTaken = 0;
        private void TimeTaken_Tick(object sender, EventArgs e)
        {
            const int intHour=(60*60);
            const int intMinute = ( 60);
            int intHours=0,intMinutes=0,intSeconds=0;
            int intRest=_intTimeTaken;
            if(intRest / (intHour)>=1)
            {
                intHours = _intTimeTaken / (intHour);
                intRest = _intTimeTaken % (intHour);
            }
            if (intRest/intMinute>=1)
            {
                intMinutes = _intTimeTaken / (intMinute);
                intRest = _intTimeTaken % (intMinute);
            }
            intSeconds = intRest;
            lblTimeTaken.Text = printInt(intHours) + ":" + printInt(intMinutes) + ":" +printInt(intSeconds) ;
            _intTimeTaken += 1;
        }

        private void Reset()
        {
            TimeTaken.Stop();
            _intTimeTaken = 0;
            sudokuPuzzle.reset();
            pnlSudoku.Invalidate();
            TimeTaken.Start();
        }

        private void cmdRestart_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
