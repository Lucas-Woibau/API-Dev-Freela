using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class UserSkillItemViewModel
    {
        public UserSkillItemViewModel(int id, int idUser, int idSkill, string description)
        {
            Id = id;
            IdUser = idUser;
            IdSkill = idSkill;
            Description = description;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
        public string Description { get; private set; }

        public static UserSkillItemViewModel FromEntity(UserSkill skill) =>
            new UserSkillItemViewModel(
                skill.Id,
                skill.IdUser,
                skill.IdSkill,
                skill.Skill?.Description
            );
    }
}
