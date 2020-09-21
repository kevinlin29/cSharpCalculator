using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Project: scientific(ish) Calculator
 * Start Date: Feb 6th 2020         End Date: Feb 12th 2020
 * Creator: Kevin Lin
 * Total time used: about 25H
 * Process
 * 
 * Research:
 * Since C# is similar to java, it wasn't that hard to understand. For this project
 * I went a bit overboard and used stacks for my calculation steps. I had to do some
 * research on how to use it. A stack is a special case collection which represents 
 * a last in first out (LIFO) concept. The concept of last in first out in the case 
 * of books means that only the top most book can be removed from the stack of books. 
 * It is not possible to remove a book from between, because then that would disturb 
 * the setting of the stack (guru99). In c#, Elements are added to the stack, one on 
 * the top of each other. The process of adding an element to the stack is called a 
 * push operation. To remove an element from a stack, you can also remove the top 
 * most element of the stack. This operation is known as pop. This was useful for me
 * since I wanted to create a scientific calculator, which invloves a long equation 
 * that is not calculated every step along the way. The stack was used to store 
 * operators, number, as well as the length of each number. 
 * 
 * tryParse is another thing i learned, which is basically trying to convert a string
 * into doubles or ints, and it returns a boolean value. This was useful for me since
 * the input is in terms of string, and i would have to parse out the integer and 
 * operators for it to become a useable equation.
 * 
 * BEDMAS was another feature I had to research on. It basically asigns priority to 
 * each of the operator, which will be considered during the calculation step. Stack 
 * important for this case as it allowed the comparison between operators in a effeicient
 * manner. this is one of the challenge i faced during this project
 * 
 * Algorithem:
 * I asigned a char to each operator, which will make it easier in the calculation 
 * process. I wrote a big function for the entirity of calculation. It first checks 
 * if its 0 or error, in this case, the program will stop. most of the code in this
 * function is for special operations (that is not +-x/%). The regular calculation 
 * is done in a seperate function called compute
 * 
 * Most of this program is repetitive in terms of code due to the buttons used for
 * the calculator, and almost 80% of the code is the same to be honest.
 * 
 * 
 * Special Features:
 * All trig functions, done in degrees
 * Factorial Calculation
 * Inverse Calculation
 * Squaring a number and Square-rooting a number
 * BEDMAS
 * MOD calculation
 */

