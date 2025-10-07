namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill) : base()
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; set; }
        public User User { get; private set; }
        public int IdSkill { get; set; }
        public Skill Skill { get; private set; }
    }
}
