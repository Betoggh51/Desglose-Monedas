using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesgloseMonedas
{
    public partial class Form1 : Form
    {
        int papeleta2000 = 0, papeleta1000 = 0, papeleta500 = 0, papeleta200 = 0, papeleta100 = 0, papeleta50 = 0, moneda25 = 0, moneda10 =0, moneda1 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
            {
                MessageBox.Show("Por favor, verifique que la casilla de 'monto' esté llena");
            }
            else
            {
                calcularDesglose();
                llenarDataGridView();
            }
        }

        private void calcularDesglose()
        {
            try
            {
                int monto = int.Parse(txtMonto.Text);

                papeleta2000 = monto / 2000;
                monto = monto - (2000 * papeleta2000);

                papeleta1000 = monto / 1000;
                monto = monto - (1000 * papeleta1000);

                papeleta500 = monto / 500;
                monto = monto - (500 * papeleta500);

                papeleta200 = monto / 200;
                monto = monto - (200 * papeleta200);

                papeleta100 = monto / 100;
                monto = monto - (100 * papeleta100);

                papeleta50 = monto / 50;
                monto = monto - (50 * papeleta50);

                moneda25 = monto / 25;
                monto = monto - (25 * moneda25);

                moneda10 = monto / 10;
                monto = monto - (10 * moneda10);

                moneda1 = monto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el desglose de monedas: " + ex.Message);
                return;
            }
            
        }

        private void llenarDataGridView()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Papeletas 2000");
                dt.Columns.Add("Papeletas 1000");
                dt.Columns.Add("Papeletas 500");
                dt.Columns.Add("Papeletas 200");
                dt.Columns.Add("Papeletas 100");
                dt.Columns.Add("Papeletas 50");
                dt.Columns.Add("Monedas 25");
                dt.Columns.Add("Monedas 10");
                dt.Columns.Add("Monedas 1");

                DataRow fila = dt.NewRow();

                fila["Papeletas 2000"] = papeleta2000;
                fila["Papeletas 1000"] = papeleta1000;
                fila["Papeletas 500"] = papeleta500;
                fila["Papeletas 200"] = papeleta200;
                fila["Papeletas 100"] = papeleta100;
                fila["Papeletas 50"] = papeleta50;
                fila["Monedas 25"] = moneda25;
                fila["Monedas 10"] = moneda10;
                fila["Monedas 1"] = moneda1;

                dt.Rows.Add(fila);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el Data Grid View: " + ex.Message);
                return;
            }
        }

    }
}
