using DevFreela.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface IUserSkillService
    {
        ResultViewModel<List<UserSkillItemViewModel>> GetSkillByUser(int id);
        ResultViewModel<int> AddSkillToUser(int idUser, int idSkill);
        ResultViewModel RemoveSkillFromUser(int idUser, int idSkill);
    }
}
