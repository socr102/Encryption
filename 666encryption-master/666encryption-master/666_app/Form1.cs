using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _666_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //matrix 1
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Random rnd = new Random();
            int matrix1r1 = rnd.Next(100000, 999999);
            int matrix1r2 = rnd.Next(100000, 999999);
            int matrix1r3 = rnd.Next(100000, 999999);
            int matrix1r4 = rnd.Next(100000, 999999);
            int matrix1r5 = rnd.Next(100000, 999999);
            int matrix1r6 = rnd.Next(100000, 999999);
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //matrix 2
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            int matrix2r1 = rnd.Next(100000, 999999);
            int matrix2r2 = rnd.Next(100000, 999999);
            int matrix2r3 = rnd.Next(100000, 999999);
            int matrix2r4 = rnd.Next(100000, 999999);
            int matrix2r5 = rnd.Next(100000, 999999);
            int matrix2r6 = rnd.Next(100000, 999999);
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //matrix 3
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            int matrix3r1 = rnd.Next(100000, 999999);
            int matrix3r2 = rnd.Next(100000, 999999);
            int matrix3r3 = rnd.Next(100000, 999999);
            int matrix3r4 = rnd.Next(100000, 999999);
            int matrix3r5 = rnd.Next(100000, 999999);
            int matrix3r6 = rnd.Next(100000, 999999);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            string matrix = Convert.ToString(matrix1r1) + Convert.ToString(matrix1r2) + Convert.ToString(matrix1r3) + Convert.ToString(matrix1r4) + Convert.ToString(matrix1r5) + Convert.ToString(matrix1r6);
            string matrix2 = Convert.ToString(matrix2r1) + Convert.ToString(matrix2r2) + Convert.ToString(matrix2r3) + Convert.ToString(matrix2r4) + Convert.ToString(matrix2r5) + Convert.ToString(matrix2r6);
            string matrix3 = Convert.ToString(matrix3r1) + Convert.ToString(matrix3r2) + Convert.ToString(matrix3r3) + Convert.ToString(matrix3r4) + Convert.ToString(matrix3r5) + Convert.ToString(matrix3r6);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            string xxx = matrix + matrix2 + matrix3;
            string str1 = xxx;
            ////////////////////////////////////////////////////////////////////////////////////////////////////



            int key1 = rnd.Next(10, 99);
            textBox3.Text = Convert.ToString(key1);
            int key2 = rnd.Next(10, 99);
            textBox4.Text = Convert.ToString(key2);
            int key3 = rnd.Next(10, 99);
            textBox5.Text = Convert.ToString(key3);
            int key4 = rnd.Next(10, 99);
            textBox6.Text = Convert.ToString(key4);
            int key5 = rnd.Next(10, 99);
            textBox7.Text = Convert.ToString(key5);
            int key6 = rnd.Next(10, 99);
            textBox8.Text = Convert.ToString(key6);

            int key7 = rnd.Next(10, 99);
            textBox9.Text = Convert.ToString(key7);
            int key8 = rnd.Next(10, 99);
            textBox10.Text = Convert.ToString(key8);
            int key9 = rnd.Next(10, 99);
            textBox11.Text = Convert.ToString(key9);
            int key10 = rnd.Next(10, 99);
            textBox12.Text = Convert.ToString(key10);
            int key11 = rnd.Next(10, 99);
            textBox13.Text = Convert.ToString(key11);
            int key12 = rnd.Next(10, 99);
            textBox14.Text = Convert.ToString(key12);

            int key13 = rnd.Next(10, 99);
            textBox15.Text = Convert.ToString(key13);
            int key14 = rnd.Next(10, 99);
            textBox16.Text = Convert.ToString(key14);
            int key15 = rnd.Next(10, 99);
            textBox17.Text = Convert.ToString(key15);
            int key16 = rnd.Next(10, 99);
            textBox18.Text = Convert.ToString(key16);
            int key17 = rnd.Next(10, 99);
            textBox19.Text = Convert.ToString(key17);
            int key18 = rnd.Next(10, 99);
            textBox20.Text = Convert.ToString(key18);




            string counter = "0";
            //counter++;

            //Encrypts a string.
            Encrypt(textBox1.Text, counter, str1, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16, key17, key18);


        }


        private void Encrypt(string contents, string counter, string str1, int key1, int key2, int key3, int key4, int key5, int key6, int key7, int key8, int key9, int key10, int key11, int key12, int key13, int key14, int key15, int key16, int key17, int key18)
        {
            int n = 1;

            textBox2.Text = "";

            using (StringReader sr = new StringReader(contents))
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////
                while (sr.Peek() >= 0)
                {

                    int asc = (char)sr.Read();

                    string message = Convert.ToString(asc);

                    //textBox22.Text = Convert.ToString(message);






                    if (message.Length == 1)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {

                            Random rnd = new Random();


                            String a = "00000" + message;

                            string str = a;





                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                        
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                         
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                        
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;

                            

                            int code = Convert.ToInt32(n++);
                            textBox23.Text = Convert.ToString(code);
                            

                        }




                    }



                    if (message.Length == 2)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {



                            String a = "0000" + message;
                            string str = a;




                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                        
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                          
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                          
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                          
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                       
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;
                            
                            int code = Convert.ToInt32(n++);
                            textBox23.Text = Convert.ToString(code);
                            

                        }




                    }





                    if (message.Length == 3)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {



                            String a = "000" + message;
                            string str = a;



                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                         
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;
                            
                            int code = Convert.ToInt32(n++);
                            textBox23.Text = Convert.ToString(code);
                           
                           
                        }




                    }


                    if (message.Length == 4)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {



                            String a = "00" + message;
                            string str = a;





                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;
                            
                            int code = Convert.ToInt32(n++);
                           


                        }




                    }






                    if (message.Length == 5)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {




                            String a = "0" + message;
                            string str = a;





                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;
                           
                            int code = Convert.ToInt32(n++);
                            


                        }




                    }




                    if (message.Length == 6)
                    {



                        if (key1 != key2 && key3 != key4 && key5 != key6)
                        {




                            String a = "" + message;
                            string str = a;





                            //////////////////////////////////////////////////////////////////////////////////
                            int pos = key1;
                            char c = str[0];
                            char replacement = c;
                            StringBuilder sb = new StringBuilder(str1);
                            sb[pos] = replacement;
                            str1 = sb.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos2 = key2;
                            char c2 = str[1];
                            char replacement2 = c2;
                            StringBuilder sb2 = new StringBuilder(str1);
                            sb2[pos2] = replacement2;
                            str1 = sb2.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos3 = key3;
                            char c3 = str[2];
                            char replacement3 = c3;
                            StringBuilder sb3 = new StringBuilder(str1);
                            sb3[pos3] = replacement3;
                            str1 = sb3.ToString();
                           
                            //////////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////////////////////////////////////////////////////////
                            int pos4 = key4;
                            char c4 = str[3];
                            char replacement4 = c4;
                            StringBuilder sb4 = new StringBuilder(str1);
                            sb4[pos4] = replacement4;
                            str1 = sb4.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos5 = key5;
                            char c5 = str[4];
                            char replacement5 = c5;
                            StringBuilder sb5 = new StringBuilder(str1);
                            sb5[pos5] = replacement5;
                            str1 = sb5.ToString();
                            
                            //////////////////////////////////////////////////////////////////////////////////
                            int pos6 = key6;
                            char c6 = str[5];
                            char replacement6 = c6;
                            StringBuilder sb6 = new StringBuilder(str1);
                            sb6[pos6] = replacement6;
                            str1 = sb6.ToString();
                            textBox2.Text += str1;
                            
                            int code = Convert.ToInt32(n++);
                           


                        }




                    }








                }
            }
        }

        private void Decrypt(string contents, string counter, int key1, int key2, int key3, int key4, int key5, int key6, int key7, int key8, int key9, int key10, int key11, int key12, int key13, int key14, int key15, int key16, int key17, int key18)
        {

            using (StringReader sr = new StringReader(contents))
            {


                string str1 = contents;

                textBox24.Text = "";

                //textBox23.Text = Convert.ToString(counter);

                int i = 0;
                while (i < int.Parse(counter))
                {

                    string temp = "";

                    //////////////////////////////////////////////////////////////////////////////////
                    int pos = key1;
                    char c = str1[pos + i * 108];
                    temp += c;

                    //////////////////////////////////////////////////////////////////////////////////
                    int pos2 = key2;
                    char c2 = str1[pos2 + i * 108];
                    temp += c2;
                    //////////////////////////////////////////////////////////////////////////////////
                    int pos3 = key3;
                    char c3 = str1[pos3 + i * 108];
                    temp += c3;
                    //////////////////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////////////////
                    int pos4 = key4;
                    char c4 = str1[pos4 + i * 108];
                    temp += c4;
                    //////////////////////////////////////////////////////////////////////////////////
                    int pos5 = key5;
                    char c5 = str1[pos5 + i * 108];
                    temp += c5;
                    //////////////////////////////////////////////////////////////////////////////////
                    int pos6 = key6;
                    char c6 = str1[pos6 + i * 108];
                    temp += c6;

                    //////////////////////////////////////////////////////////////////////////////////
                    int num = int.Parse(temp);
                    char asc = Convert.ToChar(num);
                    textBox24.Text += asc;

                    i++;

                }


                //////////////////////////////////////////////////////////////////////////////////
                /*
                //////////////////////////////////////////////////////////////////////////////////
                int pos7 = key7;
                char c7 = str1[pos7];
                textBox21.Text += c7;
                //////////////////////////////////////////////////////////////////////////////////
                int pos8 = key8;
                char c8 = str1[pos8];
                textBox21.Text += c8;
                //////////////////////////////////////////////////////////////////////////////////
                int pos9 = key9;
                char c9 = str1[pos9];
                textBox21.Text += c9;
                //////////////////////////////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////////////////////////////////
                int pos10 = key10;
                char c10 = str1[pos10];
                textBox21.Text += c10;
                //////////////////////////////////////////////////////////////////////////////////
                int pos11 = key11;
                char c11 = str1[pos11];
                textBox21.Text += c11;
                //////////////////////////////////////////////////////////////////////////////////
                int pos12 = key12;
                char c12 = str1[pos12];
                textBox21.Text += c12;
                //////////////////////////////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////////////////////////////////
                int pos13 = key13;
                char c13 = str1[pos13];
                textBox21.Text += c13;
                //////////////////////////////////////////////////////////////////////////////////
                int pos14 = key4;
                char c14 = str1[pos14];
                textBox21.Text += c14;
                //////////////////////////////////////////////////////////////////////////////////
                int pos15 = key15;
                char c15 = str1[pos15];
                textBox21.Text += c15;
                //////////////////////////////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////////////////////////////////
                int pos16 = key16;
                char c16 = str1[pos16];
                textBox21.Text += c16;
                //////////////////////////////////////////////////////////////////////////////////
                int pos17 = key17;
                char c17 = str1[pos17];
                textBox21.Text += c17;
                //////////////////////////////////////////////////////////////////////////////////
                int pos18 = key18;
                char c18 = str1[pos18];
                textBox21.Text += c18;
                //////////////////////////////////////////////////////////////////////////////////
               */

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {



            int key1 = Convert.ToInt32(textBox3.Text);

            int key2 = Convert.ToInt32(textBox4.Text);

            int key3 = Convert.ToInt32(textBox5.Text);

            int key4 = Convert.ToInt32(textBox6.Text);

            int key5 = Convert.ToInt32(textBox7.Text);

            int key6 = Convert.ToInt32(textBox8.Text);

            textBox23.Text = Convert.ToString(textBox23.Text);
            // counter++;
            
            int key7 = Convert.ToInt32(textBox9.Text);

            int key8 = Convert.ToInt32(textBox10.Text);

            int key9 = Convert.ToInt32(textBox11.Text);

            int key10 = Convert.ToInt32(textBox12.Text);

            int key11 = Convert.ToInt32(textBox13.Text);

            int key12 = Convert.ToInt32(textBox14.Text);


            int key13 = Convert.ToInt32(textBox15.Text);


            int key14 = Convert.ToInt32(textBox16.Text);

            int key15 = Convert.ToInt32(textBox17.Text);

            int key16 = Convert.ToInt32(textBox18.Text);

            int key17 = Convert.ToInt32(textBox19.Text);

            int key18 = Convert.ToInt32(textBox20.Text);

            

            Decrypt(textBox2.Text, textBox23.Text, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16, key17, key18);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
