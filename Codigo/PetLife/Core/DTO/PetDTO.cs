namespace Core.DTO
{
    public class PetDTO
    {
        public uint Id {  get; set; }
        public string Nome { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raca { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; } = null!;
        public double Peso { get; set; }
        public uint IdTutor { get; set; }
    }
}
