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
    public partial class Form_recite : Form
    {
        string sql;
        string listType = "";
        string orderType = "";
        int listNumber;
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        public Form_recite(string listType,int listNum,string orderType)
        {
            this.listType = listType;
            this.listNumber = listNum;
            this.orderType = orderType;
            this.Text = "Recite " + listType;
            conn = new SqlConnection("Data Source=王璐-VAIO\\SQLEXPRESS;Initial Catalog=dictionary;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            InitializeComponent();
        }

        
        private void button_start_Click(object sender, EventArgs e)
        {
            generateSqlSentence();
            cmd.CommandText = sql;
            dr = cmd.ExecuteReader();
            dr.Read();
            button_start.Hide();
            label_word.Text=dr[0].ToString();
            label_att.Text = dr[1].ToString();
            label_mean.Text = dr[2].ToString();
            label_word.Show();
            label_att.Show();
            label_mean.Show();
            button_next.Show();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (dr.Read())
            {
                label_word.Text = dr[0].ToString();
                label_att.Text = dr[1].ToString();
                label_mean.Text = dr[2].ToString();
                label_word.Refresh();
                label_att.Refresh();
                label_mean.Refresh();
            }
            else 
            {
                label_word.Hide();
                label_att.Hide();
                label_mean.Hide();
                button_next.Hide();
                label_finish.Show();
            }
        }

        public void generateSqlSentence()
        {
            if (listType=="wordTable4"||listType=="wordTable6")
            {
                switch (orderType)
                {
                    case "alpha":
                        sql = "select 单词,词性,解释 from " + listType + " where id >" + 400 * (listNumber - 1) + " and id <= " + 400 * listNumber;
                        break;
                    case "frequency":
                        sql="select 单词,词性,解释 from " + listType + " where id >" + 400 * (listNumber-1) + " and id <= " + 400 * listNumber+" order by 词频";
                        break;
                    case "random":
                        sql = "select 单词,词性,解释 from " + listType + " where id >" + 400 * (listNumber - 1) + " and id <= " + 400 * listNumber + " order by newID()";
                        break;
                }
            }
            else if (listType == "myWordTable")
            {
                switch (orderType)
                {
                    case "alpha":
                        sql = "select m单词,m词性,m解释 from " + listType + " order by m单词";
                        break;
                    case "random":
                        sql = "select m单词,m词性,m解释 from " + listType + " order by newID()";
                        break;
                }
            }
            else if (listType == "idiom")
            {
                switch (orderType)
                {
                    case "alpha":
                        sql = "select 单词,词性,解释 from " + listType + " order by 单词";
                        break;
                    case "frequency":
                        sql = "select 单词,词性,解释 from " + listType + " order by 词频";
                        break;
                    case "random":
                        sql = "select 单词,词性,解释 from " + listType + " order by newID()";
                        break;
                }
            }
            else
            {
                switch (orderType)
                {
                    case "alpha":
                        sql = "execute reciteMyListAlpha " + listNumber;
                        break;
                    case "random":
                        sql = "execute reciteMyListRandom " + listNumber;
                        break;
                }
            }
        }

    }
}