namespace KevinLinAdvancedCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            outPut.Text = "0";
        }

        /*
            Use a string to store all the inputs from the user, and later convert and 
            check if it is usuable for mathematical calculation.
        */
        string figure = "";
        string Ans = "0";
        bool a = true;
        /*
            
        */
        Stack<int> len1 = new Stack<int>(); //for tracking the numbers
        Stack<int> len2 = new Stack<int>(); //for identifying how many numbers in each operation
        Stack<double> nums = new Stack<double>(); // for storing numbers
        Stack<char> Operator = new Stack<char>(); // for storing operator

        // the following if for the number buttons, each corresponds to the button, 
        //and add the character to screen

        private void button1_Click(object sender, EventArgs e)
        {
            //check if the display is clear, if it is not clear it, repeat for each button
            if(a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }

            //the comments below applies to all the button inputs before the calculation function.
            len1.Push(figure.Length); //stores the length of characted currently inputed.
            len2.Push(outPut.Text.Length); //gets the amount of character in the current textbox, which is the input field
            outPut.Text += "1"; //put number on screen
            figure += "1"; //add this to figure
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "2";
            figure += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "3";
            figure += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "4";
            figure += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "5";
            figure += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "6";
            figure += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "7";
            figure += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "8";
            figure += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "9";
            figure += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "0";
            figure += "0";
        }


        // Following is for functions

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (figure != "")
            {
                outPut.Text += "+";
                figure += "+";
            }
            else
            {
                outPut.Text += "+";         //if + is pressed without anything before, change to 0 +
                figure += "0+";
            }
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "-";
            int len = figure.Length;
            if (len != 0 && (figure[len - 1] == ')' || (figure[len - 1] >= '0' && figure[len - 1] <= '9')))
                figure += "+-";           //since two operator in a row is not allowed in c#, convert all such to one operator, '-', so 4 +(-5)) would be converted to 4-5
            else figure += "-";
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "×";
            figure += "×";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "÷";
            figure += "÷";
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += ".";
            figure += ".";
        }

        private void buttonBracketL_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "(";
            figure += "(";
        }

        private void buttonBracketR_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += ")";
            figure += ")";
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len == 0 || outPut.Text[len - 1] < '0' || outPut.Text[len - 1] > '9')
            {
                outPut.Text += Ans;
                figure += Ans;
            }
            else
            {
                outPut.Text += "×";
                outPut.Text += Ans;
                figure += "×";
                figure += Ans;
            }
        }

        private void button17_Click(object sender, EventArgs e) //mod button
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "%";
            figure += "%";
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))
            {
                outPut.Text += "×";//add multuplication sign if there it is a number before it
                figure += "×";
            }
            outPut.Text += "√";
            figure += "S";
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            if(a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))  //add multuplication sign if there is no operator before it if its a number, applies for sin, cos, tan, arcsin, arccos, arctan
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "sin";
            figure += "s";
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            int len = outPut.Text.Length;
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "cos";
            figure += "c";
        }

        private void buttonFact_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "!";
            figure += "!";
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            outPut.Text += "^2";
            figure += "^";
        }

        // check if the string is usable for calculation

        private bool check(string str)  
        {
            int jd = 0, num = 0;
            int len = str.Length;
            int st = 0, ed = len - 1;
            while (str[st] == '(' && st < ed) st++;
            while (str[ed] == ')' && ed > 0) ed--;
            if ((str[st] < '0' || str[st] > '9') && str[st] != '-' && str[st] != 'S' && str[st] != 's' && str[st] != 'c' && str[st] != 't' && str[st] != 'o' && str[st] != 'p' && str[st] != 'q') return false; //outside of range and given operators
            if ((str[ed] < '0' || str[ed] > '9') && str[ed] != '!' && str[ed] != '^') return false; //for exponents and factorial
            for (int i = 0; i < len; i++)
            {
                if (str[i] == '+' || str[i] == '×' || str[i] == '÷' || str[i] == '%') jd++;
                if ((str[i] >= '0' && str[i] <= '9') || str[i] == '.') jd = 0; // this is if the input is true, then reset jd value, and return
                if (jd >= 2) return false;
            }
            jd = 0;
            for (int i = 0; i < len; i++)
            {
                if (str[i] == '(') jd++;
                else if (str[i] >= '0' && str[i] <= '9' && jd > 0) num++;
                else if (str[i] == ')')
                {
                    if (jd == 0 || num == 0) return false;
                    jd--;
                }
            }
            if (jd > 0) return false;
            return true;
        }
        //return the priority of calculation in stack

        private int isp(char op)
        {

            if (op == '#') return 0;
            if (op == '(') return 1;
            if (op == '×' || op == '÷' || op == '%' || op == 'S' || op == 'c' || op == 's' || op == 't' || op == 'o' || op == 'p' || op == 'q') return 5;
            if (op == '+' || op == '-') return 3;
            if (op == ')') return 7;
            return -1;
        }

        //return the priority of calculation outside of stack or the one currently checking again the one within the stack
        private int icp(char op)
        {
            if (op == '#') return 0;
            if (op == '(') return 7;
            if (op == '×' || op == '÷' || op == '%') return 4;
            if (op == 'S' || op == 'c' || op == 's' || op == 't' || op == 't' || op == 'o' || op == 'p' || op == 'q') return 6;
            if (op == '+' || op == '-') return 2;
            if (op == ')') return 1;
            return -1;
        }

        private double compute(double l, char op, double r)  //computation of each signs, this will be later on used in a big calculation function
        {
            if (op == '+') return l + r;    //adding process
            if (op == '-') return l - r;    //subtracting process
            if (op == '×') return l * r;    //multiplication process
            if (op == '÷') return l / r;    //division process
            if (op == '%') return Convert.ToInt64(l) % Convert.ToInt64(r);  //this is MOD
            return 0;
        }

        bool isInteger(double x) //check if it is an integer
        {
            string str = x.ToString();
            long res = -1;
            if (long.TryParse(str, out res)) return true; //return true if it is an integer
            return false;
        }

        private bool trans(ref string str)   //check if there is a operator '-' , reference string
        {
            int num = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-') num++;
                else break;
            }
            str = str.Substring(num);
            if (num % 2 == 0) return false;
            return true;
        }

        private string F(string str)
        {
            if (str == "") str = "0";
            if (str == "Error") return str;
            //return error if the string is not calculatable
            if (!check(str)) return "Error";

            str += '#';
            nums.Clear();
            Operator.Clear();
            Operator.Push('#');
            for (int i = 0; i < str.Length; i++)
            {
                bool number = false;
                string tmp = "";
                while ((str[i] >= '0' && str[i] <= '9') || str[i] == '.' || str[i] == '-' ) // if its within tange of 0-9 and its a decimal or subtraction
                {
                    number = true;
                    tmp += str[i];
                   
                    i++;
                }
                bool flag;
                if (number)
                {
                    flag = trans(ref tmp);   //if there is a -, store as a negative number
                    double res;
                    bool success = double.TryParse(tmp, out res); // check if it could be converted to a doucle
                    if (flag) res = -res;
                    if (success) nums.Push(res);
                    else return "Error";
                }
                flag = true; // set as true to run futhur loops
                while (flag)
                {
                    if (str[i] == '!'||str[i] == '^') //calculation for facotrial and powers
                    {
                        if (nums.Count == 0) return "Error";
                        double l = nums.Pop();
                        double res;
                        //factorial calculation
                        if (str[i] == '!')
                        {
                            
                            if (!isInteger(l) || l < 1) return "Error";
                            res = 1;
                            for (int j = 1; j <= l; j++) res *= j;
                        }
                        else //squaring the number
                        {
                            res = Math.Pow(l,2);
                        }
                        nums.Push(res);
                        break;
                    }
                    else if (icp(str[i]) > isp((char)Operator.Peek()))   //bedmas calculation for orders .peek means checking the last element in the stack without doing anything to it
                    {
                        Operator.Push(str[i]);
                        break;
                    }
                    else if(icp(str[i]) < isp((char)Operator.Peek()))   //if the calculation is already in the correct order
                    {                                               
                        double r = nums.Pop(); // find the last number put into the equation
                        char op = Operator.Pop(); //find the last operator put into the equation
                        if (op == 'S') //square root calculation
                        {
                            if (r < 0)
                            {
                                MessageBox.Show("Cannot calculate square root of negative number", "Error", MessageBoxButtons.OK);
                                return "Error";
                            }
                            nums.Push(Math.Sqrt(r));
                        }
                        else if (op == 's' || op == 'c'||op=='t'||op=='o' || op == 'p' || op == 'q') //trig calculation
                        {
                            if (op == 's') nums.Push(Math.Sin(Math.PI * (r) / 180.0));
                            else if (op == 'c') nums.Push(Math.Cos(Math.PI * (r) / 180.0));
                            else if (op == 't')
                            {
                                if (r == 90)
                                {
                                    MessageBox.Show("Cannot calculate tan90°", "Error", MessageBoxButtons.OK);
                                    return "Error";
                                }
                                nums.Push(Math.Tan(Math.PI * (r) / 180.0));
                            }
                            else if(op=='o')
                            {
                                nums.Push(Math.Asin(r)/(2*Math.PI)*360);
                            }
                            else if(op=='p')
                            {
                                nums.Push(Math.Acos(r) / (2 * Math.PI) * 360);
                            }
                            else if(op=='q')
                            {
                                nums.Push(Math.Atan(r) / (2 * Math.PI) * 360);
                            }
                        }
                        else
                        {//check for characters, and finally finished the calculation
                            double l = nums.Pop();
                            if (op == '÷' && r == 0) {
                                MessageBox.Show("Cannot divide by 0","Error", MessageBoxButtons.OK);
                             return "Error"; }
                            if (op == '%' && (!isInteger(l) || !isInteger(r) || r == 0)) return "Error"; 
                            nums.Push(compute(l, op, r)); //push result of compute to num stack
                        }
                    }
                    else
                    {
                        Operator.Pop(); // remover the last operator which has already been used
                        break;
                    }
                }
            }
            if (nums.Count > 1)
            {
               
                return "Error";
            }
            Ans = nums.Pop().ToString();
            return Ans;
        } //main calculating function

        private void buttonEqal_Click(object sender, EventArgs e) 
        {
            outPut.Clear();
            string ans = F(figure);
            //clear and reset stacks 
            len1.Clear();
            len2.Clear();
            len1.Push(0);
            len2.Push(0);
            outPut.Text += ans;
            figure = ans;
            double result;
            bool flag = double.TryParse(ans, out result);  //flag if result is a number or error
            if (!flag || ans == "0") //there is something in the text box
                a = true;
        }

        private void buttonClear_Click(object sender, EventArgs e) //clear input box
        {
            outPut.Text = "0";
            figure = "";
            len2.Clear();
            len1.Clear();
            a = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            //function for removing a the last inputed item
            string str = outPut.Text;
            if (str == "Error")
            {
                outPut.Text = "0";
                a = true;
                return;
            }
            try
            {
                outPut.Text = outPut.Text.Substring(0, len2.Pop());
                if (figure.Length != 0)
                {
                    figure = figure.Substring(0, len1.Pop());
                }
                if (outPut.Text.Length == 0)
                {
                    outPut.Text = "0";
                    len2.Push(0);
                    a = true;
                }
            }
            catch (Exception)
            {
                /*MessageBox.Show("can't back!", "Error", MessageBoxButtons.OK);*/
                outPut.Text = "0";
            }
        }

        private void buttonFract_Click(object sender, EventArgs e)
        {
            //for calculating 1/ the number in the textbox
            string ans = F(figure);
            outPut.Clear();
            double res; //result
            figure = ans;
            len1.Clear();
            len2.Clear();
            len1.Push(0);
            len2.Push(0);
            bool flag = double.TryParse(figure, out res);
            if (flag)
            {
                if (res == 0)
                {
                    MessageBox.Show("Cannot calculate 1/0", "Error", MessageBoxButtons.OK);
                    outPut.Text += "Error";
                    figure = "Error";
                    a = true;
                }
                else
                {
                    res = 1.0 / res;
                    outPut.Text += res;
                    figure = res.ToString();
                    Ans = ans;
                }
            }
            else
            {
                if (ans == "Error")
                {
                    ans = "0";
                    Ans = ans;
                }
                outPut.Text += ans;
                figure = "0";
                a = true;
            }
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "tan";
            figure += "t";
        }

        private void buttonArcsin_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))  
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "arcsin";
            figure += "o";
        }

        private void buttonArccos_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))  
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "arccos";
            figure += "p";
        }

        private void buttonArctan_Click(object sender, EventArgs e)
        {
            if (a)
            {
                figure = "";
                outPut.Clear();
                a = false;
            }
            int len = outPut.Text.Length;
            len1.Push(figure.Length);
            len2.Push(outPut.Text.Length);
            if (len > 0 && ((outPut.Text[len - 1] >= '0' && outPut.Text[len - 1] <= '9') || outPut.Text[len - 1] == ')'))  
            {
                outPut.Text += "×";
                figure += "×";
            }
            outPut.Text += "arctan";
            figure += "q";
        }

        private void outPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); //exit entire program
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}

