using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Utils
{
    public class VolumeDaMicrobacia : Medidas
    {
        public double VolumeMaximoHistoricoPrecitacao { get; private set; } = 171.8 / 1000;

        public VolumeDaMicrobacia(double altura, double @base, double anguloInclinacao) : base(altura, @base, anguloInclinacao)
        {
        }

        public double CalculoVolumeDaMicrobacia()
        {
            double perimetro;
            double volumeEfetivo;

            perimetro = Altura * Math.Cos(AnguloInclinacao);
            perimetro = Base * perimetro;
            volumeEfetivo = perimetro * VolumeMaximoHistoricoPrecitacao;

            return volumeEfetivo;

        }

        public double ConverteParaLitros(double valor)
        {
            double valorConvertido = valor * 1000;

            return valorConvertido;
        }
    }
}
