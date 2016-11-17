using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AgendaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            compromissos = new List<Models.Compromisso>();
        }

        private string ip = "http://localhost:53097";
        private List<Models.Compromisso> compromissos;

        private bool IsRealizado()
        {
            if (checkBox.IsChecked == true) return true;
            else return false;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Models.Compromisso comp = new Models.Compromisso();
            comp.Descricao = txtDesc.Text;
            comp.Local = txtLocal.Text;
            comp.Data = datepicker.SelectedDate.Value;
            comp.Realizado = IsRealizado();
            compromissos.Add(comp);
            MessageBox.Show("Cadastrado!");
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Models.Compromisso c in compromissos)
            {
                lvCompromissos.Items.Add("Desc: " + c.Descricao + 
                    " Local: " + c.Local + " Data: " + c.Data.Date + 
                    " Realizado: " + c.Realizado);
            }
        }

        /* HTTP */

        private async void btnDispServ_Click(object sender, RoutedEventArgs e)
        {
            //faz contato com o servidor
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);

            //entra no servidor e pega uma lista de compromissos
            var response = await httpClient.GetAsync("/api/agenda/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Compromisso> obj = JsonConvert.DeserializeObject<List<Models.Compromisso>>(str);

            //deleta todos os compromissos do servidor de acordo com a lista obtida
            foreach (Models.Compromisso c in obj)
                await httpClient.DeleteAsync("/api/agenda/" + c.Id.ToString());

            //pega a lista do dispositivo, serializa e insere no servidor
            string s = "=" + JsonConvert.SerializeObject(compromissos);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PostAsync("/api/agenda/", content);

            MessageBox.Show("Atualizado (D-S)!");
        }

        private async void btnServDisp_Click(object sender, RoutedEventArgs e)
        {
            // Acessa os dados do serviço para recuperar a lista de compromissos
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/agenda/");
            var str = response.Content.ReadAsStringAsync().Result;

            // Converte o json do serviço para uma lista
            List<Models.Compromisso> obj = JsonConvert.DeserializeObject<List<Models.Compromisso>>(str);

            // Apaga os dados locais
            compromissos.RemoveRange(0, compromissos.Count);

            // Grava a lista de compromissos no dispositivo;
            compromissos = obj;

            MessageBox.Show("Atualizado (S-D)!");
        }
    }
}
