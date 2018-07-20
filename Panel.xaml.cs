
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
using System.Windows.Shapes;

namespace CertificateDu
{
    /// <summary>
    /// Логика взаимодействия для Panel.xaml
    /// </summary>
    public partial class Panel : Window
    {
        SqlConnection c = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = cert");
        public Panel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("select NameTest from test", c);
            SqlDataAdapter a = new SqlDataAdapter(com);
            DataTable d = new DataTable();
            a.Fill(d);

            for (int i = 0; i < d.Rows.Count; i++)
            {
                tests.Items.Add(d.Rows[i][0].ToString());
            }

            SqlCommand com2 = new SqlCommand("select * from result where id_user = '"+Properties.Settings.Default.UserID+"'", c);
            SqlDataAdapter a2 = new SqlDataAdapter(com2);
            DataTable d2 = new DataTable();
            a2.Fill(d2);

            Button[] b = new Button[1000];
            Grid[] p = new Grid[1000];

            for (int i = 0; i < d2.Rows.Count; i++)
            {
                Button bi = new Button();
                bi.Content = d2.Rows[i][3].ToString();

                Grid p1 = new Grid();
                p1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                p1.Margin = new Thickness(1, 1, 1, 20);

                p1.Background = Brushes.AliceBlue;
                p1.Children.Add(bi);
                p[i] = p1;

                gr.Children.Add(p[i]);
            }

            
        }
    }
}
