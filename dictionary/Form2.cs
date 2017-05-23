using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dictionary
{
    public partial class Form2 : Form
    {
        int ID;
        int wordTable;
        string listName;
        int listNum;
        private Form1 form1;
        SqlCommand cmd;
        SqlConnection conn;
        public Form2(List<string> node, int ID,int wordTable,Form1 form)
        {
            this.ID = ID;
            this.wordTable = wordTable;
            form1 = form;
            conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            InitializeComponent();
            loadButton();
        }

        private void button_createList_Click(object sender, EventArgs e)
        {
            button_create.Show();
            textBox_newList.Show();
            label_listName.Show();
            button_createList.Hide();
        }

        //新建列表并将此条加入其中,同时更新背诵模块的list,完成后关闭窗口
        private void button_create_Click(object sender, EventArgs e)
        {
            listName = textBox_newList.Text.Trim();
            if (nameExist(listName))
            {
                MessageBox.Show("已存在相同名字的列表");
            }
            else
            {
                //listNum=setListNum().ToString();
                setListNum();
                cmd.CommandText = "insert into ListInfo values (" + listNum + ",' "+listName+" ')";
                cmd.ExecuteNonQuery();
                if (form1.flag == true)
                {
                    form1.loadTreeView();
                    form1.flag = false;
                }
                else 
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = listNum.ToString();
                    tn.Text = listName;
                    form1.treeView_recite.Nodes[2].Nodes.Add(tn);
                }
                cmd.CommandText = "insert into myList values (" + ID + "," + wordTable + "," + listNum + ")";
                cmd.ExecuteNonQuery();
                panel_button.Controls.Clear();
                loadButton();
                MessageBox.Show("创建背诵列表成功，并且已将该词条加入");
                this.Close();
            }

        }

        public void setListNum()
        {
            cmd.CommandText = "select count(listNum) from ListInfo";
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if(dr[0].ToString()!="0"){
               listNum= int.Parse(dr[0].ToString()) + 2;
            }
            else {
               listNum = 2;
            }
            dr.Close();
        }



        //判断列表是否已经存在
        private bool nameExist(string listName)
        {
            cmd.CommandText = "select * from ListInfo where myListName=' " + listName + " '";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                return true;
            }
            else 
            {
                dr.Close();
                return false;
            }
        }

        private void loadButton() 
        {
            int x = 20;//确定button的位置
            int y = 10;
            Button bt1 = new Button();
            bt1.Name = "1";
            bt1.Text = "默认列表";
            bt1.Location = new Point(x, y);
            //bt1.BackColor = Color.AliceBlue;
            bt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            bt1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            panel_button.Controls.Add(bt1);
            //this.Controls.Add(bt1);
            bt1.Click += new EventHandler(button_Click);
            cmd.CommandText = "select * from ListInfo";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                y += 40;
                if (y > 210) 
                {
                    y = 10;
                    x += 100;
                }
                Button button = new Button();
                button.Name = dr[0].ToString();
                button.Text = dr[1].ToString();
                button.Location = new Point(x, y);
                //button.BackColor = Color.AliceBlue;
                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                panel_button.Controls.Add(button);
                //this.Controls.Add(button);
                button.Click += new EventHandler(button_Click);
            }
            dr.Close();
            panel_button.ResumeLayout();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//为了知道是哪个button触发了事件
            if (wordExist(btn.Name))
            {
                MessageBox.Show("添加失败！！列表中已存在该词条,请重新选择！");
            }
            else
            {
                cmd.CommandText = "insert into myList values (" + ID + "," + wordTable + "," + btn.Name + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加成功");
                this.Close();
            }
        }

        //词条在所选列表中是否已存在
        private bool wordExist(string num) 
        {
            cmd.CommandText = "select * from myList where ID="+this.ID +" and WordTable="+this.wordTable+" and listNum="+num;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                return true;
            }
            else 
            {
                dr.Close();
                return false;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.word = null;
            form1.att = null;
            form1.mean = null;
        }
    }
}
