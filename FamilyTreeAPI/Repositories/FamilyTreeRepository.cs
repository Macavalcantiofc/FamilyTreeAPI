using FamilyTreeAPI.Model;
using FamilyTreeAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Repositories
{
    public class FamilyTreeRepository : IFamilyTreeRepository
    {
        private readonly FamilyTreeContext _Context;
        public FamilyTreeRepository(FamilyTreeContext Context)
        {
            _Context = Context;
        }

        public async Task<FamilyTree> Create(FamilyTree familytree)
        {
           _Context.FamilyTree.Add(familytree);
           await _Context.SaveChangesAsync();
            return familytree;

        }

        public async Task Delete(int id)
        {
            var Deletefamilytree = await _Context.FamilyTree.FindAsync(id);
            if (Deletefamilytree != null)
            {
                _Context.FamilyTree.Remove(Deletefamilytree);
            }
            await _Context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<FamilyTree>> familyTreesAsync()
        {
            return await _Context.FamilyTree.ToListAsync();

        }

        public async Task<FamilyTree> Get(int id)
        {
            return await _Context.FamilyTree.FindAsync(id);
        }

        public async Task Update(FamilyTree familytree)
        {
            _Context.Entry(familytree).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
