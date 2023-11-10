namespace projetoGuardaChuva.Models
{
    public class Medidas
    {
        public int IdEndereco { get; set; }
        public double Altura { get; set; }
        public double Base { get; set; }
        public double AnguloInclinacao { get; set; }

        public Medidas(double altura, double @base, double anguloInclinacao)
        {
            Altura = altura;
            Base = @base;
            AnguloInclinacao = anguloInclinacao;
        }
    }
}
