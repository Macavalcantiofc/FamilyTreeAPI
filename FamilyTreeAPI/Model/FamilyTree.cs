namespace FamilyTreeAPI.Model
{
    public class FamilyTree
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? IdMae { get; set; }
        public string? IdPai { get; set; }
        public string IdFamilia { get; set; }

    }
}
