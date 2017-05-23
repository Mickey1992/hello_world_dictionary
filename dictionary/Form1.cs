using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
namespace dictionary
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        string myword;
        string myatt;
        string mymean;
        string oldAtt;
        string oldMean;
        string listType;
        public string word;//添加到背诵列表
        public string att;
        public string mean;
        int listNum;
        public bool flag = true;
        string orderType;
        public Form1()
        {
            conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            InitializeComponent();
        }

        private void button_word_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            if (panel1.Visible == false)
            {
                panel1.Show();
            }
        }

        private void button_recite_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            if (panel2.Visible == false)
            {
                panel2.Show();
                if (flag)
                {
                    loadTreeView();
                    flag = false;
                }
            }
        }



        /**************************************************************************我的单词本**********************************************************************************/

        //进入我的单词本界面
        private void button_myword_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            if (panel3.Visible == false)
            {
                panel3.Show();
                listView1.Items.Clear();
                showMywordList();
                button_delete.Enabled = false;
                button_update.Enabled = false;
                textBox_word.ReadOnly = false;
                textBox_word.Text = "";
                textBox_att.Text = "";
                textBox_mean.Text = "";
            }
        }




        //修改词条
        private void button_update_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            myword = textBox_word.Text.Trim();
            myatt = textBox_att.Text.Trim();
            mymean = textBox_mean.Text.Trim();
            cmd.CommandText = "update  myWordTable set m词性= '" + myatt + "' , m解释='" + mymean + "' where m单词='" + myword + "' and m词性= '" + oldAtt + "' and m解释='" + oldMean + "'";
            cmd.Connection = conn;
            if (inTable(myword, myatt, mymean))
            {
                if (myatt == oldAtt && mymean == oldMean)
                {
                    MessageBox.Show("您未对词条进行修改");
                }
                else
                {
                    MessageBox.Show("该词条已存在");
                }

            }
            else 
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                listView1.Refresh();
                listView1.Items.Clear();
                showMywordList();
                conn.Close();
                MessageBox.Show("已更新");
            }
            button_delete.Enabled = false;
            button_update.Enabled = false;
            textBox_word.ReadOnly = false;
            textBox_word.Text = "";
            textBox_att.Text = "";
            textBox_mean.Text = "";
        }


        //删除词条
        private void button_delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            myword = textBox_word.Text.Trim();
            myatt = textBox_att.Text.Trim();
            mymean = textBox_mean.Text.Trim();
            cmd.CommandText = "delete from myWordTable where m单词='" + myword + "' and m词性= '" + myatt + "' and m解释='" + mymean + "'";
            cmd.Connection = conn;
            if (inTable(myword, myatt, mymean))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                listView1.Items.Clear();
                showMywordList();
                conn.Close();
                MessageBox.Show("已删除");                
            }
            else
            {
                MessageBox.Show("删除失败，请检查信息是否正确");
            }
            button_delete.Enabled = false;
            button_update.Enabled = false;
            textBox_word.ReadOnly = false;
            textBox_word.Text = "";
            textBox_att.Text = "";
            textBox_mean.Text = "";
        }


        //新增词条
        private void button_add_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(); 
            myword = textBox_word.Text.Trim();
            myatt = textBox_att.Text.Trim();
            mymean = textBox_mean.Text.Trim();
            cmd.CommandText = "insert into myWordTable (m单词,m词性,m解释) values ('" + myword + " ','" + myatt + "','" + mymean + "')";
            cmd.Connection = conn;

            if (inTable(myword, myatt, mymean))
            {
                MessageBox.Show("该词条已存在");
                textBox_word.Text = "";
                textBox_att.Text = "";
                textBox_mean.Text = "";
            }
            else
            {
                if (myword == "" || myatt == "" || mymean == "")
                {
                    MessageBox.Show("创建词条失败，请查看信息是填写否完整");
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    listView1.Items.Clear();
                    showMywordList();
                    MessageBox.Show("创建成功");
                    textBox_word.Text = "";
                    textBox_att.Text = "";
                    textBox_mean.Text = "";
                }
            }
        }


        //将myWordList中的单词添加到listView1上
        public void showMywordList() 
        {
            //SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("select m单词,m词性,m解释 from myWordTable",conn);
            cmd.CommandText = "select m单词,m词性,m解释 from myWordTable";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                ListViewItem lv = new ListViewItem(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                listView1.Items.Add(lv);
            }
            dr.Close();
            //conn.Close();
        }


        //获得listView中选定的数据,显示到对应的textbox中
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count!=0) 
            {
                textBox_word.Text = this.listView1.FocusedItem.SubItems[0].Text;
                textBox_att.Text = this.listView1.FocusedItem.SubItems[1].Text;
                textBox_mean.Text = this.listView1.FocusedItem.SubItems[2].Text;
                button_delete.Enabled = true;
                button_update.Enabled = true;
                textBox_word.ReadOnly = true;
                oldAtt = textBox_att.Text;
                oldMean = textBox_mean.Text;               
            }
            else
            {
                button_delete.Enabled = false;
                button_update.Enabled = false;
                textBox_word.ReadOnly = false;
                textBox_word.Text = "";
                textBox_att.Text = "";
                textBox_mean.Text = "";
            }
        }


        //检查用户需要进行操作的单词在数据库中是否存在
        public bool inTable(string w, string a, string m) 
        {
            //SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("select m单词,m词性,m解释 from myWordTable where m单词='" + w + "' and m词性= '" + a + "' and m解释='" + m + "'", conn);
            cmd.CommandText = "select m单词,m词性,m解释 from myWordTable where m单词='" + w + "' and m词性= '" + a + "' and m解释='" + m + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                //conn.Close();
                dr.Close();
                return true;
            }
            else 
            {
                //conn.Close();
                dr.Close();
                return false;
            }

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            button_delete.Enabled = false;
            button_update.Enabled = false;
            textBox_word.ReadOnly = false;
            textBox_word.Text = "";
            textBox_att.Text = "";
            textBox_mean.Text = "";
        }

        /************************************************************************************单词查询*********************************************************************************************/
        private void button_search_Click(object sender, EventArgs e)
        {
            
            listView2.Items.Clear();
            Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
            if (wordSearch.Text == "")
            {
                MessageBox.Show("请输入需要查询的内容");
            }
            else
            {
                if (rx.IsMatch(wordSearch.Text))
                {
                    showWordListC();
                }
                else
                {
                    showWordListE();
                }
                wordSearch.Text = "";
                button_addtolist.Show();
            }
        }

        // check if the word is in the table
        public bool CisInTable(string s)
        {
            SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("", conn);
            if (radio4.Checked == true)
            {
                cmd.CommandText += "execute chinToEng4 " + wordSearch.Text;
            }
            else if (radio6.Checked == true)
            {
                cmd.CommandText += "execute chinToEng6 " + wordSearch.Text;
            }


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                dr.Close();
                return true;
            }
            else {
                conn.Close();
                dr.Close();
                MessageBox.Show("您输入有误，请重新输入");
                return false;
            }
        }
        public bool EisInTable(string s) {
            SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("", conn);
            if (radio4.Checked == true)
            {
                cmd.CommandText += "execute engToChin4 " + wordSearch.Text;
            }
            else if (radio6.Checked == true)
            {
                cmd.CommandText += "execute engToChin6 " + wordSearch.Text;
            }


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                dr.Close();
                return true;
            }
            else
            {
                conn.Close();
                dr.Close();
                MessageBox.Show("您输入有误，请重新输入");
                return false;
            }
        }
        //将查询到的内容显示在listview2上
        public void showWordListE() {
            if (EisInTable(wordSearch.Text))
            {
                SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                if (radio4.Checked == true)
                {
                    cmd.CommandText += "execute engToChin4 " + wordSearch.Text;
                }
                else if (radio6.Checked == true)
                {
                    cmd.CommandText += "execute engToChin6 " + wordSearch.Text;
                }


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    ListViewItem lv = new ListViewItem(dr[0].ToString());
                    lv.SubItems.Add(dr[1].ToString());
                    lv.SubItems.Add(dr[2].ToString());
                    listView2.Items.Add(lv);

                }
                dr.Close();
                conn.Close();
            }
            else { }
        }
        public void showWordListC() {
            if (CisInTable(wordSearch.Text))
            {
                SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);
                if (radio4.Checked == true)
                {
                    cmd.CommandText += "execute chinToEng4 " + wordSearch.Text;
                }
                else if (radio6.Checked == true)
                {
                    cmd.CommandText += "execute chinToEngn6 " + wordSearch.Text;
                }


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    ListViewItem lv = new ListViewItem(dr[0].ToString());
                    lv.SubItems.Add(dr[1].ToString());
                    lv.SubItems.Add(dr[2].ToString());
                    listView2.Items.Add(lv);

                }
                dr.Close();
                conn.Close();
            }
            else { }
        }

        
        //输入英文单词时自动提示
        private void wordSearch_TextChanged(object sender, EventArgs e)
         {
             //SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
             //SqlCommand cmd = new SqlCommand();
             //cmd.Connection = conn;
             string str=wordSearch.Text.Trim();
             wordSearch.AutoCompleteCustomSource.Clear();
             if (radio4.Checked == true)
             {
                 cmd.CommandText = "select top 5 单词 from wordTable4 where 单词 like '" + str + "%'";
             }
             else if (radio6.Checked == true)
             {
                 cmd.CommandText = "select top 5 单词 from wordTable6 where 单词 like '" + str + "%'";
             }
             //conn.Open();
             SqlDataReader dr = cmd.ExecuteReader();
             while(dr.Read())
             {
                 wordSearch.AutoCompleteCustomSource.Add(dr[0].ToString()); 
             }
             dr.Close();
         }




        /********************************************************************单词背诵***************************************************************************/
        //按字母顺序背诵
        private void button_alpha_Click(object sender, EventArgs e)
        {
            if (listType == "" || (listType != "myWordTable" && listType != "idiom" && listNum == 0))
            {
                MessageBox.Show("请选择一个背诵列表");
            }
            else
            {
                orderType = "alpha";
                Form_recite f_recite = new Form_recite(listType, listNum, orderType);
                listNum = 0;
                f_recite.ShowDialog();
            }
        }

       //按词频背诵 
        private void button_f_Click(object sender, EventArgs e)
        {
            if (listType == "" || (listType != "myWordTable" && listType != "idiom" && listNum == 0))
            {
                MessageBox.Show("请选择一个背诵列表");
            }
            else if (listType == "myWordTable"||listType=="MyList")
            {
                MessageBox.Show("该列表不支持按词频背诵");
            }
            else
            {
                orderType = "frequency";
                Form_recite f_recite = new Form_recite(listType, listNum, orderType);
                listNum = 0;
                f_recite.ShowDialog();
            }
        }


        //按随机排序背诵
        private void button_random_Click(object sender, EventArgs e)
        {
            if (listType == "" || (listType != "myWordTable" && listType != "idiom" && listNum == 0))
            {
                MessageBox.Show("请选择一个背诵列表");
            }
            else
            {
                orderType = "random";
                Form_recite f_recite = new Form_recite(listType, listNum, orderType);       
                listNum=0;
                f_recite.ShowDialog();
            }
        }



        //选择一个背诵列表
        private void treeView_recite_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView_recite.SelectedNode.Name == "Node_MyWordTable" || treeView_recite.SelectedNode.Name == "Node_idiom")
            {
                switch (treeView_recite.SelectedNode.Name)
                {
                    case "Node_MyWordTable":
                        listType = "myWordTable";
                        break;
                    case "Node_idiom":
                        listType = "idiom";
                        break;
                    default:
                        break;
                }

            }
            else if (treeView_recite.SelectedNode.Name == "Node_CET-4" || treeView_recite.SelectedNode.Name == "Node_CET-6" || treeView_recite.SelectedNode.Name == "Node_MyList") { }
            else
            {
                switch (treeView_recite.SelectedNode.Parent.Name)
                {
                    case "Node_CET-4":
                        listType = "wordTable4";
                        switch (treeView_recite.SelectedNode.Name)
                        {
                            case "Node1":
                                listNum = 1;
                                break;
                            case "Node2":
                                listNum = 2;
                                break;
                            case "Node3":
                                listNum = 3;
                                break;
                            case "Node4":
                                listNum = 4;
                                break;
                            case "Node5":
                                listNum = 5;
                                break;
                            case "Node6":
                                listNum = 6;
                                break;
                            case "Node7":
                                listNum = 7;
                                break;
                            case "Node8":
                                listNum = 8;
                                break;
                            case "Node9":
                                listNum = 9;
                                break;
                            case "Node10":
                                listNum = 10;
                                break;
                            case "Node11":
                                listNum = 11;
                                break;
                        }
                        break;
                    case "Node_CET-6":
                        listType = "wordTable6";
                        switch (treeView_recite.SelectedNode.Name)
                        {
                            case "Node16":
                                listNum = 1;
                                break;
                            case "Node17":
                                listNum = 2;
                                break;
                            case "Node18":
                                listNum = 3;
                                break;
                            case "Node19":
                                listNum = 4;
                                break;
                            case "Node20":
                                listNum = 5;
                                break;
                            case "Node21":
                                listNum = 6;
                                break;
                        }
                        break;
                    case "Node_MyList":
                        listType = "MyList";
                        listNum = int.Parse(treeView_recite.SelectedNode.Name.ToString());
                        break;
                    default:
                        break;
                }
            }
        }




        /***********************************************************添加到背诵列表****************************************************************/
        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.listView2.SelectedItems.Count != 0)
            {
                word = this.listView2.FocusedItem.SubItems[0].Text;
                att = this.listView2.FocusedItem.SubItems[1].Text;
                mean = this.listView2.FocusedItem.SubItems[2].Text;
            }
            else
            {
                word = null;
                att = null;
                mean = null;
            }
        }

        private void button_addtolist_Click(object sender, EventArgs e)
        {
            if (word==null)
            {
                MessageBox.Show("请选择需要添加的词条");
            }
            else
            {               
                Form2 F;
                if (radio4.Checked == true)
                {
                    F = new Form2(getMyListNodes(),getID(word,att,mean),4,this);
                }
                else
                {
                    F = new Form2(getMyListNodes(),getID(word, att, mean), 6,this);
                }
                F.ShowDialog();
            }

        }

        //读取自建背诵列表下的所有节点
        public List<string> getMyListNodes() 
        {
            List<string> node=new List<string>  ();
            foreach (TreeNode tn in treeView_recite.Nodes)
            {
                if (tn.Name=="Node_MyList")
                {
                    foreach (TreeNode n in tn.Nodes)
                    node.Add(n.Text);
                }
            }
            return node;
        }

        public int getID(string word, string att, string mean) {
            //SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //conn.Open();
            if (radio4.Checked == true)
            {
                cmd.CommandText = "select ID from wordTable4 where 单词='" + word + " 'and 词性='" + att + " 'and 解释='" + mean + " '";
            }
            else 
            {
                cmd.CommandText = "select ID from wordTable6 where 单词='" + word + " 'and 词性='" + att + " 'and 解释='" + mean + " '";
            }
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int result= int.Parse(dr[0].ToString());
            dr.Close();
            return result;
        }

        public void loadTreeView() {
            //SqlConnection conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //conn.Open();
            cmd.CommandText = "select * from ListInfo";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                TreeNode tn = new TreeNode();
                tn.Name = dr[0].ToString();
                tn.Text = dr[1].ToString();
                treeView_recite.Nodes[2].Nodes.Add(tn);
            }
            dr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
