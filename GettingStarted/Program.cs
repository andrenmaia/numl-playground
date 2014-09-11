using Data;
using numl;
using numl.Model;
using numl.Supervised;
using numl.Supervised.DecisionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {

            var descriptor = Descriptor.Create<Tennis>();
            var generator = new DecisionTreeGenerator(descriptor);


            // Treina com o dados informados e imprime a árvore de decisão
            Tennis[] data = Tennis.GetData();
            generator.SetHint(false);
            var learned = Learner.Learn(data, 0.80, 1000, generator);
            Console.WriteLine(learned);


            // Cria uma previsão com o que aprendeu sobre os dados
            // Nesse caso, é passada uma nova informação para que seja previsto
            // se ocorrerá um jogo de acordo com as previsões informadas.
            IModel model = learned.Model;
            Tennis t = new Tennis
            {
                Perpectiva = Perspectiva.Ensolarado,
                Temperatura = Temperatura.Baixa,
                VentoForte = false
            };

            Tennis predictedVal = model.Predict(t);
            Console.WriteLine("Previsão para:{0}", t);
            Console.WriteLine("{0}{0} --> Play:{1}{0}{0}", Environment.NewLine, predictedVal.OcorreUmJogo);
        }
    }
}
