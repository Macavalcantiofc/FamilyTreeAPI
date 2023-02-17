using FamilyTreeAPI.Model;

namespace FamilyTreeAPI.Repositories
{
    public interface IFamilyTreeRepository
    {
        Task<IEnumerable<FamilyTree>> familyTreesAsync();
        Task<FamilyTree> Get(int id);
        Task<FamilyTree> Create(FamilyTree familytree);
        Task Update(FamilyTree familytree);
        Task Delete(int id);

    }
}
