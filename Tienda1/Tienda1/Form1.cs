using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Forms2 enviarValor = new Forms2();
        public double descuentoDiezPorCiento;
        public double aumentoTresPorCiento;
        public double descuentoDocePorCiento;
        public double descuentoSietePorCiento;
        public double aumentoTreintaPorCiento;
        public double valor1;
        public double valor2;
        public double total;
        public int cortaComunStandard = 150;
        public int cortaComunPremium = 150;
        public int cortaMaoStandard = 100;
        public int cortaMaoPremium = 100;
        public int largaComunStandard = 175;
        public int largaComunPremium = 175;
        public int largaMaoStandard = 75;
        public int largaMaoPremium = 75;
        public int pantalonComunStandard = 250;
        public int pantalonComunPremium = 250;
        public int pantalonChupinStandard = 750;
        public int pantalonChupinPremium = 750;
        public bool sinStockLabelTotal = false;
        public bool sinStockLabelUnidades = false;
        public bool excepcion = false;


        private void botonCotizar_Click(object sender, EventArgs e)
        {
            try
            {
                valor1 = int.Parse(textBox1.Text);
                valor2 = int.Parse(textBox2.Text);
            }
            catch (SystemException)
            {
                excepcion = true;
            }/*obtiene los valores de precio unitario y cantidad, si no
              lanza una excepcion*/


            //CONDICIONALES PARA MOSTRAR UNIDADES DISPONIBLES
            //cortaComunStandard
            if (tildarCamisa.Checked && tildarMangaCorta.Checked
                && calidadStandard.Checked && valor2 <= cortaComunStandard)
            {
                label8.Text = Convert.ToString(cortaComunStandard - valor2);
            }
            //cortaComunPremium
            else if (tildarCamisa.Checked && tildarMangaCorta.Checked
                && calidadPremiumClick.Checked && valor2 <= cortaComunPremium)
            {
                label8.Text = Convert.ToString(cortaComunPremium - valor2);
            }

            //cortaMaoStandard
            else if (tildarCamisa.Checked && tildarCuelloMao.Checked
                && calidadStandard.Checked && valor2 <= cortaMaoStandard)
            {
                label8.Text = Convert.ToString(cortaMaoStandard - valor2);
            }

            //cortaMaoPremium
            else if (tildarCamisa.Checked && tildarCuelloMao.Checked
                && calidadPremiumClick.Checked && valor2 <= cortaMaoPremium)
            {
                label8.Text = Convert.ToString(cortaMaoPremium - valor2);
            }

            //largaComunStandard
            else if (tildarCamisa.Checked && calidadStandard.Checked
                && valor2 <= largaComunStandard)
            {
                label8.Text = Convert.ToString(largaComunStandard - valor2);
            }

            //largaComunPremium
            else if (tildarCamisa.Checked && calidadPremiumClick.Checked
                && valor2 <= largaComunPremium)
            {
                label8.Text = Convert.ToString(largaComunPremium - valor2);
            }

            //largaMaoStandard
            else if (tildarCamisa.Checked && calidadStandard.Checked &&
                tildarCuelloMao.Checked && valor2 <= largaMaoStandard)
            {
                label8.Text = Convert.ToString(largaMaoStandard - valor2);
            }

            //largaMaoPremium
            else if (tildarCamisa.Checked && calidadPremiumClick.Checked
                && tildarCuelloMao.Checked && valor2 <= largaMaoPremium)
            {
                label8.Text = Convert.ToString(largaMaoPremium - valor2);
            }

            //pantalonComunStandard
            else if (tildarPantalon.Checked && calidadStandard.Checked &&
                valor2 <= pantalonComunStandard)
            {
                label8.Text = Convert.ToString(pantalonComunStandard - valor2);
            }

            //pantalonComunPremium
            else if (tildarPantalon.Checked && calidadPremiumClick.Checked &&
                valor2 <= pantalonComunPremium)
            {
                label8.Text = Convert.ToString(pantalonComunPremium - valor2);
            }

            //pantalonChupinStandard
            else if (tildarPantalon.Checked && calidadStandard.Checked &&
                tildarChupin.Checked && valor2 <= pantalonChupinStandard)
            {
                label8.Text = Convert.ToString(pantalonChupinStandard - valor2);
            }

            //pantalonChupinPremium
            else if (tildarPantalon.Checked && calidadPremiumClick.Checked &&
               tildarChupin.Checked && valor2 <= pantalonChupinPremium)
            {
                label8.Text = Convert.ToString(pantalonChupinPremium - valor2);
            }
            else
            {
                sinStockLabelUnidades = true;
                if (sinStockLabelUnidades == true)
                {
                    label8.Text = "ERROR, no hay stock";
                }
                sinStockLabelTotal = true;
            }

            //CONDICIONALES PARA DESCUENTOS Y AUMENTOS SEGUN PRENDA

            
            if (tildarMangaCorta.Checked)
            {
                descuentoDiezPorCiento = (valor1 * 10) / 100;
                valor1 = valor1 - descuentoDiezPorCiento;
            }
            if (tildarCuelloMao.Checked)
            {
                aumentoTresPorCiento = valor1 * 1.03f;
                valor1 = aumentoTresPorCiento;
            }
            if (tildarChupin.Checked)
            {
                descuentoDocePorCiento = (valor1 * 12) / 100;
                valor1 = valor1 - descuentoDocePorCiento;
            }
            if (calidadPremiumClick.Checked)
            {
                aumentoTreintaPorCiento = valor1 * 1.30f;
                valor1 = aumentoTreintaPorCiento;
            }

            //CALCULAR VALOR TOTAL 
            total = valor1 * valor2;
            if (sinStockLabelTotal == true)
            {
                label14.Text = "ERROR, no hay stock";
                sinStockLabelTotal = false;
            }
            if (sinStockLabelTotal == false &&
                sinStockLabelUnidades == false)/*si hay stock, 
             se muestra el precio total y se lo añade al historial 
             de cotizaciones*/
            {
                if (excepcion == false)
                {
                    label14.Text = Convert.ToString(total);
                    enviarValor.Cotizaciones.Items.Add(total);
                }
                else
                {
                    label14.Text = "ERROR, verifique los datos ingresados.";
                }
            }
        }

        //LIMPIAR LA INTERFAZ
        private void button1_Click(object sender, EventArgs e)
        {
            tildarMangaCorta.Checked = false;
            tildarCuelloMao.Checked = false;
            tildarChupin.Checked = false;
            tildarCamisa.Checked = false;
            tildarPantalon.Checked = false;
            calidadStandard.Checked = false;
            calidadPremiumClick.Checked = false;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            label8.Text = String.Empty;
            label14.Text = String.Empty;
        }
        //MOSTRAR EL HISTORIAL DE COTIZACIONES
        private void button2_Click(object sender, EventArgs e)
        {
            enviarValor.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
