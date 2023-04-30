using Notes.Common.Entities;

namespace Notes.Web.PL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegDate { get; set; }

        public static UserModel UserFromEntity(User user)
        {
            return new UserModel()
            {
                Id = user.ID,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                RegDate = user.RegDate
            };
        }
    }
}
