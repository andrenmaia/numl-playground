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
            Tennis[] data = Tennis.GetData();
            var d = Descriptor.Create<Tennis>();
            var g = new DecisionTreeGenerator(d);

            g.SetHint(false);
            var learned = Learner.Learn(data, 0.80, 1000, g);

            Console.WriteLine(learned);

            IModel model = learned.Model;
            double accuracy = learned.Accuracy;

            Tennis t = new Tennis
            {
                Outlook = Outlook.Sunny,
                Temperature = Temperature.Low,
                Windy = false
            };

            Tennis predictedVal = model.Predict(t);

            Console.WriteLine("Play:{0}", predictedVal.Play);
        }
    }
}
