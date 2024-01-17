namespace RestApi.Entities.DTO
{
    public class UserForUpdate
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public bool isActive { get; set; }
    }
}
