using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Optimus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtendimentoPage : ContentPage
    {
        private int iTela = 0;
        private int telaAnterior = 0;
        public int Tela
        {
            get
            {
                return iTela;
            }
            set
            {
                iTela = value;
                /*
                  0: Tela inicial de atendimento
                  1: Tela com detalhes do cidadão
                  2: Tela de perguntas
                  3: Tela de relatórios
                  4: Tela de encaminhamentos
                */

                stlPessoa.IsVisible = (iTela == 0) || (iTela == 1) || (iTela == 2) || (iTela == 3) || (iTela == 4);
                stlCategorias.IsVisible = (iTela == 0) || (iTela == 100) || (iTela == 2) || (iTela == 3) || (iTela == 4);
                stlPessoaDetalhe.IsVisible = (iTela == 1);
                stlAtendimento1.IsVisible = (iTela == 0);
                stlAtendimento2.IsVisible = (iTela == 2);
                stlRelatorio.IsVisible = (iTela == 3);
                stlEncaminhamento.IsVisible = (iTela == 4);

                imgSeta.Source = ((iTela == 1) ? "seta2.png" : "seta.png");
            }
        }

        public AtendimentoPage()
        {
            InitializeComponent();
            Tela = 0;
            stlPessoa.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => stlPessoa_Click())
            });
            stlPessoaDetalhe.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => stlPessoaDetalhe_Click())
            });

            btnIniciar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Tela = 2)
            });
            tabAtendimento.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Tela = 0)
            });
            tabRelatorio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Tela = 3)
            });
            tabEncaminhamento.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Tela = 4)
            });
        }

        private void stlPessoa_Click()
        {
            if (Tela == 1)
            {
                stlPessoaDetalhe_Click();
            }
            else
            {
                telaAnterior = Tela;
                Tela = 1;
            }
        }

        private void stlPessoaDetalhe_Click()
        {
            Tela = telaAnterior;
        }

    }
}
