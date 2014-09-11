using numl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Data
{
    public enum Perspectiva
    {
        Ensolarado,
        Nublado,
        Chuvoso
    }

    public enum Temperatura
    {
        Baixa,
        Alta
    }

    public class Tennis
    {
        [Feature]
        public Perspectiva Perpectiva { get; set; }

        [Feature]
        public Temperatura Temperatura { get; set; }

        [Feature]
        public bool VentoForte { get; set; }

        [Label]
        public bool OcorreUmJogo { get; set; }

        public static Tennis[] GetData()
        {
            return new Tennis[]  {
                new Tennis { OcorreUmJogo = true, Perpectiva=Perspectiva.Ensolarado, Temperatura = Temperatura.Baixa, VentoForte=true},
                new Tennis { OcorreUmJogo = false, Perpectiva=Perspectiva.Ensolarado, Temperatura = Temperatura.Alta, VentoForte=true},
                new Tennis { OcorreUmJogo = false, Perpectiva=Perspectiva.Ensolarado, Temperatura = Temperatura.Alta, VentoForte=false},
                new Tennis { OcorreUmJogo = true, Perpectiva=Perspectiva.Nublado, Temperatura = Temperatura.Baixa, VentoForte=true},
                new Tennis { OcorreUmJogo = true, Perpectiva=Perspectiva.Nublado, Temperatura = Temperatura.Alta, VentoForte= false},
                new Tennis { OcorreUmJogo = true, Perpectiva=Perspectiva.Nublado, Temperatura = Temperatura.Baixa, VentoForte=false},
                new Tennis { OcorreUmJogo = false, Perpectiva=Perspectiva.Chuvoso, Temperatura = Temperatura.Baixa, VentoForte=true},
                new Tennis { OcorreUmJogo = true, Perpectiva=Perspectiva.Chuvoso, Temperatura = Temperatura.Baixa, VentoForte=false}
            };
        }
        
        public override string ToString()
        {
            return string.Format("Perpectiva: {0}, Temperatura:{1}, VentoForte: {2}", Perpectiva, Temperatura, VentoForte);
        }
    }
}
