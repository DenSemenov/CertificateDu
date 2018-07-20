using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CertificateDu
{
     
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        SqlConnection c =    new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = cert;");
        System.Data.DataTable d = new System.Data.DataTable();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from \"User\"", c);
            SqlDataAdapter a = new SqlDataAdapter(com);
            a.Fill(d);


            for (int i = 0; i < d.Rows.Count; i++)
            {
                users.Items.Add(d.Rows[i][1].ToString());
            }
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            bool isLogin = false;

            for (int i = 0; i < d.Rows.Count; i++)
            {
                if (d.Rows[i][1].ToString() == users.Text && d.Rows[i][2].ToString() == pass.Password){
                    isLogin = true;

                    Properties.Settings.Default.UserID = d.Rows[i][0].ToString();
                    Properties.Settings.Default.UserLogin = d.Rows[i][1].ToString();
                    Properties.Settings.Default.UserPassword = d.Rows[i][2].ToString();
                    Properties.Settings.Default.UserName = d.Rows[i][3].ToString();
                    Properties.Settings.Default.UserName = d.Rows[i][4].ToString();
                }
            }

            if (isLogin)
            {
                

                Panel p = new Panel();
                p.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }

        private void excell_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Open(@"D:\Programs\Учеба\Olimp2018\olymp_fos_res\Ресурсы\Resourse.xlsx");
            Worksheet ws = (Worksheet)wb.Sheets[1];

            for (int i = 2; i < 1000; i++)
            {
                SqlCommand com1 = new SqlCommand("insert into BankOfQuestions values('" + ws.Cells[i, 1].Text.Replace("'", "") + "', '" + ws.Cells[i, 2].Text.Replace("'", "") + "', '" + ws.Cells[i, 3].Text.Replace("'", "") + "','" + ws.Cells[i, 4].Text.Replace("'", "") + "','" + ws.Cells[i, 5].Text.Replace("'", "") + "','" + ws.Cells[i, 6].Text.Replace("'", "") + "','" + ws.Cells[i, 7].Text.Replace("'", "") + "','" + ws.Cells[i, 8].Text.Replace("'", "") + "','" + ws.Cells[i, 9].Text.Replace("'", "") + "','" + ws.Cells[i, 10].Text.Replace("'", "") + "','" + ws.Cells[i, 11].Text.Replace("'", "") + "','" + ws.Cells[i, 12].Text.Replace("'", "") + "','" + ws.Cells[i, 13].Text.Replace("'", "") + "','" + ws.Cells[i, 14].Text.Replace("'", "") + "','" + ws.Cells[i, 15].Text.Replace("'", "") + "','" + ws.Cells[i, 16].Text.Replace("'", "") + "')", c);
                SqlDataAdapter a1 = new SqlDataAdapter(com1);
                System.Data.DataTable d1 = new System.Data.DataTable();
                a1.Fill(d1);
            }

            app.Quit();




            
        }
    }
}
