namespace copa
{
    public class Resultado
    {
        public string campeao { get; set; }
        public string vice { get; set; }
        public string final { get; set; }
        public Semifinais semifinais { get; set; }
        public Quartasfinal quartasfinal { get; set; }
    }

    public class Semifinais 
    {        
        public string chave1 { get; set; }
        public string chave2 { get; set; }
    }

    public class Quartasfinal
    {
        public string chave1 { get; set; }
        public string chave2 { get; set; }
        public string chave3 { get; set; }
        public string chave4 { get; set; }
    }
}
